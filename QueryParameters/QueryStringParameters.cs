

namespace BirthdayAPI.QueryParameters
{
    public abstract class QueryStringParameters
    {
        const int MAX_PAGE_SIZE = 50;
        private int _pageSize = 20;
        public int Page { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MAX_PAGE_SIZE || value <= 0) ? MAX_PAGE_SIZE : value;
            }
        }
        public string OrderBy { get; set; }
    }
}
