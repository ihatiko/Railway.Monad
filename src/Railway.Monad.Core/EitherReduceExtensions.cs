using System;


namespace Railway.Monad.Core
{
    public static class EitherReduceExtensions
    {
        public static TNewResult Reduce<TNewResult, TResult, TError>(this Either<TResult, TError> either, Func<TResult, TNewResult> newResultProjection, Func<TError, TNewResult> newErrorProjection)
        {
            return either.IsLeft ? newResultProjection(either.Result) : newErrorProjection(either.Error);
        }

        public static TNewResult ReduceRight<TNewResult, TResult, TError>(this Either<TResult, TError> either, Func<TResult, TNewResult> newResultProjection)
        {
            return newResultProjection(either.Result);
        }

        public static TNewResult ReduceLeft<TNewResult, TResult, TError>(this Either<TResult, TError> either, Func<TError, TNewResult> newErrorProjection)
        {
            return newErrorProjection(either.Error);
        }
    }
}
