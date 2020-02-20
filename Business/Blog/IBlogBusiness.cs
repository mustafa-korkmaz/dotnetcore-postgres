
using System.Collections.Generic;

namespace Business.Blog
{
    public interface IBlogBusiness
    {
        IEnumerable<Dto.Blog> SearchBlogs(string url);

        /// <summary>
        /// cached method
        /// </summary>
        /// <returns></returns>
        IEnumerable<Dto.Blog> GetAll();

        Dto.Blog Get(int id);
    }
}
