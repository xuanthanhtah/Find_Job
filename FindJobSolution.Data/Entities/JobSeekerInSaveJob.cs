using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class JobSeekerInSaveJob
    {
        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public int SaveJobId { get; set; }
        public SaveJob SaveJob { get; set; }
        public DateTime TimeSaveJob { get; set; }
    }
}
