
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public  class JobSeeker
    {
        public int JobSeekerId { get; set; }
        public int JobId { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string National { get; set; }
        public string Image { get; set; }
        public DateTime Dob { get; set; }
        public decimal DesiredSalary { get; set; }
        public Guid UserId { get; set; }
        public User Users { get; set; }
        public Job Job { get; set; }
        public List<JobSeekerInApplyJob> jobSeekerInApplyJobs { get; set; }
        public List<JobSeekerInSaveJob> JobSeekerInSaveJobs { get; set; }
        public List<JobSeekerOldCompany> JobSeekerOldCompanies { get; set; }
        public List<JobSeekerSkill> JobSeekerSkills { get; set; }
        public List<Cv> Cvs { get; set; }
    }
}