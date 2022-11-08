using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.Catalog.Recruiters;
using FindJobSolution.ViewModels.Common;
using FindJobSolution.ViewModels.System.User;
using FindJobSolution.ViewModels.System.UsersRecruiter;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FindJobSolution.APItotwoweb.API
{
    public interface IRecuiterAPI
    {
        Task<PagedResult<RecruiterVM>> GetAllPagingRecuiter(GetRecuiterPagingRequest request);

        Task<RecruiterVM> GetById(int id);

        Task<RecruiterVM> GetByUserId(string id);

        Task<bool> Delete(int id);

        Task<bool> Register(RegisterRecuiterRequest request);

        Task<bool> Edit(int id, RecruiterUpdateRequest request);
    }

    public class RecuiterAPI : IRecuiterAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RecuiterAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
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

        public async Task<bool> Edit(int id, RecruiterUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnailRecuiter != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailRecuiter.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailRecuiter.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ThumbnailRecuiter", request.ThumbnailRecuiter.FileName);
            }
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.CompanyName.ToString()) ? "" : request.CompanyName.ToString()), "CompanyName");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.Address.ToString()) ? "" : request.Address.ToString()), "Address");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.CompanyIntroduction.ToString()) ? "" : request.CompanyIntroduction.ToString()), "CompanyIntroduction");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.nameImage.ToString()) ? "" : request.nameImage.ToString()), "nameImage");

            var response = await client.PutAsync($"/api/Recruiter/edit/{id}", requestContent);

            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<bool>(result);
            return JsonConvert.DeserializeObject<bool>(result);
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

        public async Task<RecruiterVM> GetByUserId(string id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"/api/Recruiter/user/{id}");
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