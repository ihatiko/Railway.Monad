namespace Railway.Monad.Core
{
    public static class MonadConstructExtensions
    {
        public static Either<TResult, TError> ToEither<TResult, TError>(this TResult result)
        {
            return new Either<TResult, TError>(result);
        }

        public static Either<TResult, TError> ToEither<TResult, TError>(this TError error)
        {
            return new Either<TResult, TError>(error);
        }
    }
}
