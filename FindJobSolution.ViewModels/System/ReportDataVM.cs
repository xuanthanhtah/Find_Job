using FindJobSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FindJobSolution.ViewModels.System
{
    public class ReportDataVM
    {
        public int TotalJobSeeker { get; set; }
        public int TotalRecuiter { get; set; }
        public int TotalJobApply { get; set; }
        public int TotalJobInformation { get; set; }
        public int TotalCv { get; set; }
        public int TotalJob { get; set; }
        public int TotalSkill { get; set; }
        public int TotalReport { get; set; }

        [Display(Name = "Tên công việc")]
        public string JobTitle { get; set; }

        [Display(Name = "Trình độ")]
        public string JobLevel { get; set; }

        [Display(Name = "Hình thức")]
        public string JobType { get; set; }

        [Display(Name = "Lương tối đa")]
        public decimal MaxSalary { get; set; }

        [Display(Name = "Tên công việc")]
        public string JobTitleApply { get; set; }

        [Display(Name = "Trình độ")]
        public string JobLevelApply { get; set; }

        [Display(Name = "Hình thức")]
        public string JobTypeApply { get; set; }

        [Display(Name = "Lương tối đa")]
        public decimal MaxSalaryApply { get; set; }
    }
}