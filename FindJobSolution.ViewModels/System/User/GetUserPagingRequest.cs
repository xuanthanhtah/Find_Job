using FindJobSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.System.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string? keyword { get; set; }
    }
}