namespace FindJobSolution.Data.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public List<JobSeekerSkill> JobSeekerSkills { get; set; }
    }
}
