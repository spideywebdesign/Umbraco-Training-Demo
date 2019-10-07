using CoreProject.Models;
using CoreProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CoreProject.Repositories
{
    public class DemoSectionPokemonRepository : IDemoSectionPokemonRepository
    {
        private readonly List<DemoSectionPokemon> _pokemon = new List<DemoSectionPokemon>();

        public DemoSectionPokemonRepository()
        {
            _pokemon.Add(new DemoSectionPokemon("aa10b0bd-f968-4e3d-9628-268d2052274d", DemoSectionPokemonKind.Rattata));
            _pokemon.Add(new DemoSectionPokemon("ab66834a-089c-4c16-9f20-17a339033f90", DemoSectionPokemonKind.Spearow));
            _pokemon.Add(new DemoSectionPokemon("2903399f-a251-4f32-8405-5bb40058ff88", DemoSectionPokemonKind.Goldeen));
            _pokemon.Add(new DemoSectionPokemon("2ed17f2e-b0ac-4a1b-88b0-c847edae293c", DemoSectionPokemonKind.Seel));
        }
        public DemoSectionPokemon[] GetAll()
        {
            return _pokemon.ToArray();
        }

        public DemoSectionPokemon GetById(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}