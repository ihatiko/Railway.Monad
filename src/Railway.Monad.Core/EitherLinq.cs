using System;
using System.Collections.Generic;
using System.Text;

namespace Railway.Monad.Core
{
    public static class EitherLinq
    {
        public static Either<TNewResult, TNewError> Select<TResult, TError, TNewResult, TNewError>(this Either<TResult, TError> either, Func<Either<TResult, TError>, Either<TNewResult, TNewError>> projection)
        {
            return projection(either);
        }
    }
}
