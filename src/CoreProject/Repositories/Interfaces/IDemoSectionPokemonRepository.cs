using CoreProject.Models;

namespace CoreProject.Repositories.Interfaces
{
    public interface IDemoSectionPokemonRepository
    {
        DemoSectionPokemon[] GetAll();
        DemoSectionPokemon GetById(string id);
    }
}