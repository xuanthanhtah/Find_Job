using FindJobSolution.ViewModels.System.User;
using Newtonsoft.Json;
using System.Text;

namespace FindJobSolution.AdminApp.Service
{
    public interface IUserAPI
    {
        Task<string> Authencate(UserLoginRequest request);
    }

    public class UserAPI : IUserAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Authencate(UserLoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:2001");
            var response = await client.PostAsync("/api/User/Authenticate", httpContent);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }
    }
}