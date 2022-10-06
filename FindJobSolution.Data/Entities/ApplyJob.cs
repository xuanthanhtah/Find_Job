using FindJobSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class ApplyJob
    {
        public int ApplyJobsId { get; set; }
        public int JobSeekerID { get; set; }
        public int JobInformationId { get; set; }
        public JobInformation JobInformation { get; set; }
        public Status Status { get; set; }
        public List<JobSeekerInApplyJob> jobSeekerInApplyJobs { get; set; }
    }
}
