using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using WebApp1.Repository;

namespace WebApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Setting Web app
            var builder = WebApplication.CreateBuilder(args);//DEfault setting

            // Add services to the container.//Day8
            //Built in service and already register
            //Built in service need to register
            builder.Services.AddControllersWithViews();
            //register options ,StepsContext
            builder.Services.AddDbContext<StepsContext>(dbContextOptionBuilder => {
                dbContextOptionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));  
            });

            //Cusotm Service and Need To Register
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IService, Service>();//create object per request
            //Create Web app
            var app = builder.Build();

            // Configure the HTTP request pipeline. middleware Day2
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
            
            //run web app
            app.Run();
        }
    }
}
