using FindJobSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class JobInformation
    {
        public int JobInformationId { get; set; }
        public string JobTitle { get; set; }
        public string JobLevel { get; set; } 
        public string JobType { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string WorkingLocation { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal Salary { get; set; }
        public int ViewCount { set; get; } 
        public string Benefits { get; set; } 
        public Status Status { get; set; }
        public DateTime JobInformationTimeStart { get; set; }
        public DateTime JobInformationTimeEnd { get; set; }
        public Recruiter Recruiter { get; set; }
        public int RecruiterId { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public ApplyJob ApplyJob { get; set; }
        public SaveJob SaveJob { get; set; }
    }
}
