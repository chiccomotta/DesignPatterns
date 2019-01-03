namespace Maybe
{
    public static class ObjectExtensions
    {
        public static IMaybe<T> AsMaybe<T>(this T obj) where T : class
        {
            if (obj == null)
                return new None<T>();

            return new Some<T>(obj);
        }
    }
}