using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Test.TeqBall.Host.Application.Services;
using Test.TeqBall.Host.Application.Validators;
using Test.TeqBall.Host.Infrastructure;
using Test.TeqBall.Host.Infrastructure.Repositories;

namespace Test.TeqBall.Host
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
            services.AddControllers()
                // this will be scoped
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AppointmentValidator>())
                .AddNewtonsoftJson();

            services.AddHealthChecks();

            services.Configure<ConnectionOptions>(Configuration.GetSection("Connections"));

            services.AddSwagger();

            services.AddSingleton<IAppointmentRepository, MongoDbRepository>();
            services.AddSingleton<IAppointmentService, AppointmentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
