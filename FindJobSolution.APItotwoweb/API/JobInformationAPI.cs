using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Common;
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

        Task<bool> Create(JobInformationCreateRequest request);
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

        public async Task<PagedResult<JobInformationViewModel>> GetAllPaging(GetJobInformationPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"/api/JobInformation/paging?pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var jobSeeker = JsonConvert.DeserializeObject<PagedResult<JobInformationViewModel>>(body);
            return jobSeeker;
        }
    }
}