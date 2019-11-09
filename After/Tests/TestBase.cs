using Infrastructure.Interfaces.QueryableHelpers;
using System;
using Xunit;

namespace Tests
{
    public class TestBase
    {
        static TestBase()
        {
            QueryableHelper.QueryableExecutor = new InMemoryQueryableExecutor();
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
