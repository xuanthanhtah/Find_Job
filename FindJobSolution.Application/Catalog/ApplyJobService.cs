﻿using FindJobSolution.Data.EF;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.ApplyJob;
using FindJobSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FindJobSolution.Application.Catalog
{
    public interface IApplyJobService
    {
        Task<int> Create(ApplyJobCreateRequest request);
        Task<int> Delete(int JobSeekerId, int JobInfomationId);
        //Task<PagedResult<ApplyJobViewModel>> GetAllPaging(GetApplyJobPagingRequest request);
        Task<List<ApplyJobViewModel>> GetAll();
        Task<ApplyJobViewModel> GetbyId(int JobSeekerId, int JobInfomationId);
    }
    public class ApplyJobService : IApplyJobService
    {

        private readonly FindJobDBContext _context;
        public ApplyJobService(FindJobDBContext context)
        {
            _context = context;
        }

        public async Task<int> Create(ApplyJobCreateRequest request)
        {
            var ApplyJob = new ApplyJob()
            {
                JobInformationId = request.JobInformationId,
                JobSeekerId = request.JobSeekerId,
                Status = request.Status,
                TimeApply = request.TimeApply,
            };

            _context.ApplyJobs.Add(ApplyJob);
            await _context.SaveChangesAsync();
            return ApplyJob.JobSeekerId;
        }

        public async Task<int> Delete(int JobSeekerId, int JobInfomationId)
        {
            var ApplyJob = await _context.ApplyJobs.FindAsync(JobSeekerId, JobInfomationId);
            if (ApplyJob == null) { throw new FindJobException($"cannot find a ApplyJob: {JobSeekerId}, {JobInfomationId}"); }

            _context.ApplyJobs.Remove(ApplyJob);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ApplyJobViewModel>> GetAll()
        {
            var query = from j in _context.ApplyJobs select new { j };

            return await query
               .Select(p => new ApplyJobViewModel()
               {
                   JobInformationId = p.j.JobInformationId,
                   JobSeekerId = p.j.JobSeekerId,
                   Status = p.j.Status,
                   TimeApply = p.j.TimeApply,
               }).ToListAsync();

        }

        //public async Task<PagedResult<ApplyJobViewModel>> GetAllPaging(GetApplyJobPagingRequest request)
        //{
        //    //lấy ApplyJob ra
        //    var query = from j in _context.ApplyJobs select new { j };

        //    //Kiểm tra có nhập vào không
        //    if (!string.IsNullOrEmpty(request.keyword))
        //        query = query.Where(x => x.j.Name.Contains(request.keyword));

        //    if (request.JobInformationId.Count > 0 && request.JobSeekerId.Count > 0)
        //    {
        //        query = query.Where(x => request.JobInformationId.Contains(x.j.JobInformationId) && request.JobSeekerId.Contains(x.j.JobSeekerId));
        //    }

        //    //phân trang

        //    int totalRow = await query.CountAsync();

        //    var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
        //        .Take(request.PageSize)
        //        .Select(p => new ApplyJobViewModel()
        //        {
        //            JobInformationId = p.j.JobInformationId,
        //            JobSeekerId = p.j.JobSeekerId,
        //            Status = p.j.Status,
        //            TimeSave = p.j.TimeSave,
        //        }).ToListAsync();

        //    // in ra 
        //    var pagedResult = new PagedResult<ApplyJobViewModel>()
        //    {
        //        TotalRecord = totalRow,
        //        Items = data
        //    };

        //    return pagedResult;
        //}

        public async Task<ApplyJobViewModel> GetbyId(int JobSeekerId, int JobInfomationId)
        {
            var ApplyJob = await _context.ApplyJobs.FindAsync(JobSeekerId, JobInfomationId);
            if (ApplyJob == null) { throw new FindJobException($"cannot find a ApplyJob: {JobSeekerId}, {JobInfomationId}"); }
            var ApplyJobItem = new ApplyJobViewModel()
            {
                JobInformationId = ApplyJob.JobInformationId,
                JobSeekerId = ApplyJob.JobSeekerId,
                Status = ApplyJob.Status,
                TimeApply = ApplyJob.TimeApply,
            };
            return ApplyJobItem;
        }

        //public async Task<int> Update(ApplyJobUpdateRequest request)
        //{
        //    var ApplyJob = await _context.ApplyJobs.FindAsync(request.ApplyJobId);

        //    if (ApplyJob == null) { throw new FindJobException($"cannot find a ApplyJob: {request.ApplyJobId}"); }

        //    ApplyJob.Name = request.Name;
        //    ApplyJob.Experience = request.Experience;

        //    return await _context.SaveChangesAsync();
        //}
    }
}