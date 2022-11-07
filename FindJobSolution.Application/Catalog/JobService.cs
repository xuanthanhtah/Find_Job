using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace FindJobSolution.Application.Catalog
{
    public interface IJobService
    {
        Task<bool> Create(JobCreateRequest request);

        Task<bool> Update(JobUpdateRequest request);

        Task<int> Delete(int JobId);

        Task<PagedResult<JobViewModel>> GetAllPaging(GetJobPagingRequest request);

        Task<List<JobViewModel>> GetAll();

        Task<JobViewModel> GetbyId(int JobId);
    }

    public class JobService : IJobService
    {
        private readonly FindJobDBContext _context;

        public JobService(FindJobDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(JobCreateRequest request)
        {
            var jobName = await _context.Jobs.FirstOrDefaultAsync(x => x.JobName == request.JobName);
            if (jobName != null)
            {
                throw new FindJobException($"JobName already exists: {request.JobName}");
            }
            var job = new Job()
            {
                JobName = request.JobName,
            };

            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> Delete(int JobId)
        {
            var job = await _context.Jobs.FindAsync(JobId);
            if (job == null) { throw new FindJobException($"cannot find a job: {JobId}"); }

            _context.Jobs.Remove(job);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<JobViewModel>> GetAll()
        {
            var query = from j in _context.Jobs select new { j };

            return await query
               .Select(p => new JobViewModel()
               {
                   JobId = p.j.JobId,
                   JobName = p.j.JobName,
               }).ToListAsync();
        }

        public async Task<PagedResult<JobViewModel>> GetAllPaging(GetJobPagingRequest request)
        {
            //lấy job ra
            var query = from j in _context.Jobs select new { j };

            //Kiểm tra có nhập vào không
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.j.JobName.Contains(request.keyword));

            //phân trang

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new JobViewModel()
                {
                    JobId = p.j.JobId,
                    JobName = p.j.JobName,
                }).ToListAsync();

            // in ra
            var pagedResult = new PagedResult<JobViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return pagedResult;
        }

        public async Task<JobViewModel> GetbyId(int JobId)
        {
            var job = await _context.Jobs.FindAsync(JobId);
            if (job == null) { throw new FindJobException($"cannot find a job: {JobId}"); }
            var jobItem = new JobViewModel()
            {
                JobId = job.JobId,
                JobName = job.JobName,
            };
            return jobItem;
        }

        public async Task<bool> Update(JobUpdateRequest request)
        {
            var job = await _context.Jobs.FindAsync(request.Id);

            if (job == null) { throw new FindJobException($"cannot find a job: {request.Id}"); }

            job.JobName = request.JobName;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}