﻿using Pokemondex.Api.Types;

namespace Pokemondex.Data_transfer_objects
{
    public class GetPokemonDTO
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public GetPokemonDTO(GetPokemonResponse response)
        {
            Name = response.species.name;
            Url = response.species.url;
        }
    }
}