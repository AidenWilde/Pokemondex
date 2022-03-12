namespace Pokemondex.Api
{
    public interface IPokemonApiClient 
    {
        public void GetAll();
        public void Get();
    }

    public class PokemonApiClient : IPokemonApiClient
    {
        private HttpClient _httpClient;

        public PokemonApiClient()
        {
            _httpClient = new HttpClient();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
