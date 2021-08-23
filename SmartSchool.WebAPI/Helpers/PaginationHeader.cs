namespace SmartSchool.WebAPI.Helpers
{
    public class PaginationHeader
    {
        public PaginationHeader(PaginationHeader model)
        {
            this.CurrentPage = model.CurrentPage;
            this.TotalPage = model.TotalPage;
            this.PageSize = model.PageSize;
            this.TotalCount = model.TotalCount;

        }
        public PaginationHeader(int currentPage, int totalPage, int pageSize, int totalCount)
        {
            this.CurrentPage = currentPage;
            this.TotalPage = totalPage;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;

        }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}