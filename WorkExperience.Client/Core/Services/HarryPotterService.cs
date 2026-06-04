using System.Text.Json;
using WorkExperience.Client.Core.Models;

namespace WorkExperience.Client.Core.Services
{
    public class HarryPotterService
    {
        private readonly HttpClient _httpClient;

        private const string BaseAddress = "harrypotter/";

        public HarryPotterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Character>> GetCharactersAsync(string characterFilter)
        {   
            Console.WriteLine($"{BaseAddress}{characterFilter}");
            HttpResponseMessage response = await _httpClient.GetAsync($"{BaseAddress}{characterFilter}");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<Character>? characters = JsonSerializer.Deserialize<List<Character>>(json);

            return characters ?? new List<Character>();
        }
        public async Task<List<Spell>> GetSpellsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{BaseAddress}spells");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<Spell>? spells = JsonSerializer.Deserialize<List<Spell>>(json);

            return spells ?? new List<Spell>();
        }
    }
}