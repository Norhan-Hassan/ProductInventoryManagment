using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductManagment.Models;
using ProductManagment.Services;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace ProductManagment
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            
            var mainForm = host.Services.GetRequiredService<Form1>();


            Application.Run(mainForm);
        }
        public static IHostBuilder CreateHostBuilder() =>
           Host.CreateDefaultBuilder()
               .ConfigureLogging(logging =>
                 {
                     logging.ClearProviders();
                     logging.AddConsole();
                     logging.AddDebug();
                 })
               .ConfigureServices((context, services) =>
               {
                   var connectionString = "Data Source=.;Initial Catalog=ProductDB;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
                   services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(connectionString));
                   services.AddScoped<ICategoryService, CategoryService>();
                   services.AddScoped<IProductService, ProductService>();
                   
                   services.AddScoped<Form1>(provider =>
                   {
                       var categoryservice = provider.GetRequiredService<ICategoryService>();
                       var productservice = provider.GetRequiredService<IProductService>();
                       return new Form1(categoryservice,productservice);
                   });
               });
    }
}