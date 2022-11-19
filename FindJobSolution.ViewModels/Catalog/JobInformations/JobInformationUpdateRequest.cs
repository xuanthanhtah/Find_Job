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
    public class JobInformationUpdateRequest
    {
        //public int JobInformationId { get; set; }
        [Display(Name = "Tên công Việc")]
        public string JobTitle { get; set; }

        [Display(Name = "Trình độ")]
        public string JobLevel { get; set; }

        [Display(Name = "Hình thức")]
        public string JobType { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Địa chỉ")]
        public string WorkingLocation { get; set; }

        [Display(Name = "Lương tối thiểu")]
        public decimal MinSalary { get; set; }

        [Display(Name = "Lương tối đa")]
        public decimal MaxSalary { get; set; }

        [Display(Name = "Ngành nghề")]
        public int JobId { get; set; }

        [Display(Name = "Trạng thái")]
        public Status Status { get; set; }

        [Display(Name = "Thời gian bắt đầu")]
        public DateTime JobInformationTimeStart { get; set; }

        [Display(Name = "Thời gian kết thúc")]
        public DateTime JobInformationTimeEnd { get; set; }
    }
}