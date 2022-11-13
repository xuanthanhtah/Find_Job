using FindJobSolution.Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.ApplyJob
{
    public class ApplyJobViewModel
    {
        public int JobSeekerId { get; set; }
        public int JobInformationId { get; set; }
        public Status Status { get; set; }
        public DateTime TimeApply { get; set; }


        public IFormFile ThumbnailRecuiter { get; set; }
        public string nameImage { get; set; }

    }
}
