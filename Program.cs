using Microsoft.EntityFrameworkCore;
using Umbraco.Data;
using UmbracoBlog.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
builder.Services.AddUmbracoDbContext<ApplicationDbContext>(options =>
{
	//Directory.CreateDirectory(ApplicationDataPath);
    options.UseSqlite(config.GetConnectionString("umbracoDbDSN"));
	//options.AddInterceptors(serviceProvider.GetRequiredService<DatabaseConnectionInterceptor>());
});
//.AddPooledDbContextFactory<DatabaseContext>(options => { });
//services.AddHostedService<DatabaseMigrationService>();

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>();

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddDeliveryApi()
    .Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        //u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();