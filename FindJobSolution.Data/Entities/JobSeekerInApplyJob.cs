using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class JobSeekerInApplyJob
    {
        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public int ApplyJobsId { get; set; }
        public ApplyJob ApplyJob { get; set; }
        public DateTime ApplyJobsTime { get; set; }
    }
}
