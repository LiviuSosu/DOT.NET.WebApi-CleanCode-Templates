using Common;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Persistance;
using Microsoft.EntityFrameworkCore;
using Persistance.Repository;
using Infrastructure;

namespace WebApi
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.Add(new ServiceDescriptor(typeof(Common.IConfiguration), typeof(Configuration), ServiceLifetime.Singleton));
            services.AddSingleton<Common.IConfiguration, Configuration>();
            services.Add(new ServiceDescriptor(typeof(ILogger), typeof(Logger), ServiceLifetime.Singleton));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<AppDatabaseContext>(options =>
            options.UseSqlServer("Data Source = DESKTOP-M80MDUC;Initial Catalog=TestDb;Integrated Security = True;"));

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            //services.AddMediatR(typeof(BaseHandler<,>).GetTypeInfo().Assembly);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
