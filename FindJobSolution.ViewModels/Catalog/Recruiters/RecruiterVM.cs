using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FindJobSolution.ViewModels.Catalog.Recruiters
{
    public class RecruiterVM
    {
        [Display(Name = "Mã công ty")]
        public Guid id { get; set; }
        [Display(Name = "Mã công ty")]

        public int RecruiterId { get; set; }
        [Display(Name = "Tên công ty")]

        public string CompanyName { get; set; }
        [Display(Name = "Địa chỉ công ty")]

        public string Address { get; set; }
        [Display(Name = "Giới thiệu về công ty")]

        public string CompanyIntroduction { get; set; }
        public int ViewCount { set; get; }
        [Display(Name = "Hình ảnh về công ty")]

        public string ThumbnailCv { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}