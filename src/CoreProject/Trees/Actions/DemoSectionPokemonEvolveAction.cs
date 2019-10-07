using umbraco.interfaces;

namespace CoreProject.Trees.Actions
{
    public class DemoSectionPokemonEvolveAction : IAction
    {
        public char Letter => default(char);

        public bool ShowInNotifier => false;

        public bool CanBePermissionAssigned => false;

        public string Icon => "fullscreen";

        public string Alias => "evolve";

        public string JsFunctionName => "";

        public string JsSource => "";
    }
}