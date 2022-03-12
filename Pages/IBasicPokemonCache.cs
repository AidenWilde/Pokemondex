using Pokemondex.Data_transfer_objects;

namespace Pokemondex.Pages
{
    public interface IBasicPokemonCache
    {
        public void UpdateAllPokemon(GetAllPokemonDTO allPokemon);
        public void UpdatePokemon(GetPokemonDTO pokemon);
        public GetPokemonDTO Get();
        public GetAllPokemonDTO GetAll();
    }

    public class BasicPokemonCache : IBasicPokemonCache
    {
        public GetPokemonDTO? CurrentFilteredPokemonDTO { get; set; }
        public GetAllPokemonDTO? CurrentPaginatedPokemonDTO { get; set; }

        public void UpdateAllPokemon(GetAllPokemonDTO allPokemon)
        {
            CurrentPaginatedPokemonDTO = allPokemon;
        }

        public void UpdatePokemon(GetPokemonDTO pokemon)
        {
            CurrentFilteredPokemonDTO = pokemon;
        }

        public GetPokemonDTO Get()
        {
            return CurrentFilteredPokemonDTO;
        }

        public GetAllPokemonDTO GetAll()
        {
            return CurrentPaginatedPokemonDTO;
        }
    }
}