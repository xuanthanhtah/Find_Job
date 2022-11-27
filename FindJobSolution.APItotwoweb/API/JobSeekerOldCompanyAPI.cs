using FindJobSolution.ViewModels.Catalog.JobSeekerOldCompany;
using FindJobSolution.ViewModels.Catalog.JobSeekers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.APItotwoweb.API
{
    public interface IJobSeekerOldCompanyAPI
    {
        Task<JobSeekerOldCompanyViewmodel> GetById(int id);
        Task<bool> Edit(int id, JobSeekerOldCompanyUpdateRequest request);
    }
    public class JobSeekerOldCompanyAPI : IJobSeekerOldCompanyAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JobSeekerOldCompanyAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Edit(int id, JobSeekerOldCompanyUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.CompanyName.ToString()) ? "" : request.CompanyName.ToString()), "CompanyName");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.JobTitle.ToString()) ? "" : request.JobTitle.ToString()), "JobTitle");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.WorkExperience.ToString()) ? "" : request.WorkExperience.ToString()), "WorkExperience");
            requestContent.Add(
            new StringContent(string.IsNullOrEmpty(request.WorkingTime.ToString()) ? "" : request.WorkingTime.ToString()), "WorkingTime");

            var response = await client.PutAsync($"/api/JobSeekerOldCompany/Update/{id}", requestContent);

            var result = response.IsSuccessStatusCode;
            if (result)
                return true;
            return false;
        }

        public async Task<JobSeekerOldCompanyViewmodel> GetById(int id)
        {
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/JobSeekerOldCompany/GetById/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var jobSeeker = JsonConvert.DeserializeObject<JobSeekerOldCompanyViewmodel>(body);
            return jobSeeker;
        }
    }
}
