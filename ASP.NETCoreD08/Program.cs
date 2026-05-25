using ASP.NETCoreD08.Data.Context;
using ASP.NETCoreD08.Helper;
using ASP.NETCoreD08.Respositories.DepartmentRepository;
using ASP.NETCoreD08.Respositories.EmployeeRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ASP.NETCoreD08
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a new instance of the WebApplicationBuilder class,
            // which is used to configure and build the web application
            // Create and configure the foundation of ASP.NET Core MVC application
            // Create a WebApplicationBuilder Object
            // Builder is responsible for configuring application before it is built and run
            // Sets up default congiguration, logging, and dependency injection services
            // Load Settings from appsettings.json and environment variables
            // Configure Dependency Injection (DI) container
            // Configure web server (Kestrel) and other services
            // Prepare the application to handle HTTP requests and responses
            // Prepare middleware pipeline and routing for the application
            var builder = WebApplication.CreateBuilder(args);

            #region Services Container
            // Add services to the container.
            // 1- Built-in Services and Already configured (in IOC Container) by ASP.NET Core (e.g. Logging, Configuration, Kestrel, etc.)
            // 2- Built-in Services but not configured by ASP.NET Core (e.g. MVC, Razor Pages, etc.) "AddSession", "AddDbContext"
            // 3- Custom Services that you create and want to use in your application (e.g. IPrint, IEmailService, etc.)

            // Service Provider is a container that manages the creation and lifetime of services
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                // Read From appsettings.json file then pass the connection string to the UseSqlServer method : base
                options.UseSqlServer(builder.Configuration.GetConnectionString("ASPNETCoreD08"));
            });


            // Register the IPrint service with its implementation PrintV01 in the service container
            builder.Services.AddTransient<IPrint, PrintV01>();
            //builder.Services.AddScoped<IPrint, PrintV02>();
            //builder.Services.AddScoped<IPrint, PrintV02>();
            //builder.Services.AddScoped<IPrint, PrintV03>();

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            #endregion

            // Create the actual web application using all services and
            // configurations that were added to the builder.
            // ASP.NET Core creates the WebApplication
            // Creates the Service Provider(DI Container)
            // Prepares middleware pipeline
            // Prepares routing system
            // Finalizes configuration
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            // Start the web server and keep listening for HTTP requests.
            // When this line executes:
            // Kestrel web server starts
            // Application begins listening on ports
            // Browser requests can reach your app
            app.Run();
        }
    }
}
