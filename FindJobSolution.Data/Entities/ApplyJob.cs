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
        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public int JobInformationId { get; set; }
        public JobInformation JobInformation { get; set; }
        public Status Status { get; set; }
        public DateTime TimeApply { get; set; }
    }
}
