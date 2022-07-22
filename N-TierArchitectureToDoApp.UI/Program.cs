using FluentValidation;
using Microsoft.EntityFrameworkCore;
using N_TierArchitectureToDoApp.Data.WorksRepositories;
using N_TierArchitectureToDoApp.DataDomain.DbContexts;
using N_TierArchitectureToDoApp.DataDomain.EfCoreUnitOfWork;
using N_TierArchitectureToDoApp.Service.ValidationRules.FluentValidation;
using N_TierArchitectureToDoApp.Service.WorksServices;
using N_TierArchitectureToDoApp.UI.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
;

builder.Services.AddDbContext<ToDoAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString")), ServiceLifetime.Scoped);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IWorksService, WorksService>();
builder.Services.AddScoped<IWorksRepository, WorksRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddTransient<IValidator<WorksAddRequest>, WorksAddRequestValidator>();
//builder.Services.AddTransient<IValidator<WorksUpdateRequest>, WorksUpdateRequestValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<WorksAddRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapDefaultControllerRoute();

app.Run();
