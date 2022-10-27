using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class RecruiterGalleries
    {
        public int RecruiterGalleriesId { get; set; }
        public int RecruiterId { get; set; }
        public string src { get; set; }
        public string Caption { get; set; }
        public DateTime DateCreated { get; set; }
        public int FileSize { get; set; }
        public Recruiter Recruiter { get; set; }
    }
}
