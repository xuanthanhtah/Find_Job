using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.ApplyJob;
using FindJobSolution.ViewModels.Catalog.SaveJob;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FindJobSolution.Application.Catalog
{
    public interface IApplyJobService
    {
        Task<int> Create(int id, ApplyJobCreateRequestNew request);

        Task<int> Delete(int JobSeekerId, int JobInfomationId);

        Task<Tuple<List<ApplyJobViewModel>, List<SaveJobViewModel>>> GetAll();

        Task<ApplyJobViewModel> GetbyId(int JobSeekerId, int JobInfomationId);

        Task<List<ApplyJobViewModel>> GetbyJobInfomationId(int JobInfomationId);

        Task<bool> Update(int jobSeekerId, int JobInformationId, ApplyJobUpdateStatusRequest request);
    }

    public class ApplyJobService : IApplyJobService
    {
        private readonly FindJobDBContext _context;

        public ApplyJobService(FindJobDBContext context)
        {
            _context = context;
        }

        public async Task<int> Create(int id, ApplyJobCreateRequestNew request)
        {
            var getid = await _context.Users.FirstOrDefaultAsync(p => p.UserName == request.UserIdentityName);
            var getjsid = await _context.JobSeekers.FirstOrDefaultAsync(p => p.UserId == getid.Id);

            var ApplyJob = new ApplyJob()
            {
                JobInformationId = id,
                JobSeekerId = getjsid.JobSeekerId,
                Status = Data.Enums.Status.Inprogress,
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

        public async Task<Tuple<List<ApplyJobViewModel>, List<SaveJobViewModel>>> GetAll()
        {
            var query = from j in _context.ApplyJobs
                        join k in _context.JobInformations on j.JobInformationId equals k.JobInformationId
                        join j2 in _context.Recruiters on k.RecruiterId equals j2.RecruiterId
                        join j3 in _context.RecruiterImages on j2.RecruiterId equals j3.RecruiterId
                        select new { j, k, j2, j3 };

            var query2 = from i in _context.SaveJobs
                         join q in _context.JobInformations on i.JobInformationId equals q.JobInformationId
                         join i2 in _context.Recruiters on q.RecruiterId equals i2.RecruiterId
                         join i3 in _context.RecruiterImages on i2.RecruiterId equals i3.RecruiterId
                         select new { i, q, i2, i3 };

            var List1 = await query
               .Select(p => new ApplyJobViewModel()
               {
                   JobInformationId = p.j.JobInformationId,
                   JobSeekerId = p.j.JobSeekerId,
                   Status = p.j.Status,
                   TimeApply = p.j.TimeApply,

                   JobType = p.k.JobType,
                   WorkingLocation = p.k.WorkingLocation,
                   MinSalary = p.k.MinSalary,
                   MaxSalary = p.k.MaxSalary,

                   CompanyName = p.j2.CompanyName,
                   FilePath = p.j3.FilePath,
               }
               ).ToListAsync();

            var List2 = await query2
               .Select(p => new SaveJobViewModel()
               {
                   JobInformationId = p.i.JobInformationId,
                   JobSeekerId = p.i.JobSeekerId,
                   Status = p.i.Status,
                   TimeSave = p.i.TimeSave,

                   JobType = p.q.JobType,
                   WorkingLocation = p.q.WorkingLocation,
                   MinSalary = p.q.MinSalary,
                   MaxSalary = p.q.MaxSalary,

                   CompanyName = p.i2.CompanyName,
                   FilePath = p.i3.FilePath,
               }
               ).ToListAsync();

            return Tuple.Create(List1, List2);
        }

        private List<ApplyJob> GetApplyJob(int JobSeekerId)
        {
            List<ApplyJob> applyJobs = _context.ApplyJobs.Where(p => p.JobSeekerId == JobSeekerId).ToList();
            return applyJobs;
        }

        public List<SaveJob> GetSaveJob()
        {
            List<SaveJob> saveJobs = new List<SaveJob>();
            return saveJobs;
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

        public async Task<List<ApplyJobViewModel>> GetbyJobInfomationId(int JobInfomationId)
        {
            var jobInforId = await _context.ApplyJobs.FirstOrDefaultAsync(x => x.JobInformationId == JobInfomationId);
            if (jobInforId == null) { throw new FindJobException($"cannot find a ApplyJob: {JobInfomationId}"); }

            var query = from j in _context.ApplyJobs
                        where j.JobInformationId == JobInfomationId
                        select new { j };

            return await query
               .Select(p => new ApplyJobViewModel()
               {
                   JobInformationId = p.j.JobInformationId,
                   JobSeekerId = p.j.JobSeekerId,
                   Status = p.j.Status,
                   TimeApply = p.j.TimeApply,
               }).ToListAsync();
        }

        public async Task<bool> Update(int jobSeekerId, int JobInformationId, ApplyJobUpdateStatusRequest request)
        {
            var ApplyJobs = await _context.ApplyJobs.FindAsync(jobSeekerId, JobInformationId);

            if (ApplyJobs == null) { throw new FindJobException($"cannot find a jobinformation: {jobSeekerId} + {JobInformationId}"); }

            ApplyJobs.Status = request.Status;

            await _context.SaveChangesAsync();
            return true;
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