using Newtonsoft.Json;
using Pokemondex.Api.Types;

namespace Pokemondex.Api
{
    public interface IPokemonApiClient 
    {
        public List<GetPokemonResponse> GetAll();
        public GetPokemonResponse Get(string pokemonName);
    }

    public class PokemonApiClient : IPokemonApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://pokeapi.co/api/v2/"; 

        public PokemonApiClient() 
        {
            _httpClient = new HttpClient();
        }

        public List<GetPokemonResponse> GetAll()
        {
            return new();
        }

        public GetPokemonResponse Get(string pokemonName)
        {
            var getPokemonRoute = $"pokemon/{pokemonName}";
            try
            {
                var getPokemonResponse = new GetPokemonResponse();
                var response = _httpClient.GetAsync(_apiUrl + getPokemonRoute)
                    .ContinueWith(taskResponse =>
                    {
                        var response = taskResponse.Result;
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        getPokemonResponse = JsonConvert.DeserializeObject<GetPokemonResponse>(jsonString.Result);
                    });
                response.Wait();

                return getPokemonResponse;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
