using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Infrastructure.LinkResources.LinkGenerators
{
    public abstract class BasicLinks<T> where T : class 
    {
        public abstract LinkedEntity<T> GenerateLinksForOneEntity(HttpContext httpContext, T entity);
        public virtual IEnumerable<LinkedEntity<T>> GenerateLinksForManyEntities(HttpContext httpContext, IEnumerable<T> entities)
        {
            var linkedEntities = new List<LinkedEntity<T>>();

            foreach (var entity in entities)
            {
                linkedEntities.Add(GenerateLinksForOneEntity(httpContext, entity));
            }

            return linkedEntities;
        }
    }
}
