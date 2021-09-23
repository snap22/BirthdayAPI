using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Query.Parameters
{
    public class ContactParameters : QueryStringParameters
    {
        private const int MIN_VALUE = 1;
        private const int MAX_VALUE = 12;

        private int _minMonth = 1;
        private int _maxMonth = 12;
        public ContactParameters()
        {
            OrderBy = "ContactId";
        }
        /// <summary>
        /// Name of a contact to search for
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Minimal month of a contact's date
        /// </summary>
        public int MinMonth { 
            get
            {
                return _minMonth;
            }

            set
            {
                _minMonth = (value < MIN_VALUE || value > MAX_VALUE) ? MIN_VALUE : value;
            }
        }
        /// <summary>
        /// Maximal month of a contact's date
        /// </summary>
        public int MaxMonth { 
            get
            {
                return _maxMonth;
            }

            set
            {
                _maxMonth = (value < MIN_VALUE || value > MAX_VALUE) ? MAX_VALUE : value;
            }
        }
        public bool IsValidMonthRange()
        {
            return MinMonth <= MaxMonth;
        }
        
        
    }
}
