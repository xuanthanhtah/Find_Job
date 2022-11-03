using FindJobSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.JobSeekers
{
    public class GetJobSeekerPagingRequest : PagingRequestBase
    {
        public string? keyword { get; set; }
        public List<int> jobSeekerIds { get; set; }
    }
}