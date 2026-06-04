using Microsoft.AspNetCore.Mvc;
using WorkExperience.Server.Interfaces;

namespace WorkExperience.Server.Controllers
{
    [ApiController]
    [Route("harrypotter")]
    public class HarryPotterController : ControllerBase
    {
        private readonly IHarryPotterService _harryPotterService;

        public HarryPotterController(IHarryPotterService harryPotterService)
        {
            _harryPotterService = harryPotterService;
        }

        [HttpGet("{*characterFilter}")]
        public async Task<IActionResult> GetCharacters(string characterFilter)
        {
            List<Models.Character> characters = await _harryPotterService.GetCharactersAsync(characterFilter);
            return Ok(characters);
        }
        [HttpGet("spells")]
        public async Task<IActionResult> GetSpells()
        {
            List<Models.Spell> spells = await _harryPotterService.GetSpellsAsync();
            return Ok(spells);
        }
    }
}
