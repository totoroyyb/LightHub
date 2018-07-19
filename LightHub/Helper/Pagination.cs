using Octokit;

namespace LightHub.Helper
{
    public class Pagination
    {
        public ApiOptions apiOptions { get; set; }

        public Pagination(int startPage, int pageSize)
        {
            apiOptions = new ApiOptions
            {
                StartPage = startPage,
                PageSize = pageSize,
                PageCount = 1
            };
        }
    }
}
