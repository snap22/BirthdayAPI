using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using BindingFlags = System.Reflection.BindingFlags;

namespace BirthdayAPI.QueryParameters.Sorting
{
    public class SortHelper<T> : ISortHelper<T> where T : class
    {
        public IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString)
        {
            if (entities.Any() == false)
                return entities;

            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return entities;

            var orderParameters = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new System.Text.StringBuilder();

            foreach (var param in orderParameters)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyName = param.Split(" ")[0];
                var propertyObject = propertyInfos.FirstOrDefault(info => info.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));

                if (propertyObject == null)
                    continue;

                string ordering = param.ToLower().EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{propertyObject.Name.ToString()} {ordering}");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            // doable thanks to System.Linq.Dynamic.Core 
            return entities.OrderBy(orderQuery);
        }
    }
}
