using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.QueryParameters.Sorting
{
    public interface ISortHelper<T> where T : class
    {
        IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString);
    }
}
