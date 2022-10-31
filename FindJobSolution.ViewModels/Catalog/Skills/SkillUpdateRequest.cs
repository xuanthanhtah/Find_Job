using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Skills
{
    public class SkillUpdateRequest
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
    }
}
