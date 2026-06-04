using System.Text.Json.Serialization;

namespace WorkExperience.Client.Core.Models
{
    public class Spell
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
