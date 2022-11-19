using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Recruiters
{
    public class RecuiterImageVM
    {
        public int id { get; set; }
        public int recuiterId { get; set; }
        public string caption { get; set; }
        public string FilePath  { get; set; }
        public long FileSize { get; set; }
        public bool isDefaut { get; set; }
        public int sortOrder { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
