using System.Linq.Expressions;

namespace Infrastructure.Interfaces.DataAccess
{
    public class EfFunctionsExpander : ExpressionVisitor
    {
        public static IEfFunctions EfFunctions { get; set; }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Like")
            {
                return EfFunctions.Like(node);
            }

            return base.VisitMethodCall(node);
        }
    }
}
