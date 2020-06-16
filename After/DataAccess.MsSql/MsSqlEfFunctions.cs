using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.MsSql
{
    public class MsSqlEfFunctions : IEfFunctions
    {
        public Expression Like(MethodCallExpression node)
        {
            //var method = typeof(DbFunctionsExtensions).GetMethods()
            //    .Where(x => x.Name == "Like")
            //    .First();
            //var ext = Expression.Variable(typeof(DbFunctions));
            //var res = Expression.Call(null, method, ext, node.Arguments[0], node.Arguments[1]);
            //return res;

            var str = node.Arguments.First();
            var pattern = (string) ((ConstantExpression) node.Arguments.Last()).Value;
            var toLowerMethod = typeof(string).GetMethods().First(x => x.Name == "ToLower");
            string methodName;
            switch (pattern)
            {
                case var p when p.StartsWith('%') && p.EndsWith('%'):
                    methodName = "Contains";
                    break;
                case var p when p.StartsWith('%'):
                    methodName = "EndsWith";
                    break;
                case var p when p.EndsWith('%'):
                    methodName = "StartsWith";
                    break;
                default: 
                    methodName = "Equals";
                    break;
            }
            var endsWithMethod = typeof(string).GetMethods().First(x => x.Name == methodName);
            var res = Expression.Call(str, toLowerMethod);
            var constExpr = Expression.Constant(pattern.Trim('%'));
            res = Expression.Call(res, endsWithMethod, constExpr);
            return res;
        }
    }
}
