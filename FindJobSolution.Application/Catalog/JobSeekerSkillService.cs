
using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.JobSeekerSkill;
using FindJobSolution.ViewModels.Catalog.SaveJob;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Application.Catalog
{
    public interface IJobSeekerSkillService
    {
        Task<bool> Update(int id, JobSeekerSkillUpdateRequest request);
        Task<JobSeekerSkillViewModel> GetbyId(int JobSeekerId, int SkillId);
        Task<List<JobSeekerSkillViewModel>> GetAll();
    }
    public class JobSeekerSkillService : IJobSeekerSkillService
    {
        private readonly FindJobDBContext _context;
        public JobSeekerSkillService(FindJobDBContext context)
        {
            _context = context;
        }

        public async Task<List<JobSeekerSkillViewModel>> GetAll()
        {
            var query = from j in _context.JobSeekerSkills select new { j };

            return await query
               .Select(p => new JobSeekerSkillViewModel()
               {
                   SkillId = p.j.SkillId,
                   JobSeekerId = p.j.JobSeekerId,
               }).ToListAsync();
        }

        public async Task<JobSeekerSkillViewModel> GetbyId(int JobSeekerId, int SkillId)
        {
            var JobSeekerSkill = await _context.JobSeekerSkills.FindAsync(SkillId,JobSeekerId);
            if (JobSeekerSkill == null) { throw new FindJobException($"cannot find a jobseeker skill: {JobSeekerId},{SkillId}"); }

            var JobSeekerSkillItem = new JobSeekerSkillViewModel()
            {
                SkillId = JobSeekerSkill.SkillId,
                JobSeekerId = JobSeekerSkill.JobSeekerId,           
            };
            return JobSeekerSkillItem;
        }

        public async Task<bool> Update(int id, JobSeekerSkillUpdateRequest request)
        {
            var jobSeekerSkill = await _context.JobSeekerSkills.FirstOrDefaultAsync(p => p.JobSeekerId == id);

            _context.JobSeekerSkills.Remove(jobSeekerSkill);

            if (jobSeekerSkill == null) { throw new FindJobException($"cannot find a jobseeker skill: {jobSeekerSkill}"); }

            var jsskill = new JobSeekerSkill()
            {
                JobSeekerId = id,
                SkillId = request.SkillId,
                Experience = request.Experience,
            };

            _context.JobSeekerSkills.Add(jsskill);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
