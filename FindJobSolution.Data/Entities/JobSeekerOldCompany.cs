using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class JobSeekerOldCompany
    {
        public int JobSeekerOldCompanyId { get; set; }
        public string CompanyName { get; set; }
        public string WorkingTime { get; set; }
        public string JobTitle { get; set; }
        public string WorkExperience { get; set; }
        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
    }
}
