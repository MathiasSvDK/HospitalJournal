using BlazorIdentityServerTest.Areas.Identity;
using BlazorIdentityServerTest.Data;
using Client.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using BlazorIdentityServerTest.Services;
using BlazorIdentityServerTest.Models;
using CurrieTechnologies.Razor.SweetAlert2;
using Contabo.ObjectStorage.S3;
using BlazorIdentityServerTest.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.34-mariadb")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();



var accessKey = "4f6ecc8ce7f94f0dba27ec2e834a9f01";
var secretKey = "f1696f181d37c15b43fcb2676ecfc4ec";
var s3TenantId = "67b15f74e4204ae2b25797487790bb79";
var bucketName = "skole";

ContaboS3Settings.Configure(accessKey, secretKey, s3TenantId, ContaboS3RegionEndpoint.EU2, bucketName);



builder.Services.AddDefaultIdentity<ApplicationUser>()
    //.AddSignInManager<CustomSignInManager>()
    .AddEntityFrameworkStores<ApplicationDbContext>();




builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IHospitalService, HospitalService>();
builder.Services.AddScoped<IJournalService, JournalService>();
builder.Services.AddScoped<ISwalService, SwalService>();
builder.Services.AddScoped<ILogsService, LogsService>();
builder.Services.AddDbContext<HospitalContext>();
builder.Services.AddDbContext<JournalContext>();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<AttachmentService>();
builder.Services.AddSweetAlert2();


builder.Services.Configure<IdentityServerSettings>(builder.Configuration.GetSection("IdentityServerSettings"));
builder.Services.AddScoped<ITokenService, TokenService>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddOpenIdConnect(
 OpenIdConnectDefaults.AuthenticationScheme,
     options =>
        {
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
            options.Authority = builder.Configuration["InteractiveServiceSettings:AuthorityUrl"];
            options.ClientId = builder.Configuration["InteractiveServiceSettings:ClientId"];
            options.ClientSecret = builder.Configuration["InteractiveServiceSettings:ClientSecret"];
            options.RequireHttpsMetadata = false;
            options.ResponseType = "code";
            options.SaveTokens = true;
            options.GetClaimsFromUserInfoEndpoint = true;
        }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
