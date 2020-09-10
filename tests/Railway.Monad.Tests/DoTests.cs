using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Railway.Monad.Core;
using Xunit;

namespace Railway.Monad.Tests
{
    public class DoTests
    {
        [Fact]
        public void Do_Result()
        {
            var resultValue = int.MinValue;
            var errorValue = string.Empty;
            int.MaxValue
                 .ToEither<int, string>()
                 .Do(item => resultValue = item, item => errorValue = item);

            Assert.True(errorValue == string.Empty);
            Assert.True(resultValue == int.MaxValue);
        }
        
        [Fact]
        public void Do_Right_Result()
        {
            var resultValue = int.MinValue;
            int.MaxValue
                 .ToEither<int, string>()
                 .DoRight(item => resultValue = item);

            Assert.True(resultValue == int.MaxValue);
        }


        [Fact]
        public void Do_Error()
        {
            var resultValue = int.MinValue;
            var errorValue = string.Empty;
            int.MaxValue.ToString()
                 .ToEither<int, string>()
                 .Do(item => resultValue = item, item => errorValue = item);

            Assert.True(errorValue == int.MaxValue.ToString());
            Assert.True(resultValue == int.MinValue);
        }

        [Fact]
        public void Do_Left_Error()
        {
            var errorValue = string.Empty;
            int.MaxValue.ToString()
                 .ToEither<int, string>()
                 .DoLeft(item => errorValue = item);

            Assert.True(errorValue == int.MaxValue.ToString());
        }
    }
}
