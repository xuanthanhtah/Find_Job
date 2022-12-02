using FindJobSolution.ViewModels.Catalog.JobSeekerSkill;
using FindJobSolution.ViewModels.Catalog.Skills;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.APItotwoweb.API
{
    public interface IJobSeekerSkillAPI
    {
        Task<bool> Create(int id, JobSeekerSkillCreateRequest request);
        Task<JobSeekerSkillViewModel> GetById(int jobseekerid, int skillid);
        Task<bool> Edit(JobSeekerSkillUpdateRequest request);
    }
    public class JobSeekerSkillAPI : IJobSeekerSkillAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JobSeekerSkillAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<bool> Create(int id, JobSeekerSkillCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Edit(JobSeekerSkillUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/JobSeekerSkill/Update/{request.SkillId}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<bool>(result);
            return JsonConvert.DeserializeObject<bool>(result);
        }

        public async Task<JobSeekerSkillViewModel> GetById(int jobseekerid, int skillid)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"/api/skill/Jobseekerid={jobseekerid}/SkillId={skillid}");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<JobSeekerSkillViewModel>(body);
            return user;
        }
    }
}
