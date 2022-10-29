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
        Task<int> Create(JobSeekerCreateRequest request);
        Task<int> Update(JobSeekerUpdateRequest request);
        Task<int> Detele(int JobSeekerId);
        Task<PagedResult<JobSeekerViewModel>> GetAllPaging(GetJobSeekerPagingRequest request);
        Task<List<JobSeekerViewModel>> GetAll();
        Task<JobSeekerViewModel> GetbyId(int JobSeekerId);
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

        public async Task<int> Create(JobSeekerCreateRequest request)
        {
            var userId = _context.JobSeekers.FirstOrDefaultAsync(x => x.UserId == request.UserId);
            if (userId == null)
            {
                throw new FindJobException($"cannot find user with id: {request.UserId}");
            }

            var jobSeeker = new JobSeeker()
            {
                JobId = request.JobId,
                Address = request.Address,
                Gender = request.Gender,
                National = request.National,
                DesiredSalary = request.DesiredSalary,
            };

            //save cv
            if(request.ThumbnailCv != null)
            {
                jobSeeker.Cvs = new List<Cv>()
                {
                    new Cv()
                    {
                        Caption = "Thumbnail cv",
                        Timespan = DateTime.Now,
                        FileSize = request.ThumbnailCv.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailCv),
                        IsDefault = true,
                        SortOrder = 1,
                    }
                };
            }
            
            _context.JobSeekers.Add(jobSeeker);
            await _context.SaveChangesAsync();
            return jobSeeker.JobSeekerId;
        }

        public Task<int> Detele(int JobSeekerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<JobSeekerViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<JobSeekerViewModel>> GetAllPaging(GetJobSeekerPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<JobSeekerViewModel> GetbyId(int JobSeekerId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(JobSeekerUpdateRequest request)
        {
            throw new NotImplementedException();
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return  fileName;
        }
    }
}
