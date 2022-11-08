using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Common;
using FindJobSolution.ViewModels.System.User;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.APItotwoweb.API
{
    public interface IJobInformationApi
    {
        Task<PagedResult<JobInformationViewModel>> GetAllPaging(GetJobInformationPagingRequest request);

        Task<PagedResult<JobInformationViewModel>> GetPagingByRecuiterId(int id, GetJobInformationPagingRequest request);

        Task<bool> Create(JobInformationCreateRequest request);

        Task<JobInformationViewModel> GetById(int id);

        Task<JobInformationViewModel> GetRecuiterIdByUserId(string id);

        Task<bool> Edit(int id, JobInformationUpdateRequest request);

        Task<bool> Delete(int id);
    }

    public class JobInformationAPI : IJobInformationApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public JobInformationAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> Create(JobInformationCreateRequest request)
        {
            //tạo trang mới
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //Hàm lấy api từ backend xử lý đăng ký tài khoản
            var response = await client.PostAsync($"/api/JobInformation", httpContent);
            //trả về thành công 200 hay thất bại 400 > 500
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.DeleteAsync($"/api/JobInformation/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<bool>(body);
            return user;
        }

        public async Task<bool> Edit(int id, JobInformationUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/JobInformation/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<bool>(result);
            return JsonConvert.DeserializeObject<bool>(result);
        }

        public async Task<PagedResult<JobInformationViewModel>> GetAllPaging(GetJobInformationPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"/api/JobInformation/paging?pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var jobSeeker = JsonConvert.DeserializeObject<PagedResult<JobInformationViewModel>>(body);
            return jobSeeker;
        }

        public async Task<JobInformationViewModel> GetById(int id)
        {
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/JobInformation/GetById/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<JobInformationViewModel>(body);
            return user;
        }

        public async Task<PagedResult<JobInformationViewModel>> GetPagingByRecuiterId(int id, GetJobInformationPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"/api/JobInformation/paging/{id}?pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var jobSeeker = JsonConvert.DeserializeObject<PagedResult<JobInformationViewModel>>(body);
            return jobSeeker;
        }

        public async Task<JobInformationViewModel> GetRecuiterIdByUserId(string id)
        {
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/api/Recruiter/recuiterId/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<JobInformationViewModel>(body);
            return user;
        }
    }
}