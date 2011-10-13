using System;
using Moq.Language.Flow;
using Moq;
using System.Linq.Expressions;
namespace Pong.Test
{
    public static class MockExtensions
    {
        public static ISetup<T> Mocks<T>(this Mock<T> mock, Expression<Action<T>> action) where T : class
        {
            var setup = mock.Setup(action);
            setup.Verifiable();
            return setup;
        }

        public static ISetup<T, TResult> Mocks<T, TResult>(this Mock<T> mock, Expression<Func<T, TResult>> func) where T : class
        {
            var setup = mock.Setup(func);
            setup.Verifiable();
            return setup;
        }

        public static ISetup<T> Stubs<T>(this Mock<T> mock, Expression<Action<T>> action) where T : class
        {
            return mock.Setup(action);
        }

        public static ISetup<T, TResult> Stubs<T, TResult>(this Mock<T> mock, Expression<Func<T, TResult>> func) where T : class
        {
            return mock.Setup(func);
        }
    }
}

