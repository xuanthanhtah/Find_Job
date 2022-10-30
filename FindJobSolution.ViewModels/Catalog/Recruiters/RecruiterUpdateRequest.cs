﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Recruiters
{
    public class RecruiterUpdateRequest
    {
        public int RecruiterId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string Address { get; set; }
        public string CompanyIntroduction { get; set; }
        public int ViewCount { set; get; }
        public IFormFile ThumbnailRecuiter { get; set; }
    }
}