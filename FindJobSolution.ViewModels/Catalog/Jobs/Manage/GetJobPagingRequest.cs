using FindJobSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Jobs.Manage
{
    public class GetJobPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> jobIds { get; set; }
    }
}
