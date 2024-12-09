using EjournalBack.Application.Helpers.AutoMapper;
using EjournalBack.Infrastructure.Configurations;
using EjournalBack.Infrastructure.Data;
using EjournalBack.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using Serilog;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using Microsoft.EntityFrameworkCore;
using EjournalBack.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();
    

builder.Host.UseSerilog(logger, dispose: true);

builder.Services.AddCors();

builder.Services.AddControllers();

builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(config.GetSection(nameof(DatabaseSettings)));

builder.Services.AddDbContext<JournalDbContext>((serviceProvider, options) =>
{
    var databaseSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    options.UseNpgsql(databaseSettings.ConnectionString)
        .LogTo(message => Log.Error(message), LogLevel.Error);
}
);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IGroupRepository, GroupRepository>();

builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Urls.Add("https://localhost:5003");

app.Run();