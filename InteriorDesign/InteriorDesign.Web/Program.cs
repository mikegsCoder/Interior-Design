using InteriorDesign.Infrastricture.Data;
using InteriorDesign.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InteriorDesign.Web.InitialSeed;
using SignalRChat.Hubs;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Core.Constants;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddMemoryCache();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(config =>
{
    config.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedEmail");
    config.Tokens.ProviderMap.Add("CustomEmailConfirmation",
        new TokenProviderDescriptor(
            typeof(CustomEmailConfirmationTokenProvider<ApplicationUser>)));
    config.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(builder.Configuration.GetValue<int>("Identity:DefaultLockoutTimeSpan"));
    options.Lockout.MaxFailedAccessAttempts = builder.Configuration.GetValue<int>("Identity:MaxFailedAccessAttempts");
    options.Lockout.AllowedForNewUsers = builder.Configuration.GetValue<bool>("Identity:AllowedForNewUsers");

    options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:RequireDigit");
    options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:RequireLowercase");
    options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:RequireNonAlphanumeric");
    options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:RequireUppercase");
    options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:RequiredLength");
    options.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("Identity:RequiredUniqueChars");
});

builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.AppId = builder.Configuration["Authentication:Facebook:AppId"];
        options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireEmployeeOnly", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole(RoleConstants.Employee) &&
            !context.User.IsInRole(RoleConstants.Administrator)));
});

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });

builder.Services.AddSignalR();

builder.Services.AddApplicationServices();

builder.Services.AddResponseCaching();

builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(builder.Configuration.GetValue<int>("ApplicationCookie:ExpireTimeSpan"));
    options.SlidingExpiration = builder.Configuration.GetValue<bool>("ApplicationCookie:SlidingExpiration");
});

// Add cookie consent policy
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => builder.Configuration.GetValue<bool>("CookiePolicyOptions:CheckConsentNeeded");
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
    options.TokenLifespan = TimeSpan.FromDays(builder.Configuration.GetValue<int>("DataProtectionTokenProvider:TokenLifespan")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseDeveloperExceptionPage();
app.UseMigrationsEndPoint();
}
else
{
app.UseExceptionHandler("/Home/Error");
app.UseHsts();
}

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404)
    {
    context.Request.Path = "/Home/NotFound404";
    await next();
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chathub");

app.MapRazorPages();

await Seeder.SeedAsync(app);

app.UseResponseCaching();

app.Run();

public partial class Program { }