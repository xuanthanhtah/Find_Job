using Microsoft.AspNetCore.Http;

namespace FindJobSolution.ViewModels.Catalog.Cvs
{
    public class CvCreateRequest
    {
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
        public IFormFile FileCv { get; set; }
    }
}
