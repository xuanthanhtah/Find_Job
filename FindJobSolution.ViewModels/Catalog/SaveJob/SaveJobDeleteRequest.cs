using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.SaveJob
{
    public class SaveJobDeleteRequest
    {
        public int JobInformationId { get; set; }

        public int JobSeekerId { get; set; }
    }
}
