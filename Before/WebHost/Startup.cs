using AutoMapper;
using DataAccess.MsSql;
using DataAccess.MsSql.DataAccess;
using DataAccess.MsSql.DataAccess.NoRepository;
using Entities;
using Handlers.Products.Queries.GetNewProducts;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.DataAccess.NoRepository;
using Infrastructure.Interfaces.QueryableHelpers;
using Infrastructure.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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

            services.AddScoped<ICurrentUserService, CurrentUserService>();
            
            var queryableExecutor = new EfQueryableExecutor();
            services.AddSingleton<IQueryableExecutor>(queryableExecutor);
            QueryableHelper.QueryableExecutor = queryableExecutor;

            services.AddScoped<IRepositoryUnitOfWork, RepositoryUnitOfWork>();
            services.AddScoped<INoRepositoryUnitOfWork, NoRepositoryUnitOfWork>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection")));
            
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders(); 

            services.AddMediatR(typeof(GetNewProductsQuery).Assembly);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
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
