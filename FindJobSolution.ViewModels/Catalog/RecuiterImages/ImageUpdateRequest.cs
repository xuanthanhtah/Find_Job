using Microsoft.AspNetCore.Http;

namespace FindJobSolution.ViewModels.Catalog.RecuiterImages
{
    public class ImageUpdateRequest
    {
        public int CvId { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
        public IFormFile FileImage { get; set; }
    }
}