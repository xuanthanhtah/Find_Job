using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Cvs
{
    public class CvCreateRequest
    {
        public string Name { get; set; }
        public string fileType { get; set; }
        public long FileSize { get; set; }
        public DateTime Timespan { get; set; }
        public int ViewCount { set; get; }
    }
}
