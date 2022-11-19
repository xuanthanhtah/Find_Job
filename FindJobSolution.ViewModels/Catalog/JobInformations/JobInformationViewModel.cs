using FindJobSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FindJobSolution.ViewModels.Catalog.JobInformations
{
    public class JobInformationViewModel
    {
        [Display(Name = "Mã công việc")]
        public int JobInformationId { get; set; }

        [Display(Name = "Tên công việc")]
        public string JobTitle { get; set; }

        [Display(Name = "Trình độ")]
        public string JobLevel { get; set; }

        [Display(Name = "Hình thức")]
        public string JobType { get; set; }

        [Display(Name = "Mô tả công việc")]
        public string Description { get; set; }

        [Display(Name = "Địa chỉ")]
        public string WorkingLocation { get; set; }

        [Display(Name = "Lương tối thiểu")]
        public decimal MinSalary { get; set; }

        [Display(Name = "Lương tối đa")]
        public decimal MaxSalary { get; set; }

        public int ViewCount { set; get; }

        [Display(Name = "Trạng thái")]
        public Status Status { get; set; }

        public int RecruiterId { get; set; }

        [Display(Name = "Ngành nghề")]
        public int JobId { get; set; }

        public string CompanyName { get; set; }
        
        [Display(Name = "Thời gian bắt đầu tuyển")]
        public DateTime JobInformationTimeStart { get; set; }

        [Display(Name = "Thời gian kết thúc tuyển")]
        public DateTime JobInformationTimeEnd { get; set; }

    }
}