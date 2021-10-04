using LI.BookService.Bll.Service;
using LI.BookService.Core.Interfaces;
using LI.BookService.DAL;
using LI.BookService.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LI.BookService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            string connection = Configuration.GetConnectionString("DefaultConnection");
            // устанавливаем контекст данных
            services.AddDbContext<BookServiceDbContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IBookRequestService, BookRequestService>();
            services.AddScoped<IRequestBookRepository, RequestBookRepository>();
            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // определение маршрутов
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=BookRequest}/{action=Index}/{id?}");
            });
        }
    }
}
