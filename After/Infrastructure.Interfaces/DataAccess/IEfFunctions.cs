using System.Linq.Expressions;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IEfFunctions
    {
        Expression Like(MethodCallExpression node);
    }
}
