using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.JobSeekers
{
    public class JobSeekerCvViewModel
    {
        public int CvId { get; set; }
        public int JobSeekerId { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime Timespan { get; set; }
        public long FileSize { get; set; }
        public int SortOrder { get; set; }
    }
}
