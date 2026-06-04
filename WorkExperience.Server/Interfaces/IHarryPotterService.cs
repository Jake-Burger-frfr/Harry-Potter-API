using WorkExperience.Server.Models;

namespace WorkExperience.Server.Interfaces
{
    public interface IHarryPotterService
    {
        Task<List<Character>> GetCharactersAsync(string path);
        Task<List<Spell>> GetSpellsAsync();
    }
}
