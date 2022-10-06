using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class SaveJob
    {
        public int SaveJobId { get; set; }
        public int JobInformationId { get; set; }
        public JobInformation JobInformation { get; set; }
        public List<JobSeekerInSaveJob> JobSeekerInSaveJobs { get; set; }

    }
}
