namespace FindJobSolution.ViewModels.Catalog.JobSeekers
{
    public class JobSeekerViewModel
    {
        public int JobId { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public string Name { get; set; }
        public string National { get; set; }
        public decimal DesiredSalary { get; set; }
        public string ThumbnailCv { get; set; }
    }
}
