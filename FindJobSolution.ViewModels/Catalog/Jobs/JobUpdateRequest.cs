using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Jobs
{
    public class JobUpdateRequest
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
    }
}
