using System;

namespace Maybe
{
    public static class MaybeExtensions
    {
        public static U Case<T, U>(this Maybe<T> obj, Func<T, U> some,
            Func<U> none)
        {
            return obj.HasValue()
                ? some(obj.Value)
                : none();
        }
    }
}