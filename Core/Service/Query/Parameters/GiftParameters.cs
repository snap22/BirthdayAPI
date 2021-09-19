using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Query.Parameters
{
    public class GiftParameters : QueryStringParameters
    {
        public GiftParameters()
        {
            OrderBy = "GiftId";
        }

        private const double DEFAULT_PRICE = 0;
        private double _minPrice;
        private double _maxPrice;

        public string Name { get; set; }
        public double MinPrice
        { 
            get
            {
                return _minPrice;
            }

            set
            {
                _minPrice = (value < 0) ? DEFAULT_PRICE : value;
            }
        }

        public double MaxPrice
        {
            get
            {
                return _maxPrice;
            }

            set
            {
                _maxPrice = (value < 0) ? MinPrice : value;
            }
        }

        public bool IsValidPriceRange() => _minPrice <= _maxPrice;
    }
}
