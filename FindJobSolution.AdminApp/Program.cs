using FindJobSolution.APItotwoweb.API;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
// Add services to the container.
builder.Services.AddControllersWithViews();
//Add Transient
builder.Services.AddTransient<IUserAPI, UserAPI>();
builder.Services.AddTransient<IJobSeekerAPI, JobSeekerAPI>();
builder.Services.AddTransient<IRecuiterAPI, RecuiterAPI>();
builder.Services.AddTransient<ISkillAPI, SkillAPI>();
builder.Services.AddTransient<IRoleApi, RoleAPI>();
builder.Services.AddTransient<IJobAPI, JobAPI>();
builder.Services.AddTransient<IReportAPI, ReportAPI>();
// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    //options.Cookie.HttpOnly = true;
    //options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/User/Forbidden/";
    });

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

app.Run();