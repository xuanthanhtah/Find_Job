using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.RecuiterImages
{
    public class ImageViewModel
    {
        public int RecruiterGalleriesId { get; set; }
        public int RecruiterId { get; set; }
        public string Caption { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
        public DateTime DateCreated { get; set; }
    }
}