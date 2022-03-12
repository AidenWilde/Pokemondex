using Pokemondex.Api.Types;

namespace Pokemondex.Data_transfer_objects
{
    public sealed class GetAllPokemonDTO
    {
        public List<PokemonDetails> Pokemon;

        public string ? NextPaginationUrl { get; set; }
        public string ? PreviousPaginationUrl { get; set; }
        public string CurrentUrl { get; set; }

        public GetAllPokemonDTO(GetAllPokemonResponse getAllPokemonResponse)
        {
            Pokemon = new List<PokemonDetails>();

            NextPaginationUrl = getAllPokemonResponse.next;
            PreviousPaginationUrl = getAllPokemonResponse.previous;

            foreach(var pokemon in getAllPokemonResponse.results)
            {
                Pokemon.Add(new PokemonDetails
                {
                    Name = pokemon.name,
                    Url = pokemon.url
                });
            }

            // update cache here
        }

        public class PokemonDetails
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}
