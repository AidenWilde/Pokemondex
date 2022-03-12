using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemondex.Api;
using Pokemondex.Data_transfer_objects;

namespace Pokemondex.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly IBasicPokemonCache _basicPokemonCache;

        private readonly PokemonApiWrapper _pokemonApiWrapper;

        public GetAllPokemonDTO PaginatedPokemon { get; set; } = null;
        public GetPokemonDTO FilteredPokemon { get; set; } = null;

        [BindProperty(SupportsGet = true)] //SupportsGet is opt-in because it can be insecure, verify user input before mapping elsewhere
        public string SearchValue { get; set; }
        [BindProperty(SupportsGet = true)] //SupportsGet is opt-in because it can be insecure, verify user input before mapping elsewhere
        public string FilterValue { get; set; }

        static IndexModel()
        {
            _basicPokemonCache = new BasicPokemonCache();
        }

        public IndexModel()
        {
            _pokemonApiWrapper = new PokemonApiWrapper();
        }

        public void OnPostSearch()
        {
            FilteredPokemon = _pokemonApiWrapper.Get(SearchValue);
            _basicPokemonCache.UpdatePokemon(FilteredPokemon);
        }
        
        public void OnPostFilter()
        {
            FilteredPokemon = _pokemonApiWrapper.Get(FilterValue);
            _basicPokemonCache.UpdatePokemon(FilteredPokemon);
        }

        public void OnPostNextPage()
        {
            PaginatedPokemon = _pokemonApiWrapper.GetAllByPaginationUrl(_basicPokemonCache.GetAll().NextPaginationUrl);
            _basicPokemonCache.UpdateAllPokemon(PaginatedPokemon);
        }
        public void OnPostPreviousPage()
        {
            PaginatedPokemon = _pokemonApiWrapper.GetAllByPaginationUrl(_basicPokemonCache.GetAll().PreviousPaginationUrl);
            _basicPokemonCache.UpdateAllPokemon(PaginatedPokemon);
        }

        public void OnGet()
        {
            PaginatedPokemon = _pokemonApiWrapper.GetAll();
            _basicPokemonCache.UpdateAllPokemon(PaginatedPokemon);
        }
    }
}