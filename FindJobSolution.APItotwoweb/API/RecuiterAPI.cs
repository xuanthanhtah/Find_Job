using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.Catalog.Recruiters;
using FindJobSolution.ViewModels.Common;
using FindJobSolution.ViewModels.System.User;
using FindJobSolution.ViewModels.System.UsersRecruiter;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace FindJobSolution.APItotwoweb.API
{
    public interface IRecuiterAPI
    {
        Task<PagedResult<RecruiterVM>> GetAllPagingRecuiter(GetRecuiterPagingRequest request);

        Task<RecruiterVM> GetById(int id);

        Task<bool> Delete(int id);

        Task<bool> Register(RegisterRecuiterRequest request);
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

        public async Task<bool> Register(RegisterRecuiterRequest request)
        {
            //tạo trang tạo tài khoản mới
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //Hàm lấy api từ backend xử lý đăng ký tài khoản
            var response = await client.PostAsync($"/api/UsersRecuiter/register", httpContent);
            //trả về thành công 200 hay thất bại 400 > 500
            return response.IsSuccessStatusCode;
        }
    }
}