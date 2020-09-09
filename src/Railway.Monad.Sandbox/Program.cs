using System;

namespace Railway.Monad
{
    public struct Either<TResult, TError>
    {
        internal TResult Result;
        internal TError Error;
        
        public Either(TResult result)
        {
            Result = result;
            Error = default;
        }
        public Either(TError error)
        {
            Error = error;
            Result = default;
        }

        public static implicit operator Either<TResult, TError>(TResult result) => new Either<TResult, TError>(result);
        public static implicit operator Either<TResult, TError>(TError error) => new Either<TResult, TError>(error);
    }
    class Program
    {
        static void Main(string[] args)
        {
            Either<int, string> test = (10, "");
        }
    }
}
