using FindJobSolution.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace FindJobSolution.ViewModels.Catalog.JobSeekers
{
    public class JobSeekerCreateRequest
    {
        public int JobId { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string National { get; set; }
        public decimal DesiredSalary { get; set; }
        public Guid UserId { get; set; }
        public User Users { get; set; }
        public IFormFile ThumbnailCv { get; set; }
    }
}
