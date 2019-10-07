using CoreProject.Helpers;
using System.Linq;
using CoreProject.Constants;
using Umbraco.Core;

namespace CoreProject.Events
{
    public class UmbracoEvents : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            IocHelper.Register();

            RegisterDemoSection(applicationContext);
        }

        private static void RegisterDemoSection(ApplicationContext applicationContext)
        {
            //Look for an existing section with this alias
            var section = applicationContext.Services.SectionService.GetByAlias(UmbracoTrainingDemoConstants.DemoSectionAlias);

            //If a section with this alias was found, no need to continue to add it.
            if (section != null) return;

            //Add a new "Demo Section" section
            applicationContext.Services.SectionService.MakeNew("Demo Section", UmbracoTrainingDemoConstants.DemoSectionAlias, "icon-newspaper");

            //You can programmatically/automatically add access to this section specific user groups
            //Alternatively, this can be managed from the user groups view in the "Users" section of Umbraco.
            AddDemoSectionToUserGroups(applicationContext);
        }

        private static void AddDemoSectionToUserGroups(ApplicationContext applicationContext)
        {
            //Make the new section available to all users or specific user groups
            var adminGroup = applicationContext.Services.UserService.GetUserGroupByAlias("administrators");

            //Group does not exist, so skip
            if (adminGroup == null) return;

            //Group already has section access, so skip
            if (adminGroup.AllowedSections.Contains(UmbracoTrainingDemoConstants.DemoSectionAlias)) return;

            //Add the section to the list of allowed sections for this group
            adminGroup.AddAllowedSection(UmbracoTrainingDemoConstants.DemoSectionAlias);

            //Make sure you save the change to the group
            applicationContext.Services.UserService.Save(adminGroup);
        }
    }
}