using System;


namespace Railway.Monad.Core
{
    public static class EitherMapExtensions
    {
        public static Either<TNewResult, TError> Map<TNewResult, TResult, TError>(this Either<TResult, TError> either, Func<TResult, TNewResult> projection)
        {
            var result = projection(either.Result);
            return new Either<TNewResult, TError>(result, either.Error);
        }

        public static Either<TNewResult, TNewError> Map<TNewResult, TNewError, TResult, TError>(this Either<TResult, TError> either,
            Func<TResult, TNewResult> resultProjection, Func<TError, TNewError> errorProjection)
        {
            var result = resultProjection(either.Result);
            var error = errorProjection(either.Error);
            return new Either<TNewResult, TNewError>(result, error);
        }

        public static TNewResult Match<TNewResult, TResult, TError>(this Either<TResult, TError> either, Func<TResult, TNewResult> newResultProjection, Func<TError, TNewResult> newErrorProjection)
        {
            return either.IsLeft ? newResultProjection(either.Result) : newErrorProjection(either.Error);
        }
    }
}
