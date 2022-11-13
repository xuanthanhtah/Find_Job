using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindJobSolution.ViewModels.Catalog.SaveJob;

namespace FindJobSolution.ViewModels.Catalog.ApplyJob
{
    public class ApplySaveViewModel
    {
        public List<ApplyJobViewModel> applyJobs { get; set; }
        public List<SaveJobViewModel> saveJobs { get; set; }
    }
}
