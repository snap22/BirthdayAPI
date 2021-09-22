using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Infrastructure.LinkResources
{
    public class LinkedEntity<T> where T : class
    {
        public T Value { get; set; }
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
