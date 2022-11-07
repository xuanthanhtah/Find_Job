﻿using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace FindJobSolution.Application.Catalog
{
    public interface IJobInformationService
    {
        Task<bool> Create(JobInformationCreateRequest request);

        Task<int> Update(JobInformationUpdateRequest request);

        Task<int> Delete(int JobInformationId);

        Task<List<JobInformationViewModel>> GetAll();

        Task<JobInformationViewModel> GetbyId(int JobInformationId);

        Task<PagedResult<JobInformationViewModel>> GetbyRecuiterId(int Id, GetJobInformationPagingRequest request);

        Task AddViewcount(int JobInformationId);

        Task<PagedResult<JobInformationViewModel>> GetAllPaging(GetJobInformationPagingRequest request);
    }

    public class JobInformationService : IJobInformationService
    {
        private readonly FindJobDBContext _context;

        public JobInformationService(FindJobDBContext context)
        {
            _context = context;
        }

        public async Task AddViewcount(int JobInformationId)
        {
            var job = await _context.JobInformations.FindAsync(JobInformationId);
            job.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Create(JobInformationCreateRequest request)
        {
            var newJobInformation = new JobInformation()
            {
                JobTitle = request.JobTitle,
                Description = request.Description,
                JobId = request.JobId,
                RecruiterId = request.RecruiterId,
                WorkingLocation = request.WorkingLocation,
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
            return true;
        }

        public async Task<int> Delete(int JobInformationId)
        {
            var jobInformation = await _context.JobInformations.FindAsync(JobInformationId);
            if (jobInformation == null) return 0;
            jobInformation.Status = Data.Enums.Status.NoActive;

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
                   MaxSalary = p.j.MaxSalary,
                   MinSalary = p.j.MinSalary,
                   WorkingLocation = p.j.WorkingLocation,
                   ViewCount = p.j.ViewCount,
                   Status = p.j.Status,
                   JobId = p.j.JobId,
                   RecruiterId = p.j.RecruiterId,
                   JobInformationTimeEnd = p.j.JobInformationTimeEnd,
                   JobInformationTimeStart = p.j.JobInformationTimeStart
               }).Where(n => n.Status == Data.Enums.Status.Active).ToListAsync();
        }

        public async Task<PagedResult<JobInformationViewModel>> GetAllPaging(GetJobInformationPagingRequest request)
        {
            var query = from j in _context.JobInformations
                        select new
                        {
                            JobInformationId = j.JobInformationId,
                            JobLevel = j.JobLevel,
                            JobTitle = j.JobTitle,
                            JobType = j.JobType,
                            Description = j.Description,
                            MaxSalary = j.MaxSalary,
                            MinSalary = j.MinSalary,
                            WorkingLocation = j.WorkingLocation,
                            ViewCount = j.ViewCount,
                            Status = j.Status,
                            JobId = j.JobId,
                            RecruiterId = j.RecruiterId,
                            JobInformationTimeEnd = j.JobInformationTimeEnd,
                            JobInformationTimeStart = j.JobInformationTimeStart
                        };

            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => (x.JobLevel.Contains(request.keyword)) ||
                (x.JobTitle.Contains(request.keyword)) || (x.JobType.Contains(request.keyword)));
            }

            //phân trang

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new JobInformationViewModel()
                {
                    JobInformationId = p.JobInformationId,
                    JobLevel = p.JobLevel,
                    JobTitle = p.JobTitle,
                    JobType = p.JobType,
                    Description = p.Description,
                    MaxSalary = p.MaxSalary,
                    MinSalary = p.MinSalary,
                    WorkingLocation = p.WorkingLocation,
                    ViewCount = p.ViewCount,
                    Status = p.Status,
                    JobId = p.JobId,
                    RecruiterId = p.RecruiterId,
                    JobInformationTimeEnd = p.JobInformationTimeEnd,
                    JobInformationTimeStart = p.JobInformationTimeStart
                }).ToListAsync();

            // in ra
            var pagedResult = new PagedResult<JobInformationViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };

            return pagedResult;
        }

        public async Task<JobInformationViewModel> GetbyId(int JobInformationId)
        {
            var jobInformation = await _context.JobInformations.FindAsync(JobInformationId);
            if (jobInformation == null) { throw new FindJobException($"cannot find a jobInformation: {JobInformationId}"); }

            var JobInformationItem = new JobInformationViewModel()
            {
                JobTitle = jobInformation.JobTitle,
                Description = jobInformation.Description,
                JobId = jobInformation.JobId,
                RecruiterId = jobInformation.RecruiterId,
                WorkingLocation = jobInformation.WorkingLocation,
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

        public async Task<PagedResult<JobInformationViewModel>> GetbyRecuiterId(int Id, GetJobInformationPagingRequest request)
        {
            var recuiter = await _context.JobInformations.FirstOrDefaultAsync(x => x.RecruiterId == Id);
            if (recuiter == null) { throw new FindJobException($"cannot find a recuiter: {Id}"); }
            var query = from j in _context.JobInformations
                        select new
                        {
                            JobInformationId = j.JobInformationId,
                            JobLevel = j.JobLevel,
                            JobTitle = j.JobTitle,
                            JobType = j.JobType,
                            Description = j.Description,
                            MaxSalary = j.MaxSalary,
                            MinSalary = j.MinSalary,
                            WorkingLocation = j.WorkingLocation,
                            ViewCount = j.ViewCount,
                            Status = j.Status,
                            JobId = j.JobId,
                            RecruiterId = j.RecruiterId,
                            JobInformationTimeEnd = j.JobInformationTimeEnd,
                            JobInformationTimeStart = j.JobInformationTimeStart
                        };

            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => (x.JobLevel.Contains(request.keyword)) ||
                (x.JobTitle.Contains(request.keyword)) || (x.JobType.Contains(request.keyword)));
            }

            //phân trang

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new JobInformationViewModel()
                {
                    JobInformationId = p.JobInformationId,
                    JobLevel = p.JobLevel,
                    JobTitle = p.JobTitle,
                    JobType = p.JobType,
                    Description = p.Description,
                    MaxSalary = p.MaxSalary,
                    MinSalary = p.MinSalary,
                    WorkingLocation = p.WorkingLocation,
                    ViewCount = p.ViewCount,
                    Status = p.Status,
                    JobId = p.JobId,
                    RecruiterId = p.RecruiterId,
                    JobInformationTimeEnd = p.JobInformationTimeEnd,
                    JobInformationTimeStart = p.JobInformationTimeStart
                }).ToListAsync();

            // in ra
            var pagedResult = new PagedResult<JobInformationViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };

            return pagedResult;
        }

        public async Task<int> Update(JobInformationUpdateRequest request)
        {
            var jobInformation = await _context.JobInformations.FindAsync(request.JobInformationId);

            if (jobInformation == null) { throw new FindJobException($"cannot find a job: {request.JobInformationId}"); }

            jobInformation.JobInformationTimeEnd = request.JobInformationTimeEnd;
            jobInformation.JobInformationTimeStart = request.JobInformationTimeStart;
            jobInformation.Description = request.Description;
            jobInformation.WorkingLocation = request.WorkingLocation;
            jobInformation.MaxSalary = request.MaxSalary;
            jobInformation.MinSalary = request.MinSalary;
            jobInformation.JobId = request.JobId;
            jobInformation.JobType = request.JobType;
            jobInformation.JobInformationId = request.JobInformationId;
            jobInformation.JobLevel = request.JobLevel;
            jobInformation.JobTitle = request.JobTitle;
            return await _context.SaveChangesAsync();
        }
    }
}