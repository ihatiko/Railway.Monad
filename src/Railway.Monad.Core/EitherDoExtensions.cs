using System;
using System.Collections.Generic;
using System.Text;

namespace Railway.Monad.Core
{
    public static class EitherDoExtensions
    {
        public static Either<TResult, TError> Do<TResult, TError>(this Either<TResult, TError> either, Action<TResult> resultAction, Action<TError> errorAction)
        {
            if (either.IsLeft)
            {
                resultAction(either.Result);
            }
            else
            {
                errorAction(either.Error);
            }
            return either;
        }

        public static Either<TResult, TError> DoRight<TResult, TError>(this Either<TResult, TError> either, Action<TResult> resultAction)
        {
            resultAction(either.Result);
            return either;
        }

        public static Either<TResult, TError> DoLeft<TResult, TError>(this Either<TResult, TError> either, Action<TError> errorAction)
        {
            errorAction(either.Error);
            return either;
        }
    }
}
