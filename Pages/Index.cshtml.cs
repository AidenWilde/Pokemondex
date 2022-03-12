using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemondex.Api;

namespace Pokemondex.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //var pokemonWrapper = new PokemonApiWrapper();
            //var pokemon = pokemonWrapper.Get();
        }
    }
}