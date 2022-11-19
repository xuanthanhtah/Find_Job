using FindJobSolution.Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.ApplyJob
{
    public class ApplyJobViewModel
    {
        public int JobSeekerId { get; set; }
        public int JobInformationId { get; set; }
        public Status Status { get; set; }
        public DateTime TimeApply { get; set; }


        public string JobType { get; set; }
        public string WorkingLocation { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }

        public string CompanyName { get; set; }
        public string FilePath { get; set; }

    }
}
