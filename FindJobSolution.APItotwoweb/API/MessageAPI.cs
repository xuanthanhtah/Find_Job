//using FindJobSolution.APItotwoweb.API;
//using FindJobSolution.ViewModels.Catalog.Jobs;
//using FindJobSolution.ViewModels.Catalog.Message;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FindJobSolution.APItotwoweb.API
//{
//    public interface IMessageAPI
//    {
//        Task<List<MessageModel>> GetbyUserId(string Id);

//        Task<bool> Create(string Id, MessageCreateRequest request);
//    }
//}

//public class MessageAPI : IMessageAPI
//{
//    private readonly IHttpClientFactory _httpClientFactory;
//    private readonly IConfiguration _configuration;
//    private readonly IHttpContextAccessor _httpContextAccessor;

//    public MessageAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
//    {
//        _httpClientFactory = httpClientFactory;
//        _configuration = configuration;
//        _httpContextAccessor = httpContextAccessor;
//    }

//    public async Task<bool> Create(string Id, MessageCreateRequest request)
//    {
//        var client = _httpClientFactory.CreateClient();
//        client.BaseAddress = new Uri(_configuration["BaseAddress"]);

//        var json = JsonConvert.SerializeObject(request);

//        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

//        var response = await client.PostAsync($"/api/Message/{Id}", httpContent);
//        //trả về thành công 200 hay thất bại 400 > 500
//        return response.IsSuccessStatusCode;
//    }

//    public async Task<List<MessageModel>> GetbyUserId(string Id)
//    {
//        var client = _httpClientFactory.CreateClient();
//        client.BaseAddress = new Uri(_configuration["BaseAddress"]);

//        var response = await client.GetAsync($"/api/Message/{Id}");
//        var body = await response.Content.ReadAsStringAsync();
//        var user = JsonConvert.DeserializeObject<List<MessageModel>>(body);
//        return user;
//    }
//}