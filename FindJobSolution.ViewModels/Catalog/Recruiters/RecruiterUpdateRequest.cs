using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Recruiters
{
    public class RecruiterUpdateRequest
    {
        public Guid Id { get; set; }
        public int RecruiterId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CompanyIntroduction { get; set; }
        public IFormFile ThumbnailRecuiter { get; set; }
        public string nameImage { get; set; }
    }
}