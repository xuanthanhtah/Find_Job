
using FindJobSolution.ViewModels.Catalog.ApplyJob;
using FindJobSolution.ViewModels.Catalog.SaveJob;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.APItotwoweb.API
{
    public interface ISaveJobAPI
    {

        Task<bool> Create(int id, SaveJobCreateRequestNew request);

        Task<bool> Delete(int jobinfomationid, int jobseekerid);

        Task<SaveJobViewModel> GetById(int jobseekerid, int jobinfomationid);

    }
    public class SaveJobAPI : ISaveJobAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SaveJobAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Create(int id, SaveJobCreateRequestNew request)
        {
            //tạo trang tạo tài khoản mới
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //Hàm lấy api từ backend xử lý đăng ký tài khoản
            var response = await client.PostAsync($"/api/SaveJob/JobInfomationId={id}", httpContent);
            if(response.IsSuccessStatusCode == false)
            {
                return false;
            }
            //trả về thành công 200 hay thất bại 400 > 500
            //var body = await response.Content.ReadAsStringAsync();
            //var user = JsonConvert.DeserializeObject<bool>(body);
            return true;

        }

        public async Task<bool> Delete(int jobseekerid, int jobinfomationid)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.DeleteAsync($"/api/SaveJob/Jobseekerid={jobseekerid}/JobInfomationId={jobinfomationid}");
            return false;
        }

        public async Task<SaveJobViewModel> GetById(int jobseekerid, int jobinfomationid)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"/api/SaveJob/Jobseekerid={jobseekerid}/JobInfomationId={jobinfomationid}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<SaveJobViewModel>(body);
            return user;
        }
    }
}
