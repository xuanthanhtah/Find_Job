using FindJobSolution.Application.Catalog.Jobs.Dtos;
using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Catalog.Jobs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Application.Catalog.JobInformations
{
    public interface IJobInformationService
    {
        Task<int> Create(JobInformationCreateRequest request);
        Task<int> Update(JobInformationUpdateRequest request);
        Task<int> Detele(int JobInformationId);
        Task<List<JobInformationViewModel>> GetAll();
        Task<JobInformationViewModel> GetbyId(int JobInformationId);
    }
    public class JobInformationService : IJobInformationService
    {
        private readonly FindJobDBContext _context;
        public JobInformationService(FindJobDBContext context)
        {
            _context = context;
        }

        public async Task<int> Create(JobInformationCreateRequest request)
        {
            var newJobInformation = new JobInformation()
            {
                JobTitle = request.JobTitle,
                Description = request.Description,
                Benefits = request.Benefits,
                Requirements = request.Requirements,
                JobId = request.JobId,
                RecruiterId = request.RecruiterId,
                WorkingLocation = request.WorkingLocation,
                Salary = request.Salary,
                MinSalary = request.MinSalary,
                MaxSalary = request.MaxSalary,
                Status = Data.Enums.Status.Active,
                ViewCount = 0,
                JobLevel = request.JobLevel,
                JobType = request.JobType,
                JobInformationTimeStart = request.JobInformationTimeStart,
                JobInformationTimeEnd = request.JobInformationTimeEnd
            };
            _context.JobInformations.Add(newJobInformation);
            await _context.SaveChangesAsync();
            return newJobInformation.JobInformationId;
        }


        public async Task<int> Detele(int JobInformationId)
        {
            var jobInformation = await _context.JobInformations.FindAsync(JobInformationId);
            if (jobInformation == null) return 0;
            jobInformation.Status = Data.Enums.Status.InActive;

            return await _context.SaveChangesAsync();
        }

        public async Task<List<JobInformationViewModel>> GetAll()
        {
            var query = from j in _context.JobInformations select new { j };

            return await query
               .Select(p => new JobInformationViewModel()
               {
                   JobInformationId = p.j.JobInformationId,
                   JobLevel = p.j.JobLevel,
                   JobTitle = p.j.JobTitle,
                   JobType = p.j.JobType,
                   Description = p.j.Description,
                   Requirements = p.j.Requirements,
                   Benefits = p.j.Benefits,
                   MaxSalary = p.j.MaxSalary,
                   MinSalary = p.j.MinSalary,
                   Salary = p.j.Salary,
                   WorkingLocation = p.j.WorkingLocation,
                   ViewCount = p.j.ViewCount,
                   Status = p.j.Status,
                   JobId = p.j.JobId,
                   RecruiterId = p.j.RecruiterId,
                   JobInformationTimeEnd = p.j.JobInformationTimeEnd,
                   JobInformationTimeStart = p.j.JobInformationTimeStart
               }).ToListAsync();
        }

        public async Task<JobInformationViewModel> GetbyId(int JobInformationId)
        {
            var jobInformation = await _context.JobInformations.FindAsync(JobInformationId);
            if (jobInformation == null) { throw new FindJobException($"cannot find a jobInformation: {JobInformationId}"); }

            var JobInformationItem = new JobInformationViewModel()
            {
                JobTitle = jobInformation.JobTitle,
                Description = jobInformation.Description,
                Benefits = jobInformation.Benefits,
                Requirements = jobInformation.Requirements,
                JobId = jobInformation.JobId,
                RecruiterId = jobInformation.RecruiterId,
                WorkingLocation = jobInformation.WorkingLocation,
                Salary = jobInformation.Salary,
                MinSalary = jobInformation.MinSalary,
                MaxSalary = jobInformation.MaxSalary,
                Status = jobInformation.Status,
                ViewCount = jobInformation.ViewCount,
                JobLevel = jobInformation.JobLevel,
                JobType = jobInformation.JobType,
                JobInformationTimeEnd = jobInformation.JobInformationTimeEnd,
                JobInformationTimeStart = jobInformation.JobInformationTimeStart,
                JobInformationId = jobInformation.JobInformationId,
            };
            return JobInformationItem;
        }

        public async Task<int> Update(JobInformationUpdateRequest request)
        {
            var jobInformation = await _context.JobInformations.FindAsync(request.JobInformationId);

            if (jobInformation == null) { throw new FindJobException($"cannot find a job: {request.JobInformationId}"); }

            jobInformation.JobInformationTimeEnd = request.JobInformationTimeEnd;
            jobInformation.JobInformationTimeStart = request.JobInformationTimeStart;
            jobInformation.Benefits = request.Benefits;
            jobInformation.Description = request.Description;
            jobInformation.WorkingLocation = request.WorkingLocation;
            jobInformation.Status = request.Status;
            jobInformation.MaxSalary = request.MaxSalary;
            jobInformation.MinSalary = request.MinSalary;
            jobInformation.Salary = request.Salary;
            jobInformation.Requirements = request.Requirements;
            jobInformation.JobId = request.JobId;
            jobInformation.JobType = request.JobType;
            jobInformation.JobInformationId = request.JobInformationId;
            jobInformation.JobLevel = request.JobLevel;
            jobInformation.RecruiterId = request.RecruiterId;
            jobInformation.JobTitle = request.JobTitle;
            return await _context.SaveChangesAsync();
        }
    }
}
