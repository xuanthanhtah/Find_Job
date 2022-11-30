using FindJobSolution.APItotwoweb.API;
using FindJobSolution.WebApp.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddHttpClient();

//Add Transient
builder.Services.AddTransient<IUserAPI, UserAPI>();
builder.Services.AddTransient<IJobInformationApi, JobInformationAPI>();
builder.Services.AddTransient<IRecuiterAPI, RecuiterAPI>();
builder.Services.AddTransient<IJobAPI, JobAPI>();
builder.Services.AddTransient<IJobSeekerAPI, JobSeekerAPI>();
builder.Services.AddTransient<IApplyJobAPI, ApplyJobAPI>();
builder.Services.AddTransient<ISaveJobAPI, SaveJobAPI>();
builder.Services.AddTransient<IJobSeekerOldCompanyAPI, JobSeekerOldCompanyAPI>();
//builder.Services.AddTransient<IMessageAPI, MessageAPI>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    //options.Cookie.HttpOnly = true;
    //options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/UserJobSeeker/Login";
        options.AccessDeniedPath = "/User/Forbidden/";
    });

builder.Services.Configure<IdentityOptions>(options =>
    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

builder.Services.AddHttpContextAccessor();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.Run();