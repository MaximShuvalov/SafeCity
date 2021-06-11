using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SafeCity.EmailSender.IoC;
using SafeCity.Server.Db.Context;
using SafeCity.Server.Db.DI;

namespace SafeCity.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //string connectionDb = Configuration.GetConnectionString("ConnectionDb");
            string connectionDb = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:7070").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddMvc();
            
            services.AddControllers();
            services.AddDbContext<AppDbContext>(
                options => options.UseNpgsql(connectionDb)
            );
            services.AddDb();
            services.AddEmailSender();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();
            
            app.UseCors("ApiCorsPolicy");
            
            app.UseMvc();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}