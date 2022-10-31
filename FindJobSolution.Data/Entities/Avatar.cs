using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class Avatar
    {
        public int AvatarId { get; set; }
        public string Caption { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
        public DateTime Timespan { get; set; }
        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public int RecruiterId { get; set; }
        public Recruiter Recruiter { get; set; }
    }
}