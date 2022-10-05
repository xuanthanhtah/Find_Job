using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public List<JobSeeker> JobSeekers { get; set; }
        public List<JobInformation> JobInformation { get; set; }
    }
}
