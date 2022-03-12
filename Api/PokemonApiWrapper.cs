using Pokemondex.Data_transfer_objects;

namespace Pokemondex.Api
{
    public interface IPokemonApiWrapper
    {
        public List<GetPokemonDTO?> GetAll();
        public GetPokemonDTO? Get(string pokemonName);
    }

    public class PokemonApiWrapper : IPokemonApiWrapper
    {
        private PokemonApiClient _client;

        public PokemonApiWrapper()
        {
            _client = new PokemonApiClient();
        }

        public List<GetPokemonDTO?> GetAll()
        {
            // call off to client api to get all pokemon
            throw new NotImplementedException();
        }

        public GetPokemonDTO? Get(string pokemonName)
        {
            var getPokemonResponse = _client.Get(pokemonName);
            if(getPokemonResponse is not null) 
                return new GetPokemonDTO(getPokemonResponse);

            return null;
        }
    }
}
