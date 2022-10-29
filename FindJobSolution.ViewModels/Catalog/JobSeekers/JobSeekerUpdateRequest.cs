﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.JobSeekers
{
    public class JobSeekerUpdateRequest
    {
        public int JobSeekerId { get; set; }
        public int JobId { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string National { get; set; }
        public string Image { get; set; }
        public decimal DesiredSalary { get; set; }
    }
}