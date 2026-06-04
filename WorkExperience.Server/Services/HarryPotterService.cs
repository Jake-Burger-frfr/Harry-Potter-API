using System.Text.Json;
using WorkExperience.Server.Models;
using WorkExperience.Server.Interfaces;

namespace WorkExperience.Server.Services
{
    public class HarryPotterService : IHarryPotterService
    {
        private readonly HttpClient _httpClient;

        public HarryPotterService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<Character>> GetCharactersAsync(string characterFilter)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(characterFilter);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<Character>? characters = JsonSerializer.Deserialize<List<Character>>(json);

            return characters ?? new List<Character>();
        }
        public async Task<List<Spell>> GetSpellsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("spells");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<Spell>? spells = JsonSerializer.Deserialize<List<Spell>>(json);

            return spells ?? new List<Spell>();
        }
    }
}
