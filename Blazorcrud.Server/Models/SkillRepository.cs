using Blazorcrud.Shared.Data;
using Blazorcrud.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazorcrud.Server.Models
{
    public class SkillRepository:ISkillRepository
    {
        private readonly AppDbContext _appDbContext;

        public SkillRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Skill> AddSkill(Skill skill)
        {
            var result = await _appDbContext.Skills.AddAsync(skill);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Skill?> DeleteSkill(int skillId)
        {
            var result = await _appDbContext.Skills.FirstOrDefaultAsync(p => p.SkillId == skillId);
            if (result!=null)
            {
                _appDbContext.Skills.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Skill not found");
            }
            return result;
        }

        public async Task<Skill?> GetSkill(int skillId)
        {
            var result = await _appDbContext.Skills
                .FirstOrDefaultAsync(p => p.SkillId == skillId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Skill not found");
            }
        }

        public async Task<Skill?> UpdateSkill(Skill skill)
        {
            var result = await _appDbContext.Skills.FirstOrDefaultAsync(p => p.SkillId == skill.SkillId);
            if (result != null)
            {
                // Update existing Skill
                _appDbContext.Entry(result).CurrentValues.SetValues(skill);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Skill not found");
            }
            return result;
        }
    }
}