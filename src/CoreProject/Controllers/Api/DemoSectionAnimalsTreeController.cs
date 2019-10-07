using CoreProject.Constants;
using CoreProject.Repositories.Interfaces;
using System.Linq;
using System.Net.Http.Formatting;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace CoreProject.Controllers.Api
{
    [Tree(UmbracoTrainingDemoConstants.DemoSectionAlias, "animals", "Umbraco Animals")]
    [PluginController("MyAwesomeSection")]
    public class DemoSectionAnimalsTreeController : TreeController
    {
        private readonly IDemoSectionAnimalsRepository _demoSectionAnimalsRepository;

        public DemoSectionAnimalsTreeController(IDemoSectionAnimalsRepository demoSectionAnimalsRepository)
        {
            _demoSectionAnimalsRepository = demoSectionAnimalsRepository;
        }
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            var nodes = new TreeNodeCollection();

            if (id == "-1")
            {
                nodes
                    .AddRange(
                        _demoSectionAnimalsRepository
                        .GetAll()
                        .Select(animal => CreateTreeNode(animal.Id + "", id, queryStrings, animal.Name, "icon-bird"))
                    );
            }

            return nodes;
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            return new MenuItemCollection();
        }
    }
}