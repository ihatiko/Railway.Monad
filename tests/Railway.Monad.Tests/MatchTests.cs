using Railway.Monad.Core;
using Xunit;

namespace Railway.Monad.Tests
{
    public class MatchTests
    {
        [Fact]
        public void Match_Result()
        {
            var result = int.MaxValue
                 .ToEither<int, string>()
                 .Match(item => int.MinValue, item => int.MaxValue);

            Assert.True(result == int.MinValue);
        }

        [Fact]
        public void Match_Error()
        {
            var result = string.Empty
                 .ToEither<int, string>()
                 .Match(item => int.MinValue, item => int.MaxValue);

            Assert.True(result == int.MaxValue);
        }
    }
}
