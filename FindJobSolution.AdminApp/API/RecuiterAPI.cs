using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.Catalog.Recruiters;
using FindJobSolution.ViewModels.Common;
using FindJobSolution.ViewModels.System.User;
using Newtonsoft.Json;

namespace FindJobSolution.AdminApp.API
{
    public interface IRecuiterAPI
    {
        Task<PagedResult<RecruiterVM>> GetAllPagingRecuiter(GetRecuiterPagingRequest request);

        Task<RecruiterVM> GetById(int id);

        Task<bool> Delete(int id);
    }

    public class RecuiterAPI : IRecuiterAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public RecuiterAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.DeleteAsync($"/api/Recruiter/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<bool>(body);
            return user;
        }

        public async Task<PagedResult<RecruiterVM>> GetAllPagingRecuiter(GetRecuiterPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);

            var response = await client.GetAsync($"/api/Recruiter/paging?pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var recuiter = JsonConvert.DeserializeObject<PagedResult<RecruiterVM>>(body);
            return recuiter;
        }

        public async Task<RecruiterVM> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"/api/Recruiter/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<RecruiterVM>(body);
            return user;
        }
    }
}