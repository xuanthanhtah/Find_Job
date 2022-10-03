using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Major { get; set; }
        public string SchoolName { get; set; }
        public string Degree { get; set; }
        public string Certificate { get; set; }
        public string Language { get; set; }
        public string level { get; set; }
        public List<JobSeekerSkill> JobSeekerSkills { get; set; }
    }
}
