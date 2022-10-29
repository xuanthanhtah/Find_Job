using FindJobSolution.Data.Enums;
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
        public string Caption { get; set; }
        public MediaType FileType { get; set; }
        public long FileSize { get; set; }
        public int SortOrder { get; set; }
        public DateTime Timespan { get; set; }
        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
    }
}
