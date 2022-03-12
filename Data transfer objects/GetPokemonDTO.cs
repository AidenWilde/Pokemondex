using Pokemondex.Api.Types;

namespace Pokemondex.Data_transfer_objects
{
    public sealed class GetPokemonDTO
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string SpriteUrl { get; set; }

        public GetPokemonDTO(GetPokemonResponse response)
        {
            Name = response.species.name;
            Url = response.species.url;
            SpriteUrl = response.sprites.front_default;
        }
    }
}
