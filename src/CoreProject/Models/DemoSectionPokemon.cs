using Newtonsoft.Json;

namespace CoreProject.Models
{
    public class DemoSectionPokemon
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string[] Type { get; set; }

        [JsonIgnore]
        public DemoSectionPokemonKind Kind { get; set; }

        [JsonProperty("kind")]
        protected string KindStr => Kind + "";

        [JsonProperty("isEvolved")]
        public bool IsEvolved => !CanEnvolve;

        [JsonProperty("canEvolve")]
        public bool CanEnvolve =>
        (
            Kind == DemoSectionPokemonKind.Rattata
            ||
            Kind == DemoSectionPokemonKind.Spearow
            ||
            Kind == DemoSectionPokemonKind.Goldeen
            ||
            Kind == DemoSectionPokemonKind.Seel
        );

        public DemoSectionPokemon(string id, DemoSectionPokemonKind kind)
        {
            Id = id;
            Name = kind + "";
            Kind = kind;
            Type = GetTypes(kind);
        }

        public void Envolve()
        {

            switch (Kind)
            {
                case DemoSectionPokemonKind.Rattata:
                    Kind = DemoSectionPokemonKind.Raticate;
                    if (Name == DemoSectionPokemonKind.Rattata + "") Name = DemoSectionPokemonKind.Raticate + "";
                    Type = GetTypes(Kind);
                    break;
                case DemoSectionPokemonKind.Spearow:
                    Kind = DemoSectionPokemonKind.Fearow;
                    if (Name == DemoSectionPokemonKind.Spearow + "") Name = DemoSectionPokemonKind.Fearow + "";
                    Type = GetTypes(Kind);
                    break;
                case DemoSectionPokemonKind.Goldeen:
                    Kind = DemoSectionPokemonKind.Seaking;
                    if (Name == DemoSectionPokemonKind.Goldeen + "") Name = DemoSectionPokemonKind.Seaking + "";
                    Type = GetTypes(Kind);
                    break;
                case DemoSectionPokemonKind.Seel:
                    Kind = DemoSectionPokemonKind.Dewgong;
                    if (Name == DemoSectionPokemonKind.Seel + "") Name = DemoSectionPokemonKind.Dewgong + "";
                    Type = GetTypes(Kind);
                    break;
            }

        }

        private string[] GetTypes(DemoSectionPokemonKind kind)
        {

            switch (kind)
            {

                case DemoSectionPokemonKind.Rattata:
                case DemoSectionPokemonKind.Raticate:
                    return new[] { "Normal" };

                case DemoSectionPokemonKind.Spearow:
                case DemoSectionPokemonKind.Fearow:
                    return new[] { "Normal", "Flying" };

                case DemoSectionPokemonKind.Goldeen:
                case DemoSectionPokemonKind.Seaking:
                case DemoSectionPokemonKind.Seel:
                    return new[] { "Water" };

                case DemoSectionPokemonKind.Dewgong:
                    return new[] { "Water", "Ice" };

                default:
                    return new[] { "Unknown" };

            }
        }
    }
}