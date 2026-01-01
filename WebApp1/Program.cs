namespace WebApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Setting Web app
            var builder = WebApplication.CreateBuilder(args);//DEfault setting

            // Add services to the container.//Day8
            builder.Services.AddControllersWithViews();
            
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
