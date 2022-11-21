using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FindJobSolution.ViewModels.Catalog.Recruiters
{
    public class RecruiterUpdateRequest
    {
        [Display(Name = "Tên công Ty")]
        public string CompanyName { get; set; }
        [Display(Name = "Địa chỉ công ty")]
        public string Address { get; set; }
        [Display(Name = "Giới thiệu về công ty")]
        public string CompanyIntroduction { get; set; }
        public IFormFile ThumbnailRecuiter { get; set; }
        [Display(Name = "Tên ảnh công Ty")]
        public string nameImage { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}