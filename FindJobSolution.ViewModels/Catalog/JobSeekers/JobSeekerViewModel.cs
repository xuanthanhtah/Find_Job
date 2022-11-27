namespace FindJobSolution.ViewModels.Catalog.JobSeekers
{
    public class JobSeekerViewModel
    {
        public Guid id { get; set; }
        public int jobseekerId { get; set; }
        public int JobId { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string National { get; set; }
        public DateTime Dob { get; set; }
        public decimal DesiredSalary { get; set; }
        public string ThumbnailCv { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string CompanyName { get; set; }
        public string WorkingTime { get; set; }
        public string JobTitle { get; set; }
        public string WorkExperience { get; set; }

        public string Skillname { get; set; }
        public string SkillExperience { get; set; }
    }
}