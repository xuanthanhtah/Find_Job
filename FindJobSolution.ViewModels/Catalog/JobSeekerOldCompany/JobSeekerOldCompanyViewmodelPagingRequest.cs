﻿using FindJobSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.JobSeekerOldCompany
{
    public class JobSeekerOldCompanyViewmodelPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> JobSeekerOldCompanyId { get; set; }
    }
}