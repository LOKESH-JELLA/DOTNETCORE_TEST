using TS_LRS.Repositories.DbConnections;
using TS_LRS.Repositories.DbConnections.Interfaces;
using TS_LRS.Repositories.LookUp;
using TS_LRS.Repositories.LookUp.Interfaces;
using TS_LRS.Repositories.Officer;
using TS_LRS.Repositories.Officer.Interfaces;
using TS_LRS.Repositories.Website;
using TS_LRS.Repositories.Website.Interfaces;
using TS_LRS.Services.LookUp;
using TS_LRS.Services.LookUp.Interfaces;
using TS_LRS.Services.Officer;
using TS_LRS.Services.Officer.Interfaces;
using TS_LRS.Services.Website;
using TS_LRS.Services.Website.Interfaces;
using TS_LRS.Utilities.NLogs;
using TS_LRS.Utilities.NLogs.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(360);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddControllersWithViews().AddRazorOptions(options => { options.ViewLocationFormats.Add("/{0}.cshtml"); });
// Add services to the container.
builder.Services.AddControllersWithViews();

//NLogging
builder.Services.AddSingleton<ILog, NLogger>();

//Dapper DB connection
builder.Services.AddSingleton<IDapperContext, DapperContext>();

// Website Service
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IHomeRepo, HomeRepo>();

// Office Login Service
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILoginRepo, LoginRepo>();

//LookUp  Service
builder.Services.AddScoped<ILookUpService, LookUpService>();
builder.Services.AddScoped<ILookUpRepo, LookUpRepo>();


builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var env = hostingContext.HostingEnvironment;
    config
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Load the common appsettings.json file
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true); // Load the environment-specific appsettings file

    if (env.IsDevelopment())
    {
        // Additional configuration for the Development environment
        config.AddUserSecrets<Program>();
    }
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();