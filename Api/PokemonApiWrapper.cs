namespace Pokemondex.Api
{
    public interface IPokemonApiWrapper
    {
        public void GetAll();
        public void Get();
    }

    public class PokemonApiWrapper : IPokemonApiWrapper
    {
        private PokemonApiClient _client;

        public PokemonApiWrapper()
        {
            _client = new PokemonApiClient();
        }

        public void GetAll()
        {
            // call off to client api to get all pokemon
            throw new NotImplementedException();
        }

        public void Get()
        {
            // get specific pokemon information
            throw new NotImplementedException();
        }
    }
}
