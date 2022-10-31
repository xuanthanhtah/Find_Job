using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public  class Recruiter
    {
        public int RecruiterId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string Address { get; set; }
        public string CompanyIntroduction { get; set; }
        public int ViewCount { set; get; }
        public Guid UserId { get; set; }
        public User Users { get; set; }
        public List<JobInformation> JobInformation { get; set; }
        public List<RecruiterImages> recruiterGalleries { get; set; }
    }
}
