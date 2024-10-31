using Microsoft.EntityFrameworkCore;
using UmbracoBlog.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddDeliveryApi()
    .Build();

WebApplication app = builder.Build();

// builder.Services.AddUmbracoEFCoreContext<ApplicationDbContext>(
//     config.GetConnectionString("umbracoDbDSN"),
//     config.GetConnectionStringProviderName("umbracoDbDSN")
// );

builder.Services.AddUmbracoDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(config.GetConnectionString("umbracoDbDSN"));
});

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>();

await app.BootUmbracoAsync();


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();