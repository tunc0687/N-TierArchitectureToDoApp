using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_TierArchitectureToDoApp.Data.WorksRepositories;
using N_TierArchitectureToDoApp.DataDomain.DbContexts;
using N_TierArchitectureToDoApp.DataDomain.EfCoreUnitOfWork;
using N_TierArchitectureToDoApp.Service.Mappings;
using N_TierArchitectureToDoApp.Service.WorksServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ToDoAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString")), ServiceLifetime.Scoped);

var configuration = new MapperConfiguration(opt =>
{
    opt.AddProfile(new WorkProfile());
});

var mapper = configuration.CreateMapper();

builder.Services.AddSingleton<IMapper>(mapper);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IWorksService, WorksService>();
builder.Services.AddScoped<IWorksRepository, WorksRepository>();

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

app.MapDefaultControllerRoute();

app.Run();
