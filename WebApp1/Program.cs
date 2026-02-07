using Microsoft.AspNetCore.Http;
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
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(45);
            });
            //Cusotm Service and Need To Register
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IService, Service>();//create object per request
            //Create Web app
            var app = builder.Build();
            #region Custom PipleLine
            //inline Midleware
            //app.Use(async (httpcontext,nextMidleware) => {
            //    await  httpcontext.Response.WriteAsync("1- Middleware 1\n");//<--1
            //    //call next
            //    await  nextMidleware.Invoke();//<--2
            //    await httpcontext.Response.WriteAsync("1-1 Middleware 1-1\n");//<--7
            //});
            //app.Use(async (httpcontext, nextMidleware) => {
            //    await httpcontext.Response.WriteAsync("2- Middleware 2\n");//<--3
            //    //call next
            //    await nextMidleware.Invoke();//<--4
            //    await httpcontext.Response.WriteAsync("2-2 Middleware 2-2\n");//<--6

            //});
            //app.Run(async(httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3- Terminate\n");//<--5

            //});
          
            #endregion

            // Configure the HTTP request pipeline. middleware Day2
            #region built in middlewares
              if (!app.Environment.IsDevelopment())
              {
                  app.UseExceptionHandler("/Home/Error");
              }
              app.UseStaticFiles();//hanadel wwwroot

              app.UseRouting();
                app.UseSession();
                app.UseAuthorization();

              app.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
              
            #endregion
            //run web app
            app.Run();
        }
    }
}
