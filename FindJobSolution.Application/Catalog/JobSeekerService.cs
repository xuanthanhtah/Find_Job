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
