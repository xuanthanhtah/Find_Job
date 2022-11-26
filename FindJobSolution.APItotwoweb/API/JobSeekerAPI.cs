using FindJobSolution.Data.Entities;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using FindJobSolution.ViewModels.Common;
using FindJobSolution.ViewModels.System.UsersJobSeeker;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FindJobSolution.APItotwoweb.API
{
    public interface IJobSeekerAPI
    {
        Task<PagedResult<JobSeekerViewModel>> GetAllPagingJobSeeker(GetJobSeekerPagingRequest request);

        Task<JobSeekerViewModel> GetById(int id);

        Task<bool> Delete(int id);

        Task<JobSeekerViewModel> GetByUserId(string id);

        Task<bool> Register(RegisterRequest request);

        Task<JobViewModel> GetJobIdByjobSeekerId(int Id);

        Task<bool> Edit(int id, JobSeekerUpdateRequest request);
    }

    public class JobSeekerAPI : IJobSeekerAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JobSeekerAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
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

        public async Task<bool> Edit(int id, JobSeekerUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnailCv != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailCv.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailCv.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ThumbnailCv", request.ThumbnailCv.FileName);
            }
            if (request.ThumbnailAvatar != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailAvatar.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailAvatar.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ThumbnailAvatar", request.ThumbnailAvatar.FileName);
            }
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.Name.ToString()) ? "" : request.Name.ToString()), "Name");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.DesiredSalary.ToString()) ? "" : request.DesiredSalary.ToString()), "DesiredSalary");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.Address.ToString()) ? "" : request.Address.ToString()), "Address");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.National.ToString()) ? "" : request.National.ToString()), "National");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.PhoneNumber.ToString()) ? "" : request.PhoneNumber.ToString()), "PhoneNumber");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.Gender.ToString()) ? "" : request.Gender.ToString()), "Gender");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.Dob.ToString()) ? "" : request.Dob.ToString()), "Dob");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.Email.ToString()) ? "" : request.Email.ToString()), "Email");
            requestContent.Add(
           new StringContent(string.IsNullOrEmpty(request.nameCv.ToString()) ? "" : request.nameCv.ToString()), "nameCv");
            requestContent.Add(
           new StringContent(string.IsNullOrEmpty(request.nameAvatar.ToString()) ? "" : request.nameAvatar.ToString()), "nameAvatar");
            //requestContent.Add(
            //new StringContent(string.IsNullOrEmpty(request.Name.ToString()) ? "" : request.Name.ToString()), "Name");

            var response = await client.PutAsync($"/api/JobSeeker/editjobseeker/{id}", requestContent);

            var result = response.IsSuccessStatusCode;
            if (response.IsSuccessStatusCode)
                return true;
            return false;
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

        public async Task<JobSeekerViewModel> GetByUserId(string id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"/api/JobSeeker/user/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<JobSeekerViewModel>(body);
            return user;
        }

        public async Task<JobViewModel> GetJobIdByjobSeekerId(int id)
        {
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/JobSeeker/job/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var jobSeeker = JsonConvert.DeserializeObject<JobViewModel>(body);
            return jobSeeker;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            //tạo trang tạo tài khoản mới
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //Hàm lấy api từ backend xử lý đăng ký tài khoản
            var response = await client.PostAsync($"/api/UsersJobSeeker/register", httpContent);
            //trả về thành công 200 hay thất bại 400 > 500
            return response.IsSuccessStatusCode;
        }
    }
}