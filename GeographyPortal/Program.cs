using GeographyPortal.Areas.Identity.Data;
using GeographyPortal.Models;
using GeographyPortal.Repositories;
using GeographyPortal.Repositories.Impl;
using GeographyPortal.Services;
using GeographyPortal.Services.Impl;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'AplicationDBContextConnection' not found.");

builder.Services.AddDbContext<AplicationDBContext>(options =>
    options.UseNpgsql(connectionString));
//Как поднимается сервис паблишера и ребита поменять значнеие на true для подтвреждения почты
builder.Services.AddDefaultIdentity<GeographyPortalUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AplicationDBContext>();

// Add services to the container.
builder.Services.Configure<PortalGeographyMongoDBSettings>(
    builder.Configuration.GetSection("PortalGeographyMongoDB"));

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeographyPortal API", Version = "v0.1" });
});


builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();

initRabbitMQ();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "My API V1");
});

app.MapRazorPages();

app.Run();


void initRabbitMQ()
{
    builder.Services.AddMassTransit(x =>
    {

        x.SetKebabCaseEndpointNameFormatter();

        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host("localhost", "/", h =>
            {
                h.Username("guest");
                h.Password("guest");
            });

            cfg.ConfigureEndpoints(context);
        });
    });
}