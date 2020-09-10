using System;
using System.Collections.Generic;
using System.Text;
using Railway.Monad.Core;
using Xunit;

namespace Railway.Monad.Tests
{
    public class MapTests
    {
        [Fact]
        public void Map_Result()
        {
            var resultValue = string.Empty;
            var errorValue = int.MinValue;
            int.MaxValue
                 .ToEither<int, string>()
                 .Map(item => item.ToString(), item => int.MaxValue)
                 .Do(item => resultValue = item, item => errorValue = item);

            Assert.True(errorValue == int.MinValue);
            Assert.True(resultValue == int.MaxValue.ToString());
        }

        [Fact]
        public void Map_Error()
        {
            var resultValue = string.Empty;
            var errorValue = int.MinValue;
            int.MaxValue.ToString()
                 .ToEither<int, string>()
                 .Map(item => item.ToString(), item => int.MaxValue)
                 .Do(item => resultValue = item, item => errorValue = item);

            Assert.True(errorValue == int.MaxValue);
            Assert.True(resultValue == string.Empty);
        }

        [Fact]
        public void Map_Right()
        {
            var resultValue = string.Empty;
            int.MaxValue
                 .ToEither<int, string>()
                 .MapRight(item => item.ToString())
                 .DoRight(item => resultValue = item);

            Assert.True(resultValue == int.MaxValue.ToString());
        }


        [Fact]
        public void Map_Left()
        {
            var errorValue = string.Empty;
            int.MaxValue.ToString()
                 .ToEither<int, string>()
                 .MapLeft(item => item.ToString())
                 .DoLeft(item => errorValue = item);

            Assert.True(errorValue == int.MaxValue.ToString());
        }
    }
}
