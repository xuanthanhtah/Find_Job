using FindJobSolution.Data.Entities;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.Common;
using FindJobSolution.ViewModels.System.User;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FindJobSolution.APItotwoweb.API
{
    public interface IJobSeekerAPI
    {
        Task<PagedResult<JobSeekerViewModel>> GetAllPagingJobSeeker(GetJobSeekerPagingRequest request);

        Task<JobSeekerViewModel> GetById(int id);

        Task<bool> Delete(int id);
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

        public async Task<bool> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.DeleteAsync($"/api/JobSeeker/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<bool>(body);
            return user;
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

        public async Task<JobSeekerViewModel> GetById(int id)
        {
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/JobSeeker/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var jobSeeker = JsonConvert.DeserializeObject<JobSeekerViewModel>(body);
            return jobSeeker;
        }
    }
}