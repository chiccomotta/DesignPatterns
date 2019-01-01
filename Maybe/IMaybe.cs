using System;
using System.Collections.Generic;
using System.Text;

namespace Maybe
{
    public interface IMaybe<T>
    {
        bool HasValue();
        T Value();
    }

    public class Some<T> : IMaybe<T>
    {
        private readonly T t;

        public Some(T t)
        {
            this.t = t;
        }

        public bool HasValue()
        {
            return true;
        }

        public T Value()
        {
            return t;
        }
    }

    public class None<T> : IMaybe<T>
    {
        public bool HasValue()
        {
            return false;
        }

        public T Value()
        {
            throw new ApplicationException("Object is null");
        }
    }
}
