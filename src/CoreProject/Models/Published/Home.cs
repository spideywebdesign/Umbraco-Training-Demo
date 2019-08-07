using System.Collections.Generic;

namespace CoreProject.Models.Published
{
    public partial class Home
    {
        public IEnumerable<Blogpost> AllBlogPosts { get; set; }
    }
}