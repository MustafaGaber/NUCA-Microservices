using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NUCA.Projects.Data;
using NUCA.Projects.Shared.Constants;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
var requireAuthenticatedUserPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser().Build();
builder.Services.AddControllersWithViews(configure =>
{
    configure.Filters.Add(new AuthorizeFilter(requireAuthenticatedUserPolicy));
});
builder.Services.Configure<RazorViewEngineOptions>(o =>
{
    o.ViewLocationFormats.Clear();
    o.ViewLocationFormats.Add("/Api/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
    o.ViewLocationFormats.Add("/Api/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddJsReport(new LocalReporting().UseBinary(JsReportBinary.GetBinary()).KillRunningJsReportProcesses()
.AsUtility().Create());
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.Scan(scan =>
{
    scan
    .FromEntryAssembly()
    //.FromApplicationDependencies(d => d.FullName.StartsWith("NUCA.Projects"))
    .AddClasses(publicOnly: true)
    .AsMatchingInterface((service, filter) =>
        filter.Where(implementation => implementation.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)))
    .WithTransientLifetime();
});
//builder.Services.AddDbContext<ProjectsDatabaseContext>(options => options.UseSqlite("Data Source=projects.db"));
builder.Services.AddDbContext<ProjectsDatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectsDatabase")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = "https://localhost:5010";
    options.Audience = "projects";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ProjectsUser", policy =>
    {
        policy.RequireClaim("permission", Permissions.Projects);
    });
    options.AddPolicy("ExecutionUser", policy =>
    {
        policy.RequireClaim("permission", Permissions.Execution);
    });
    options.AddPolicy("TechnicalOfficeUser", policy =>
    {
        policy.RequireClaim("permission", Permissions.TechnicalOffice);
    });
    options.AddPolicy("RevisionUser", policy =>
    {
        policy.RequireClaim("permission", Permissions.Revision);
    });
    options.AddPolicy("AccountingUser", policy =>
    {
        policy.RequireClaim("permission", Permissions.Accounting);
    });
    options.AddPolicy("FinanceUser", policy =>
    {
        policy.RequireClaim("permission", new string[] { Permissions.Revision, Permissions.Accounting });
    });
});
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    // enables immediate logout, after updating the user's stat.
    options.ValidationInterval = TimeSpan.Zero;
});
var app = builder.Build();

var defaultCulture = new CultureInfo("ar-EG");
defaultCulture.NumberFormat = new NumberFormatInfo()
{
    NativeDigits = new string[] { "٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" },
    DigitSubstitution = DigitShapes.NativeNational,
};
Thread.CurrentThread.CurrentCulture = defaultCulture;
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture },
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


