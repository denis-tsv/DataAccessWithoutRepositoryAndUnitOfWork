using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.MsSql;
using EntityFrameworkCore.CommonTools;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace ConsoleHost
{
    class Program
    {
        class CurrentUserServiceServiceStub : ICurrentUserService
        {
            private readonly int? _userId;
            private readonly bool _isAuthentificated;

            public CurrentUserServiceServiceStub(int? userId, bool isAuthentificated)
            {
                _userId = userId;
                _isAuthentificated = isAuthentificated;
            }

            public int? UserId => _userId;

            public bool IsAuthenticated => _isAuthentificated;
        }

        static async Task Main(string[] args)
        {
            EfFunctionsExpander.EfFunctions = new MsSqlEfFunctions();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Data Source=.;Initial Catalog=NoRepository;Integrated Security=True")
                .Options;
            var context = new AppDbContext(options, new CurrentUserServiceServiceStub(1, true));

            var res = await context.Products
                .AsVisitable(new EfFunctionsExpander())
                .AsNoTracking()
                //.Where(Product.AvailableSpec)
                //.Where(x => EF.Functions.Like(x.Name, "a%"))
                .Where(x => EfFunctions.Like(x.Name, "%1"))
                .ToListAsync()
                ;

            var res1 = await context.Products
                    .AsVisitable(new EfFunctionsExpander())
                    .Where(x => EfFunctions.Like(x.Name, "P%"))
                    .ToListAsync()
                ;
            var res2 = await context.Products
                    .AsVisitable(new EfFunctionsExpander())
                    .Where(x => EfFunctions.Like(x.Name, "%ro%"))
                    .ToListAsync()
                ;
            var re3s = await context.Products
                    .AsVisitable(new EfFunctionsExpander())
                    .Where(x => EfFunctions.Like(x.Name, "Prod1"))
                    .ToListAsync()
                ;

            int t = 0;
        }
    }
}
