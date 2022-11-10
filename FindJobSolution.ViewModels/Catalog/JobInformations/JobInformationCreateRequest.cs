using FindJobSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.JobInformations
{
    public class JobInformationCreateRequest
    {
        public string JobTitle { get; set; }
        public string JobLevel { get; set; }
        public string JobType { get; set; }
        public string Description { get; set; }
        public string WorkingLocation { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public int JobId { get; set; }
        public DateTime JobInformationTimeStart { get; set; }
        public DateTime JobInformationTimeEnd { get; set; }
    }
}