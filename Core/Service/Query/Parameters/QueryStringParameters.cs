

namespace BirthdayAPI.Core.Service.Query.Parameters
{
    public abstract class QueryStringParameters
    {
        const int MAX_PAGE_SIZE = 50;
        const int DEFAULT_PAGE = 1;
        const int DEFAULT_PAGE_SIZE = 10;

        private int _pageSize = DEFAULT_PAGE_SIZE;
        private int _page = DEFAULT_PAGE;
        public int Page
        { 
            get
            {
                return _page;
            }
            set
            {
                _page = (value > 0) ? value : DEFAULT_PAGE;
            }
        } 
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MAX_PAGE_SIZE || value <= 0) ? DEFAULT_PAGE_SIZE : value;
            }
        }
        public string OrderBy { get; set; }
    }
}
