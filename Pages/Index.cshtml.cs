using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemondex.Api;
using Pokemondex.Data_transfer_objects;

namespace Pokemondex.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PokemonApiWrapper _pokemonApiWrapper;

        public GetPokemonDTO Pokemon { get; set; } = null;

        [BindProperty(SupportsGet = true)] //SupportsGet is opt-in because it can be insecure, verify user input before mapping elsewhere
        public string SearchValue { get; set; }

        public IndexModel()
        {
            _pokemonApiWrapper = new PokemonApiWrapper();
        }

        public void OnPostSearch()
        {
            Pokemon = _pokemonApiWrapper.Get(SearchValue);
        }

        public void OnGet()
        {
        }
    }
}