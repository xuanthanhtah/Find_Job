using FindJobSolution.Application.Catalog;
using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Catalog.JobSeekerOldCompany;
using FindJobSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Application.Catalog
{
    public interface IJobSeekerOldCompanyService
    {
        Task<int> Create(JobSeekerOldCompanyCreateRequest request);

        Task<int> Update(JobSeekerOldCompanyUpdateRequest request);

        Task<int> Detele(int JobSeekerOldCompanyId);

        Task<List<JobSeekerOldCompanyViewmodel>> GetAll();

        Task<JobSeekerOldCompanyViewmodel> GetbyId(int JobSeekerOldCompanyId);

        Task<PagedResult<JobSeekerOldCompanyViewmodel>> GetAllPaging(JobSeekerOldCompanyViewmodelPagingRequest request);
    }

}
public class JobSeekerOldCompanyService : IJobSeekerOldCompanyService
{
    private readonly FindJobDBContext _context;

    public JobSeekerOldCompanyService(FindJobDBContext context)
    {
        _context = context;
    }
    public async Task<int> Create(JobSeekerOldCompanyCreateRequest request)
    {
        var JobSeekerOldCompany = new JobSeekerOldCompany()
        {
            CompanyName = request.CompanyName,
            JobTitle = request.JobTitle,
            WorkExperience = request.WorkExperience,
            WorkingTime = request.WorkingTime,
            JobSeekerId = request.JobSeekerId
        };
        _context.JobSeekerOldCompanies.Add(JobSeekerOldCompany);
        await _context.SaveChangesAsync();
        return JobSeekerOldCompany.JobSeekerOldCompanyId;
    }

    public async Task<int> Detele(int JobSeekerOldCompanyId)
    {
        var JobSeekerOldCompany = await _context.JobSeekerOldCompanies.FindAsync(JobSeekerOldCompanyId);
        if (JobSeekerOldCompany == null) { throw new FindJobException($"cannot find a job: {JobSeekerOldCompanyId}"); }

        _context.JobSeekerOldCompanies.Remove(JobSeekerOldCompany);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<JobSeekerOldCompanyViewmodel>> GetAll()
    {
        var query = from j in _context.JobSeekerOldCompanies select new { j };

        return await query
           .Select(p => new JobSeekerOldCompanyViewmodel()
           {
                CompanyName = p.j.CompanyName,
                JobSeekerId=p.j.JobSeekerId,
                WorkExperience = p.j.WorkExperience,
                WorkingTime = p.j.WorkingTime,
                JobTitle = p.j.JobTitle,
                JobSeekerOldCompanyId = p.j.JobSeekerOldCompanyId,
           }).ToListAsync();

    }

    
    public async Task<PagedResult<JobSeekerOldCompanyViewmodel>> GetAllPaging(JobSeekerOldCompanyViewmodelPagingRequest request)
    {
        var query = from j in _context.JobSeekerOldCompanies select new {j};

        //Kiểm tra có nhập vào không
        if (!string.IsNullOrEmpty(request.keyword))
            query = query.Where(x => x.j.JobTitle.Contains(request.keyword));


        //phân trang

        int totalRow = await query.CountAsync();

        var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new JobSeekerOldCompanyViewmodel()
            {
                CompanyName=p.j.CompanyName,
                JobTitle=p.j.JobTitle, 
                WorkExperience=p.j.WorkExperience,
                JobSeekerOldCompanyId=p.j.JobSeekerOldCompanyId,
                WorkingTime=p.j.WorkingTime,
                JobSeekerId = p.j.JobSeekerId
            }).ToListAsync();

        // in ra 
        var pagedResult = new PagedResult<JobSeekerOldCompanyViewmodel>()
        {
            TotalRecord = totalRow,
            Items = data
        };

        return pagedResult;
    }

    public async Task<JobSeekerOldCompanyViewmodel> GetbyId(int JobSeekerOldCompanyId)
    {
        var job = await _context.JobSeekerOldCompanies.FindAsync(JobSeekerOldCompanyId);
        if (job == null) { throw new FindJobException($"cannot find a job: {JobSeekerOldCompanyId}"); }
        var JobSeekerOldCompanyItem = new JobSeekerOldCompanyViewmodel()
        {
           JobSeekerOldCompanyId = job.JobSeekerOldCompanyId,
            JobSeekerId=job.JobSeekerId,
            JobTitle=job.JobTitle,
            WorkingTime=job.WorkingTime,
            WorkExperience = job.WorkExperience,
            CompanyName = job.CompanyName,
        };
        return JobSeekerOldCompanyItem;
    }

    public async Task<int> Update(JobSeekerOldCompanyUpdateRequest request)
    {
        var JobSeekerOldCompanyItem = await _context.JobSeekerOldCompanies.FindAsync(request.JobSeekerOldCompanyId);

        if (JobSeekerOldCompanyItem == null) { throw new FindJobException($"cannot find a job: {request.JobSeekerOldCompanyId}"); }

        JobSeekerOldCompanyItem.WorkExperience = request.WorkExperience;
        JobSeekerOldCompanyItem.CompanyName = request.CompanyName;
        JobSeekerOldCompanyItem.JobTitle = request.JobTitle;
        JobSeekerOldCompanyItem.WorkingTime = request.WorkingTime;
        return await _context.SaveChangesAsync();
    }
}


