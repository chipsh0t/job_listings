using JobListingsDAL.Repositories;
using JobListingsDAL.Repositories.Contracts;
using JobListingsDAL.UnitOfWork;
using JobListingsDAL.UnitOfWork.Contracts;
using JobListingsBusiness.Services;
using JobListingsBusiness.Services.Contracts;
using JobListingsDAL.Context;
using Microsoft.EntityFrameworkCore;
using JobListingsShared.Services;
using JobListingsShared.Services.Contracts;
//using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IJobsRepository, JobsRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJobsService, JobsService>();
builder.Services.AddScoped<ILookupService, LookupService>();

//adding db context
builder.Services.AddDbContext<JobListingsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:JobListingsDbConnection"], b=>b.MigrationsAssembly("JobListingsWeb"));
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
