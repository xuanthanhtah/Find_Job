using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.SaveJob;
using FindJobSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Application.Catalog
{
    public interface ISaveJobService
    {
        Task<bool> Create(int id, SaveJobCreateRequestNew request);

        Task<int> Delete(int JobSeekerId, int JobInfomationId);

        //Task<PagedResult<SaveJobViewModel>> GetAllPaging(GetSaveJobPagingRequest request);
        Task<List<SaveJobViewModel>> GetAll();

        Task<SaveJobViewModel> GetbyId(int JobSeekerId, int JobInfomationId);
    }

    public class SaveJobService : ISaveJobService
    {
        private readonly FindJobDBContext _context;

        public SaveJobService(FindJobDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(int id, SaveJobCreateRequestNew request)
        {
            var getid = await _context.Users.FirstOrDefaultAsync(p => p.UserName == request.UserIdentityName);
            if (getid == null) return false;
            var getjsid = await _context.JobSeekers.FirstOrDefaultAsync(p => p.UserId == getid.Id);
            if (getjsid == null) return false;
            var jobInfor = await _context.JobInformations.FindAsync(id);
            if (jobInfor == null) return false;

            var SaveJob = new SaveJob()
            {
                JobInformationId = id,
                JobSeekerId = getjsid.JobSeekerId,
                Status = Data.Enums.Status.Inprogress,
                TimeSave = request.TimeSave,
            };

            var result = _context.SaveJobs.Add(SaveJob);
            if (result != null)
            {
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<int> Delete(int JobSeekerId, int JobInfomationId)
        {
            var SaveJob = await _context.SaveJobs.FindAsync(JobSeekerId, JobInfomationId);
            if (SaveJob == null) { throw new FindJobException($"cannot find a SaveJob: {JobSeekerId}, {JobInfomationId}"); }

            _context.SaveJobs.Remove(SaveJob);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<SaveJobViewModel>> GetAll()
        {
            var query = from j in _context.SaveJobs select new { j };

            return await query
               .Select(p => new SaveJobViewModel()
               {
                   JobInformationId = p.j.JobInformationId,
                   JobSeekerId = p.j.JobSeekerId,
                   Status = p.j.Status,
                   TimeSave = p.j.TimeSave,
               }).ToListAsync();
        }

        public async Task<SaveJobViewModel> GetbyId(int JobSeekerId, int JobInfomationId)
        {
            var SaveJob = await _context.SaveJobs.FindAsync(JobSeekerId, JobInfomationId);
            if (SaveJob == null) { throw new FindJobException($"cannot find a SaveJob: {JobSeekerId}, {JobInfomationId}"); }
            var SaveJobItem = new SaveJobViewModel()
            {
                JobInformationId = SaveJob.JobInformationId,
                JobSeekerId = SaveJob.JobSeekerId,
                Status = SaveJob.Status,
                TimeSave = SaveJob.TimeSave
            };
            return SaveJobItem;
        }

        //public async Task<int> Update(SaveJobUpdateRequest request)
        //{
        //    var SaveJob = await _context.SaveJobs.FindAsync(request.SaveJobId);

        //    if (SaveJob == null) { throw new FindJobException($"cannot find a SaveJob: {request.SaveJobId}"); }

        //    SaveJob.Name = request.Name;
        //    SaveJob.Experience = request.Experience;

        //    return await _context.SaveChangesAsync();
        //}
    }
}