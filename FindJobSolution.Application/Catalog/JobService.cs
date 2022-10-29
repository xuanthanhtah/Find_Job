using FindJobSolution.Application.Catalog.Jobs.Dtos;
using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace FindJobSolution.Application.Catalog;

public interface IJobService
{
    Task<int> Create(JobCreateRequest request);
    Task<int> Update(JobUpdateRequest request);
    Task<int> Detele(int JobId);
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

    public async Task<int> Create(JobCreateRequest request)
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
        return job.JobId;
    }

    public async Task<int> Detele(int JobId)
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


        if (request.jobIds.Count > 0)
        {
            query = query.Where(x => request.jobIds.Contains(x.j.JobId));
        }

        //phân trang

        int totalRow = await query.CountAsync();

        var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new JobViewModel()
            {
                JobName = p.j.JobName,
            }).ToListAsync();

        // in ra 
        var pagedResult = new PagedResult<JobViewModel>()
        {
            TotalRecord = totalRow,
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
            JobName = job.JobName,
        };
        return jobItem;
    }

    public async Task<int> Update(JobUpdateRequest request)
    {
        var job = await _context.Jobs.FindAsync(request.JobId);

        if (job == null) { throw new FindJobException($"cannot find a job: {request.JobId}"); }

        job.JobName = request.JobName;

        return await _context.SaveChangesAsync();
    }
}


