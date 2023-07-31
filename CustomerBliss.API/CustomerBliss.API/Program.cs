using CustomerBliss.Domain.UseCases.Extensions;
using CustomerBliss.Infrastructure.DependencyInjection;
using CustomerBliss.Infrastructure.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using CustomerBliss.Domain.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.ReferenceHandler = null;
                    options.UseDateOnlyTimeOnlyStringConverters();
                });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Customer Bliss API",
            Version = "v1"
        }
     );

    c.UseDateOnlyTimeOnlyStringConverters();
});

builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});


//Services
builder.Services.AddDbContext<CustomerBlissContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        b => b.MigrationsAssembly("CustomerBliss.Infrastructure"));
});

builder.Services.AddUseCases()
                .AddServices()
                .AddRepositories();

builder.Logging.ClearProviders().AddConsole();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
