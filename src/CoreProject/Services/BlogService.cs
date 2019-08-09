using CoreProject.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;
using ContentModels = CoreProject.Models.Published;

namespace CoreProject.Services
{
    public class BlogService : IBlogService
    {
        public IEnumerable<ContentModels.Blogpost> GetAllBlogPosts()
        {
            var blogPostsXPath = $"root/{ContentModels.Home.ModelTypeAlias} [@isDoc]/{ContentModels.Blog.ModelTypeAlias} [@isDoc]/{ContentModels.Blogpost.ModelTypeAlias} [@isDoc]";
            var uHelper = new UmbracoHelper(UmbracoContext.Current);
            var blogPosts = uHelper.TypedContentAtXPath(blogPostsXPath).Select(x => new ContentModels.Blogpost(x));
            return blogPosts ?? Enumerable.Empty<ContentModels.Blogpost>();
        }
    }
}