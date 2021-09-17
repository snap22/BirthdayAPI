using System.Linq;

namespace BirthdayAPI.Core.Service.Query.Sorting
{
    public interface ISortHelper<T> where T : class
    {
        IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString);
    }
}
