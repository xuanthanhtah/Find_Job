using FindJobSolution.ViewModels.Catalog.JobSeekerSkill;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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

        public Task<bool> Edit(JobSeekerSkillUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<JobSeekerSkillViewModel> GetById(int jobseekerid, int skillid)
        {
            throw new NotImplementedException();
        }
    }
}
