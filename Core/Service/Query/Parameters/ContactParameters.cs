using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Query.Parameters
{
    public class ContactParameters : QueryStringParameters
    {
        public ContactParameters()
        {
            OrderBy = "ContactId";
        }
        public string Name { get; set; }
        public int MinMonth { get; set; }
        public int MaxMonth { get; set; }
        public bool IsValidMonthRange()
        {
            return MinMonth < MaxMonth;
        }
        public bool IsValidMonth(int month)
        {
            return month < 12 && month > 0;
        }
    }
}
