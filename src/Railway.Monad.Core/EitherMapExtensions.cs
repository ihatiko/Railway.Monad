using System;


namespace Railway.Monad.Core
{
    public static class EitherMapExtensions
    {
        public static Either<TNewResult, TError> MapRight<TNewResult, TResult, TError>(this Either<TResult, TError> either, Func<TResult, TNewResult> resultProjection)
        {
            var result = resultProjection(either.Result);
            return new Either<TNewResult, TError>(result, either.Error);
        }

        public static Either<TResult, TNewError> MapLeft<TNewError, TResult, TError>(this Either<TResult, TError> either, Func<TError, TNewError> errorProjection)
        {
            var error = errorProjection(either.Error);
            return new Either<TResult, TNewError>(either.Result, error);
        }

        public static Either<TNewResult, TNewError> Map<TNewResult, TNewError, TResult, TError>(this Either<TResult, TError> either,
            Func<TResult, TNewResult> resultProjection, Func<TError, TNewError> errorProjection)
        {
            var result = resultProjection(either.Result);
            var error = errorProjection(either.Error);
            return new Either<TNewResult, TNewError>(result, error, either.IsLeft);
        }
    }
}
