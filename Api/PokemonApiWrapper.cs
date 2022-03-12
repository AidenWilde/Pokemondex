using Pokemondex.Data_transfer_objects;

namespace Pokemondex.Api
{
    public interface IPokemonApiWrapper
    {
        public GetAllPokemonDTO GetAll();
        public GetAllPokemonDTO GetAllByPaginationUrl(string paginationUrl);
        public GetPokemonDTO? Get(string pokemonName);
    }

    public class PokemonApiWrapper : IPokemonApiWrapper
    {
        private PokemonApiClient _client;

        public PokemonApiWrapper()
        {
            _client = new PokemonApiClient();
        }

        public GetAllPokemonDTO GetAll()
        {
            var getAllPokemonResponse = _client.GetAll();
            if (getAllPokemonResponse is null)
                return null;

            return new GetAllPokemonDTO(getAllPokemonResponse);
        }

        public GetAllPokemonDTO GetAllByPaginationUrl(string paginationUrl)
        {
            var getAllPokemonResponse = _client.GetAllByPaginationUrl(paginationUrl);
            if (getAllPokemonResponse is null)
                return null;

            return new GetAllPokemonDTO(getAllPokemonResponse);
        }

        public GetPokemonDTO? Get(string pokemonName)
        {
            var getPokemonResponse = _client.Get(pokemonName);
            if(getPokemonResponse is null) 
                return null;

            return new GetPokemonDTO(getPokemonResponse);
        }
    }
}
