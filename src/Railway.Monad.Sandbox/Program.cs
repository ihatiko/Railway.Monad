using System;
using Railway.Monad.Core;

namespace Railway.Monad
{
    class Program
    {
        static void Main(string[] args)
        {
            Either<int, string> test = (10, "");
            var a = from x in test.Select(item => item.MapRight(item => 10f))
                    select x;
        }
    }
}
