
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
            //trả về thành công 200 hay thất bại 400 > 500
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<bool>(body);

            return user;
        }

        public async Task<bool> Delete(int jobseekerid, int jobinfomationid)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.DeleteAsync($"/api/SaveJob/Jobseekerid={jobseekerid},JobInfomationId={jobinfomationid}");
            return false;
        }
    }
}
