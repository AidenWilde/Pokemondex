﻿namespace Pokemondex.Api.Types
{
    public class GetAllPokemonResponse
    {
        public class Result
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public int count { get; set; }
        public string? next { get; set; }
        public string? previous { get; set; }
        public List<Result> results { get; set; }
    }
}
