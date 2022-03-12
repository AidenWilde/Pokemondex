using Newtonsoft.Json;
using Pokemondex.Api.Types;

namespace Pokemondex.Api
{
    public interface IPokemonApiClient 
    {
        public GetAllPokemonResponse? GetAll();
        public GetAllPokemonResponse? GetAllByPaginationUrl(string paginationUrl);
        public GetPokemonResponse? Get(string pokemonName);
    }

    public class PokemonApiClient : IPokemonApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://pokeapi.co/api/v2/"; 

        public PokemonApiClient() 
        {
            _httpClient = new HttpClient();
        }

        public GetAllPokemonResponse? GetAll()
        {
            var getPokemonRoute = $"pokemon/";

            try
            {
                var getPokemonResponse = new GetAllPokemonResponse();
                var response = _httpClient.GetAsync(_apiUrl + getPokemonRoute)
                    .ContinueWith(taskResponse =>
                    {
                        var response = taskResponse.Result;
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        getPokemonResponse = JsonConvert.DeserializeObject<GetAllPokemonResponse>(jsonString.Result);
                    });
                response.Wait();

                return getPokemonResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public GetAllPokemonResponse? GetAllByPaginationUrl(string paginationUrl)
        {
            try
            {
                var getPokemonResponse = new GetAllPokemonResponse();
                var response = _httpClient.GetAsync(paginationUrl)
                    .ContinueWith(taskResponse =>
                    {
                        var response = taskResponse.Result;
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        getPokemonResponse = JsonConvert.DeserializeObject<GetAllPokemonResponse>(jsonString.Result);
                    });
                response.Wait();

                return getPokemonResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public GetPokemonResponse? Get(string pokemonName)
        {
            if (pokemonName.IsNullOrEmpty()) 
                return null;

            var getPokemonRoute = $"pokemon/{pokemonName.ToLower()}";
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
                return null;
            }
        }
    }

    public static class ExtensionMethods
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return value == null || value.Length == 0;
        }
    }
}
