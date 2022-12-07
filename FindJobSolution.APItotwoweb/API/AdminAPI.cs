using FindJobSolution.Data.Entities;
using FindJobSolution.ViewModels.Catalog.ApplyJob;
using FindJobSolution.ViewModels.System;
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
    public interface IAdminAPI
    {
        Task<ReportDataVM> GetReportData();
    }
    public class AdminAPI : IAdminAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ReportDataVM> GetReportData()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync("/api/Admin/report");
            var body = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<ReportDataVM>(body);
            return user;
        }
    }
}
