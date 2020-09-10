namespace Railway.Monad.Core
{
    public struct Either<TResult, TError>
    {
        internal TResult Result;
        internal TError Error;
        internal bool IsLeft;
        public Either(TResult result)
        {
            Result = result;
            Error = default;
            IsLeft = true;
        }
        public Either(TError error)
        {
            Error = error;
            Result = default;
            IsLeft = false;
        }

        internal Either(TResult result, TError error, bool isLeft = false)
        {
            Error = error;
            Result = result;
            IsLeft = isLeft;
        }

        public static implicit operator Either<TResult, TError>((TResult result, TError error) tuple) => new Either<TResult, TError>(tuple.result, tuple.error);
        public static implicit operator Either<TResult, TError>(TResult result) => new Either<TResult, TError>(result);
        public static implicit operator Either<TResult, TError>(TError error) => new Either<TResult, TError>(error);
    }
}
