using System;
using System.Collections.Generic;
using System.Text;
using Maybe;

namespace Maybe
{
    // Interfaccia IMaybe (ma preferisco usare la classe astratta)
    public interface IMaybe<T>
    {
        bool HasValue();
        T Value { get; }
    }

    // Oppure creo la classe astratta Maybe (più comoda)
    public abstract class Maybe<T>
    {
        public virtual bool HasValue()
        {
            return true;
        }

        public virtual T Value { get; }
    }

    //public class Some<T> : IMaybe<T>
    //{
    //    private readonly T t;

    //    public Some(T t)
    //    {
    //        this.t = t;
    //    }

    //    public bool HasValue()
    //    {
    //        return true;
    //    }

    //    public T Value
    //    {
    //        get { return t; }
    //    }      
    //}

    //public class None<T> : IMaybe<T>
    //{
    //    public bool HasValue()
    //    {
    //        return false;
    //    }

    //    public T Value
    //    {
    //        get
    //        {
    //            throw new ApplicationException("Object is null");
    //        }
    //    }
    //}

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

        public T Value
        {
            get
            {
                throw new ApplicationException("Object is null");
            }
        }
    }

    //public static class ObjectExtensions
    //{
    //    public static IMaybe<T> AsMaybe<T>(this T obj)
    //        where T : class
    //    {
    //        if (obj == null)
    //            return new None<T>();

    //        return new Some<T>(obj);
    //    }
    //}
}
