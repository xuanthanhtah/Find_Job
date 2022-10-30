using FindJobSolution.Application.Common;
using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace FindJobSolution.Application.Catalog
{
    public interface IJobSeekerService
    {
        Task<int> Update(JobSeekerUpdateRequest request);
        Task<int> Delete(int JobSeekerId);
        Task<PagedResult<JobSeekerViewModel>> GetAllPaging(GetJobSeekerPagingRequest request);
        Task<List<JobSeekerViewModel>> GetAll();
        Task<JobSeekerViewModel> GetbyId(int JobSeekerId);
        Task<int> AddImages(int JobSeekerId, List<IFormFile> request);
        Task<int> RemoveImages(int CvId);
        Task<int> UpdateImages(int CvId, string caption, bool isDefault);
        Task<List<JobSeekerCvViewModel>> GetCvByJobSeekerId(int JobSeekerId);
    }
    public class JobSeekerService : IJobSeekerService
    {
        private readonly FindJobDBContext _context;
        private readonly IStorageService _storageService;
        public JobSeekerService(FindJobDBContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public Task<int> AddImages(int JobSeekerId, List<IFormFile> request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int JobSeekerId)
        {
            //nếu có jobseeker thì xóa
            var jobSeeker = await _context.JobSeekers.FindAsync(JobSeekerId);
            if (jobSeeker == null) { throw new FindJobException($"cannot find a jobSeeker: {JobSeekerId}"); }


            //xóa ảnh
            var thumbnailCv =  _context.Cvs.Where(i =>i.JobSeekerId == JobSeekerId);
            foreach (var image in thumbnailCv)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }

            //xóa jobseeker
            _context.JobSeekers.Remove(jobSeeker);
            //tìm user của jobseeker đó, xong xóa
            var userId = await _context.Users.FindAsync(jobSeeker.UserId);
            if (userId != null)
            {
                _context.Users.Remove(userId);
            }
            
            return await _context.SaveChangesAsync();
        }

        public async Task<List<JobSeekerViewModel>> GetAll()
        {
            var query = from j in _context.JobSeekers
                        join i in _context.Cvs on j.JobSeekerId equals i.JobSeekerId
                        select new { j, i };

            return await query
               .Select(p => new JobSeekerViewModel()
               {
                   JobId = p.j.JobId,
                   Address = p.j.Address,
                   Gender = p.j.Gender,
                   Name = p.j.Name,
                   National = p.j.National,
                   DesiredSalary = p.j.DesiredSalary,
                   ThumbnailCv = p.i.ImagePath,
               }).ToListAsync();
        }

        public async Task<PagedResult<JobSeekerViewModel>> GetAllPaging(GetJobSeekerPagingRequest request)
        {
            var query = from j in _context.JobSeekers
                        select new { j };

            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.j.Name.Contains(request.keyword));

            if (request.jobSeekerIds.Count > 0)
            {
                query = query.Where(x => request.jobSeekerIds.Contains(x.j.JobSeekerId));
            }
            //phân trang

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new JobSeekerViewModel()
                {
                    JobId = p.j.JobId,
                    Address = p.j.Address,
                    Gender = p.j.Gender,
                    Name = p.j.Name,
                    National = p.j.National,
                    DesiredSalary = p.j.DesiredSalary,
                   //ThumbnailCv = p.i.ImagePath,
                }).ToListAsync();

            // in ra 
            var pagedResult = new PagedResult<JobSeekerViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };

            return pagedResult;
        }

        public async Task<JobSeekerViewModel> GetbyId(int JobSeekerId)
        {
            var query = from j in _context.JobSeekers
                        join i in _context.Cvs on j.JobSeekerId equals i.JobSeekerId
                        where i.IsDefault == true
                        select new { j, i };
            
            var jobSeeker = await _context.JobSeekers.FindAsync(JobSeekerId);
            if (jobSeeker == null) { throw new FindJobException($"cannot find a jobseeker: {JobSeekerId}"); }
            var jobItem = new JobSeekerViewModel()
            {
                JobId = jobSeeker.JobId,
                Address = jobSeeker.Address,
                Gender = jobSeeker.Gender,
                Name = jobSeeker.Name,
                National = jobSeeker.National,
                DesiredSalary = jobSeeker.DesiredSalary,
                ThumbnailCv = query.Select(i => i.i.ImagePath).FirstOrDefault(),
            };
            return jobItem;
        }

        public Task<List<JobSeekerCvViewModel>> GetCvByJobSeekerId(int JobSeekerId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImages(int CvId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(JobSeekerUpdateRequest request)
        {
            var JobSeeker = await _context.JobSeekers.FindAsync(request.JobSeekerId);
            if (JobSeeker == null) throw new FindJobException($"Cannot find a JobSeeker with id: {request.JobSeekerId}");

            JobSeeker.JobId = request.JobId;
            JobSeeker.Address = request.Address;
            JobSeeker.Gender = request.Gender;
            JobSeeker.Name = request.Name;
            JobSeeker.National = request.National;
            JobSeeker.DesiredSalary = request.DesiredSalary;

            if (request.ThumbnailCv != null)
            {
                var thumbnailCv = await _context.Cvs.FirstOrDefaultAsync(i => i.IsDefault == true && i.JobSeekerId == request.JobSeekerId);
                if (thumbnailCv != null)
                {
                    thumbnailCv.FileSize = request.ThumbnailCv.Length;
                    thumbnailCv.ImagePath = await this.SaveFile(request.ThumbnailCv);
                    _context.Cvs.Update(thumbnailCv);
                }
            }
            else
            {
                JobSeeker.Cvs = new List<Cv>()
                {
                    new Cv()
                    {
                        Caption = "Cv",
                        Timespan = DateTime.Now,
                        FileSize = request.ThumbnailCv.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailCv),
                        IsDefault = true,
                        SortOrder = 1,
                    }
                };
            }
            return await _context.SaveChangesAsync();
        }

        public Task<int> UpdateImages(int CvId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
