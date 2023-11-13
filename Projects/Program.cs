using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Data;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllersWithViews();
builder.Services.Configure<RazorViewEngineOptions>(o =>
{
    o.ViewLocationFormats.Clear();
    o.ViewLocationFormats.Add("/Api/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
    o.ViewLocationFormats.Add("/Api/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddJsReport(new LocalReporting().UseBinary(JsReportBinary.GetBinary()).KillRunningJsReportProcesses().AsUtility().Create());
builder.Services.AddSwaggerGen();
builder.Services.Scan(scan => {
    scan
    .FromEntryAssembly()
    //.FromApplicationDependencies(d => d.FullName.StartsWith("NUCA.Projects"))
    .AddClasses(publicOnly: true)
    .AsMatchingInterface((service, filter) =>
        filter.Where(implementation => implementation.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)))
    .WithTransientLifetime();
});
builder.Services.AddDbContext<ProjectsDatabaseContext>(options => options.UseSqlite("Data Source=projects.db"));

var app = builder.Build();

var defaultCulture = new CultureInfo("ar-EG");
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
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

app.MapControllers();

app.Run();


