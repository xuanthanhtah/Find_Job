using FindJobSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.ApplyJob
{
    public class GetApplyJobPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
    }
}