using Blazorcrud.Server.Authorization;
using Blazorcrud.Server.Models;
using Blazorcrud.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Blazorcrud.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepository _SkillRepository;
        private readonly AppSettings _appSettings;

        public SkillController(ISkillRepository SkillRepository, IOptions<AppSettings> appSettings)
        {
            _SkillRepository = SkillRepository;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Gets a specific Skill by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSkill(int id)
        {
            return Ok(await _SkillRepository.GetSkill(id));
        }

        /// <summary>
        /// Creates a Skill and hashes password.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddSkill(Skill Skill)
        {
            return Ok(await _SkillRepository.AddSkill(Skill));
        }
        
        /// <summary>
        /// Updates a Skill with a specific Id, hashing password if updated.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateSkill(Skill Skill)
        {
            return Ok(await _SkillRepository.UpdateSkill(Skill));
        }

        /// <summary>
        /// Deletes a Skill with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSkill(int id)
        {
            return Ok(await _SkillRepository.DeleteSkill(id));
        }
    }
}
