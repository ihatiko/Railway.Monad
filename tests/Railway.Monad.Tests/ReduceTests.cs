using Railway.Monad.Core;
using Xunit;

namespace Railway.Monad.Tests
{
    public class ReduceTests
    {
        [Fact]
        public void Reduce_Result()
        {
            var result = int.MaxValue
                 .ToEither<int, string>()
                 .Reduce(item => int.MinValue, item => int.MaxValue);

            Assert.True(result == int.MinValue);
        }

        [Fact]
        public void Reduce_Right_Result()
        {
            var result = int.MaxValue
                 .ToEither<int, string>()
                 .ReduceRight(item => int.MinValue);

            Assert.True(result == int.MinValue);
        }

        [Fact]
        public void Reduce_Error()
        {
            var result = string.Empty
                 .ToEither<int, string>()
                 .Reduce(item => int.MinValue, item => int.MaxValue);

            Assert.True(result == int.MaxValue);
        }

        [Fact]
        public void Reduce_Left_Error()
        {
            var result = string.Empty
                 .ToEither<int, string>()
                 .ReduceLeft(item => int.MaxValue);

            Assert.True(result == int.MaxValue);
        }
    }
}
