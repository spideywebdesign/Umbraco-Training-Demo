using CoreProject.Repositories.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace CoreProject.Controllers.Api
{
    public class DemoSectionPokemonController : UmbracoAuthorizedApiController
    {
        private readonly IDemoSectionPokemonRepository _demoSectionPokemonRepository;

        public DemoSectionPokemonController(IDemoSectionPokemonRepository demoSectionPokemonRepository)
        {
            _demoSectionPokemonRepository = demoSectionPokemonRepository;
        }

        [HttpGet]
        public object GetPokemon(string pokemonId)
        {
            var pokemon = _demoSectionPokemonRepository.GetById(pokemonId);

            if (pokemon == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Pokémon not found");

            return pokemon;

        }

        [HttpGet]
        public object Evolve(string pokemonId)
        {
            var pokemon = _demoSectionPokemonRepository.GetById(pokemonId);

            if (pokemon == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Pokémon not found");
            if (!pokemon.CanEnvolve) return Request.CreateResponse(HttpStatusCode.BadRequest);

            pokemon.Envolve();

            return pokemon;

        }
    }
}