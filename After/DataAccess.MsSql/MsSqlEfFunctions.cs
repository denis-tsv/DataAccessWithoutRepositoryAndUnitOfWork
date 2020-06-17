using System.Linq;
using System.Linq.Expressions;
using Infrastructure.Interfaces.DataAccess;

namespace DataAccess.MsSql
{
    public class MsSqlEfFunctions : IEfFunctions
    {
        public Expression Like(MethodCallExpression node)
        {
            //Postgres
            //var method = typeof(DbFunctionsExtensions).GetMethods()
            //    .Where(x => x.Name == "Like")
            //    .First();
            //var ext = Expression.Variable(typeof(DbFunctions));
            //var res = Expression.Call(null, method, ext, node.Arguments[0], node.Arguments[1]);
            //return res;

            //MS SQL
            var str = node.Arguments.First();
            var pattern = (string) ((ConstantExpression) node.Arguments.Last()).Value;
            var toLowerMethod = typeof(string).GetMethods().First(x => x.Name == "ToLower");
            string stringMethodName = GetMethodName(pattern);
            var endsWithMethod = typeof(string).GetMethods().First(x => x.Name == stringMethodName);
            var res = Expression.Call(str, toLowerMethod);
            var constExpr = Expression.Constant(pattern.Trim('%'));
            res = Expression.Call(res, endsWithMethod, constExpr);
            return res;

            string GetMethodName(string ptrn)
            {
                switch (ptrn)
                {
                    case var p when p.StartsWith('%') && p.EndsWith('%'):
                        return "Contains";
                    case var p when p.StartsWith('%'):
                        return "EndsWith";
                    case var p when p.EndsWith('%'):
                        return "StartsWith";
                    default:
                        return "Equals";
                }
            }
        }
    }
}
