using FindJobSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.ApplyJob
{
    public class ApplyJobUpdateStatusRequest
    {
        public Status Status { get; set; }

        public DateTime TimeApply { get; set; }
    }
}
