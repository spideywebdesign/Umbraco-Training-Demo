using System.Collections.Generic;
using ContentModels = CoreProject.Models.Published;

namespace CoreProject.Services.Interfaces
{
    public interface IBlogService
    {
        IEnumerable<ContentModels.Blogpost> GetAllBlogPosts();
    }
}