using System;

namespace Maybe
{
    // Interfaccia IMaybe
    public interface IMaybe<T>
    {
        bool HasValue();
        T Value { get; }
    }

    // Creo la classe astratta Maybe
    public abstract class Maybe<T> : IMaybe<T>
    {
        public abstract bool HasValue();
        public abstract T Value { get; }
    }
    
    public class Some<T> : Maybe<T>
    {
        private readonly T t;

        public Some(T t)
        {
            this.t = t;
        }

        public override bool HasValue()
        {
            return true;
        }

        public override T Value
        {
            get { return t; }
        }
    }

    public class None<T> : Maybe<T>
    {
        public override bool HasValue()
        {
            return false;
        }

        public override T Value
        {
            get { throw new ApplicationException("Object is null"); }
        }
    }
}