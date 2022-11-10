using FindJobSolution.Application.Common;
using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.Cvs;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.Catalog.Recruiters;
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
        Task<JobSeekerViewModel> GetByUserId(Guid id);

        Task<int> AddCv(int JobSeekerId, CvCreateRequest request);

        Task<int> RemoveCv(int CvId);

        Task<int> UpdateCv(int CvId, CvUpdateRequest request);

        Task<List<CvViewModel>> GetCvByJobSeekerId(int JobSeekerId);

        Task<CvViewModel> GetCvById(int Cvid);
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

        public async Task<int> AddCv(int JobSeekerId, CvCreateRequest request)
        {
            var cv = new Cv()
            {
                Caption = request.Caption,
                Timespan = DateTime.Now,
                IsDefault = request.IsDefault,
                JobSeekerId = JobSeekerId,
                SortOrder = request.SortOrder,
            };

            if (request.FileCv != null)
            {
                cv.FileSize = request.FileCv.Length;
                cv.FilePath = await this.SaveFile(request.FileCv);
            }
            _context.Cvs.Add(cv);

            await _context.SaveChangesAsync();
            return cv.CvId;
        }

        public async Task<int> Delete(int JobSeekerId)
        {
            //nếu có jobseeker thì xóa
            var jobSeeker = await _context.JobSeekers.FindAsync(JobSeekerId);
            if (jobSeeker == null) { throw new FindJobException($"cannot find a jobSeeker: {JobSeekerId}"); }

            //xóa ảnh
            var thumbnailCv = _context.Cvs.Where(i => i.JobSeekerId == JobSeekerId);
            foreach (var image in thumbnailCv)
            {
                await _storageService.DeleteFileAsync(image.FilePath);
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
                   jobseekerId = p.j.JobSeekerId,
                   JobId = p.j.JobId,
                   Address = p.j.Address,
                   Gender = p.j.Gender,
                   Dob = p.j.Dob,
                   Name = p.j.Name,
                   National = p.j.National,
                   DesiredSalary = p.j.DesiredSalary,
                   ThumbnailCv = p.i.FilePath,
               }).ToListAsync();
        }

        public async Task<PagedResult<JobSeekerViewModel>> GetAllPaging(GetJobSeekerPagingRequest request)
        {
            var query = from j in _context.JobSeekers
                        join i in _context.Cvs on j.JobSeekerId equals i.JobSeekerId
                        select new
                        {
                            JobSeekerId = j.JobSeekerId,
                            JobId = j.JobId,
                            Address = j.Address,
                            Gender = j.Gender,
                            Dob = j.Dob,
                            Name = j.Name,
                            National = j.National,
                            DesiredSalary = j.DesiredSalary,
                            ThumbnailCv = i.FilePath,
                        };

            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.Name.Contains(request.keyword));

            //phân trang

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new JobSeekerViewModel()
                {
                    jobseekerId = p.JobSeekerId,
                    JobId = p.JobId,
                    Address = p.Address,
                    Gender = p.Gender,
                    Dob = p.Dob,
                    Name = p.Name,
                    National = p.National,
                    DesiredSalary = p.DesiredSalary,
                    ThumbnailCv = p.ThumbnailCv,
                }).ToListAsync();

            // in ra
            var pagedResult = new PagedResult<JobSeekerViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
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

            var user = _context.Users.FirstOrDefault(p => p.Id == jobSeeker.UserId);

            if (jobSeeker == null) { throw new FindJobException($"cannot find a jobseeker: {jobSeeker}"); }
            var jobItem = new JobSeekerViewModel()
            {        
                jobseekerId = jobSeeker.JobSeekerId,
                JobId = jobSeeker.JobId,
                Address = jobSeeker.Address,
                Gender = jobSeeker.Gender,
                Dob = jobSeeker.Dob,
                Name = jobSeeker.Name,
                National = jobSeeker.National,
                DesiredSalary = jobSeeker.DesiredSalary,
                ThumbnailCv = query.Select(i => i.i.FilePath).FirstOrDefault(),

                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return jobItem;
        }

        public async Task<JobSeekerViewModel> GetByUserId(Guid id)
        {
            var query = from j in _context.JobSeekers
                        join i in _context.Cvs on j.JobSeekerId equals i.JobSeekerId
                        where i.IsDefault == true
                        select new { j, i };

            var jobSeeker = await _context.JobSeekers.FirstOrDefaultAsync(x => x.UserId == id);

            var user = _context.Users.FirstOrDefault(p => p.Id == jobSeeker.UserId);

            if (jobSeeker == null) { throw new FindJobException($"cannot find a jobseeker: {jobSeeker}"); }
            var jobItem = new JobSeekerViewModel()
            {
                id = id,
                jobseekerId = jobSeeker.JobSeekerId,
                JobId = jobSeeker.JobId,
                Address = jobSeeker.Address,
                Gender = jobSeeker.Gender,
                Dob = jobSeeker.Dob,
                Name = jobSeeker.Name,
                National = jobSeeker.National,
                DesiredSalary = jobSeeker.DesiredSalary,
                ThumbnailCv = query.Select(i => i.i.FilePath).FirstOrDefault(),

                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return jobItem;
        }

        public async Task<CvViewModel> GetCvById(int Cvid)
        {
            var cv = await _context.Cvs.FindAsync(Cvid);
            if (cv == null) { throw new FindJobException($"cannot find a cv: {Cvid}"); }

            var viewmodel = new CvViewModel()
            {
                JobSeekerId = cv.JobSeekerId,
                CvId = cv.CvId,
                Caption = cv.Caption,
                FilePath = cv.FilePath,
                FileSize = cv.FileSize,
                IsDefault = cv.IsDefault,
                SortOrder = cv.SortOrder,
                Timespan = cv.Timespan,
            };
            return viewmodel;
        }

        public async Task<List<CvViewModel>> GetCvByJobSeekerId(int JobSeekerId)
        {
            return await _context.Cvs.Where(x => x.JobSeekerId == JobSeekerId)
                .Select(i => new CvViewModel()
                {
                    Caption = i.Caption,
                    FilePath = i.FilePath,
                    FileSize = i.FileSize,
                    IsDefault = i.IsDefault,
                    SortOrder = i.SortOrder,
                    Timespan = i.Timespan,
                    CvId = i.CvId,
                    JobSeekerId = i.JobSeekerId,
                }).ToListAsync();
        }

        public async Task<int> RemoveCv(int CvId)
        {
            var cv = await _context.Cvs.FindAsync(CvId);
            if (cv == null) { throw new FindJobException($"cannot find a cv: {CvId}"); }
            _context.Cvs.Remove(cv);
            return await _context.SaveChangesAsync();
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
            JobSeeker.Dob = request.Dob;

            if (request.ThumbnailCv != null)
            {
                var thumbnailCv = await _context.Cvs.FirstOrDefaultAsync(i => i.IsDefault == true && i.JobSeekerId == request.JobSeekerId);
                if (thumbnailCv != null)
                {
                    thumbnailCv.Caption = request.nameCv;
                    thumbnailCv.FileSize = request.ThumbnailCv.Length;
                    thumbnailCv.FilePath = await this.SaveFile(request.ThumbnailCv);
                    _context.Cvs.Update(thumbnailCv);
                }
                else
                {
                    JobSeeker.Cvs = new List<Cv>()
                    {
                        new Cv()
                        {
                            Caption = request.nameCv,
                            Timespan = DateTime.Now,
                            FileSize = request.ThumbnailCv.Length,
                            FilePath = await this.SaveFile(request.ThumbnailCv),
                            IsDefault = true,
                            SortOrder = 1,
                        }
                    };
                    _context.Cvs.AddRange(JobSeeker.Cvs);
                }
            }
            if (request.ThumbnailAvatar != null)
            {
                var thumbnailCv = await _context.Avatars.FirstOrDefaultAsync(i => i.IsDefault == true && i.JobSeekerId == request.JobSeekerId);
                if (thumbnailCv != null)
                {
                    thumbnailCv.Caption = request.nameAvatar;
                    thumbnailCv.FileSize = request.ThumbnailAvatar.Length;
                    thumbnailCv.FilePath = await this.SaveFile(request.ThumbnailAvatar);
                    _context.Avatars.Update(thumbnailCv);
                }
                else
                {
                    JobSeeker.Avatar = new Avatar()
                    {
                        Caption = request.nameAvatar,
                        Timespan = DateTime.Now,
                        FileSize = request.ThumbnailAvatar.Length,
                        FilePath = await this.SaveFile(request.ThumbnailAvatar),
                        IsDefault = true,
                        SortOrder = 1,
                    };
                    _context.Avatars.AddRange(JobSeeker.Avatar);
                }
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCv(int CvId, CvUpdateRequest request)
        {
            var cv = await _context.Cvs.FindAsync(CvId);
            if (cv == null)
            {
                throw new FindJobException($"Cannot find a cv with id: {CvId}");
            }

            if (request.FileCv != null)
            {
                cv.Caption = request.Caption;
                cv.IsDefault = request.IsDefault;
                cv.SortOrder = request.SortOrder;
                cv.FileSize = request.FileCv.Length;
                cv.FilePath = await this.SaveFile(request.FileCv);
            }
            _context.Cvs.Update(cv);

            return await _context.SaveChangesAsync();
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