using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using FindJobSolution.APItotwoweb.API;
using System.Net.Http.Headers;
using System;
using Microsoft.AspNetCore.Http;

namespace FindJobSolution.APItotwoweb.API
{
    public interface IJobAPI
    {
        Task<PagedResult<JobViewModel>> GetAllPaging(GetJobPagingRequest request);

        Task<List<JobViewModel>> GetAll();

        Task<bool> Create(JobCreateRequest request);

        Task<bool> Delete(int id);

        Task<bool> Edit(JobUpdateRequest request);

        Task<JobViewModel> GetById(int id);


    }

    public class JobAPI : IJobAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JobAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Create(JobCreateRequest request)
        {
            //tạo trang mới
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //Hàm lấy api từ backend xử lý đăng ký tài khoản
            var response = await client.PostAsync($"/api/Job", httpContent);
            //trả về thành công 200 hay thất bại 400 > 500
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.DeleteAsync($"/api/job/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<bool>(body);
            return user;
        }

        public async Task<PagedResult<JobViewModel>> GetAllPaging(GetJobPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"/api/Job/paging?pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var jobSeeker = JsonConvert.DeserializeObject<PagedResult<JobViewModel>>(body);
            return jobSeeker;
        }

        public async Task<bool> Edit(JobUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/job/{request.Id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<bool>(result);
            return JsonConvert.DeserializeObject<bool>(result);
        }

        public async Task<JobViewModel> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"/api/job/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<JobViewModel>(body);
            return user;
        }

        public async Task<List<JobViewModel>> GetAll()
        {
            return await GetListAsync<JobViewModel>($"/api/Job");
        }

        private async Task<List<T>> GetListAsync<T>(string url, bool requiredLogin = false)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = (List<T>)JsonConvert.DeserializeObject(body, typeof(List<T>));
                return data;
            }
            throw new Exception(body);
        }
    }
}