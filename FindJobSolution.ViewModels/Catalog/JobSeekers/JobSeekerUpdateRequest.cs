using FindJobSolution.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FindJobSolution.ViewModels.Catalog.JobSeekers
{
    public class JobSeekerUpdateRequest
    {
        //public int JobSeekerId { get; set; }
        //public int JobId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string National { get; set; }
        public decimal DesiredSalary { get; set; }
        public DateTime Dob { get; set; }
        public IFormFile ThumbnailCv { get; set; }
        [Display(Name = "Tên ảnh công Ty")]
        public string nameCv { get; set; }
        public IFormFile ThumbnailAvatar { get; set; }
        public string nameAvatar { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}