namespace Pokemondex.Api
{
    public class PokemonApiClient
    {
        private HttpClient _httpClient;

        public PokemonApiClient()
        {
            _httpClient = new HttpClient();
        }
    }
}
