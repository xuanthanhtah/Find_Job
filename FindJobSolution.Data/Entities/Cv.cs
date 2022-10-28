using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class Cv
    {
        public int CvId { get; set; }
        public string Name { get; set; }
        public string fileType { get; set; }
        public long FileSize { get; set; }
        public DateTime Timespan { get; set; }
        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public int ViewCount { set; get; }
    }
}
