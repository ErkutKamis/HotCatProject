using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Hc.Application.Service.Interface;
using HC.Application.Extensions;
using HC.Application.InversionOfControl;
using HC.Application.Service.Concrete;
using HC.Domain.Concrete;
using HC.Domain.Repositories.EntityTypeRepository;
using HC.Infrastructure.Context;
using HC.Infrastructure.DependencyResolver;
using HC.Infrastructure.Repositories.Concrete;
using HC.Infrastructure.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HC_DbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddIdentity<AppUser, AppUserRole>().AddEntityFrameworkStores<HC_DbContext>().AddDefaultTokenProviders();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddDependencyResolver((IConfiguration)builder.Configuration, new ICoreModule[]
{
    new CoreModule()
});

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new DependencyResolver()));
//Session
builder.Services.AddSession(x =>
{

});



var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(x => {

    x.MapControllerRoute(
        name: "MyArea",
        pattern: "{area:exists}/{Controller=home}/{Action=index}/{id?}" //Area Route
    );

    x.MapControllerRoute(
        name: "default",
        pattern: "{Controller=Home}/{Action=Index}/{id?}" //Default Route
    );
});

app.Run();
