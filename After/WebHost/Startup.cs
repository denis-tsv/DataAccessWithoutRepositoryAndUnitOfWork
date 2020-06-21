using Autofac;
using AutoMapper;
using DataAccess.MsSql;
using Handlers.Products.Queries.GetProductsByName;
using Handlers.SaveChangesPostProcessor;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.Services;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using WebHost.Services;

namespace WebHost
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
            services.AddControllers();
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddScoped<IDbContext>(factory => factory.GetRequiredService<AppDbContext>());
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection")));

            services.AddScoped<IDbContextPostProcessor>(factory => factory.GetRequiredService<AppDbContextPostProcessor>());
            services.AddDbContext<AppDbContextPostProcessor>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection")));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            EfFunctionsExpander.EfFunctions = new MsSqlEfFunctions();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddMediatR(typeof(GetProductsByNameQuery).Assembly);

            builder.RegisterGeneric(typeof(SaveChangesRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
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
