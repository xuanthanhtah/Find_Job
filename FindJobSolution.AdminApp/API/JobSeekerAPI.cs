using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.Common;
using Newtonsoft.Json;

namespace FindJobSolution.AdminApp.API
{
    public interface IJobSeekerAPI
    {
        Task<PagedResult<JobSeekerViewModel>> GetAllPagingJobSeeker(GetJobSeekerPagingRequest request);
    }

    public class JobSeekerAPI : IJobSeekerAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public JobSeekerAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<PagedResult<JobSeekerViewModel>> GetAllPagingJobSeeker(GetJobSeekerPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);

            var response = await client.GetAsync($"/api/JobSeeker/paging?pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var jobSeeker = JsonConvert.DeserializeObject<PagedResult<JobSeekerViewModel>>(body);
            return jobSeeker;
        }
    }
}