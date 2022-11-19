using FindJobSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FindJobSolution.ViewModels.Catalog.JobInformations
{
    public class JobInformationCreateRequest
    {
        [Display(Name = "Tên công việc")]
        public string JobTitle { get; set; }

        [Display(Name = "Trình độ của công việc")]
        public string JobLevel { get; set; }

        [Display(Name = "Hình thức làm việc")]
        public string JobType { get; set; }

        [Display(Name = "Mô tả công việc")]
        public string Description { get; set; }

        [Display(Name = "Địa chỉ làm việc")]
        public string WorkingLocation { get; set; }

        [Display(Name = "Lương tối thiểu")]
        public decimal MinSalary { get; set; }

        [Display(Name = "Lương tối đa")]
        public decimal MaxSalary { get; set; }

        [Display(Name = "Ngành nghề")]
        public int JobId { get; set; }

        [Display(Name = "Thời gian bắt đầu tuyển dụng")]
        public DateTime JobInformationTimeStart { get; set; }

        [Display(Name = "Thời gian kết thúc tuyển dụng")]
        public DateTime JobInformationTimeEnd { get; set; }
    }
}