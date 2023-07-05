namespace WebApiEntityFramework.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source,int page,int size)
        {
            return source.Skip((page - 1) * size).Take(size);
        }
    }
}
