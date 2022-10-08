using FindJobSolution.Application.Catalog.Jobs.Dtos;
using FindJobSolution.Application.Dtos;
using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Application.Catalog.Jobs;

public interface IJobService
{
    Task<int> Create(JobCreateRequest request);
    Task<int> Update(JobUpdateRequest request);
    Task<int> Detele(int JobId);
    Task<List<JobViewModel>> GetAll(); 
    Task<PagedResult<JobViewModel>> GetAllPaging(GetJobPagingRequest request);
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
        if(jobName != null)
        {
            throw new FindJobException($"JobName already exists: {request.JobName}");
        }
        var job = new Job()
        {
            JobName = request.JobName,
        };

        _context.Jobs.Add(job);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Detele(int JobId)
    {
        var job = await _context.Jobs.FindAsync(JobId);
        if (job == null) { throw new FindJobException($"cannot find a job: {JobId}"); }

        _context.Jobs.Remove(job);
        return await _context.SaveChangesAsync();
    }

    public Task<List<JobViewModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResult<JobViewModel>> GetAllPaging(GetJobPagingRequest request)
    {
        //lấy job ra
        var query = from j in _context.Jobs select j;
        
        //Kiểm tra có nhập vào không
        if(!string.IsNullOrEmpty(request.keyword))
            query = query.Where(x => x.JobName.Contains(request.keyword));

        
        if(request.jobIds.Count > 0)
        {
            query = query.Where(x => request.jobIds.Contains(x.JobId));
        }

        //phân trang

        int totalRow = await query.CountAsync();

        var data = await query.Skip((request.PageIndex - 1)* request.PageSize)
            .Take(request.PageSize)
            .Select( p => new JobViewModel()
            {
                JobName = p.JobName,
            }).ToListAsync();

        // in ra 
        var pagedResult = new PagedResult<JobViewModel>()
        {
            TotalRecord = totalRow,
            Items = data
        };

        return pagedResult;
    }

    public Task<int> Update(JobUpdateRequest request)
    {
        throw new NotImplementedException();
    }
}


