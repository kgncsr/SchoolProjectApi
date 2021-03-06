using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using School.Business.Abstract;
using School.Business.Concrete;
using School.DataAccess.Abstract;
using School.DataAccess.Concrete.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IStudentService, StudentManager>();
            services.AddSingleton<IStudentDal, StudentRepository>();
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "All Hotels Api";
                    doc.Info.Version = "1.0.13";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Ka?an Co?ar",
                        Email = "kagancosar@gmail.com"
                    };
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

