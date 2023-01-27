using Blazorcrud.Shared.Data;
using Blazorcrud.Shared.Models;

namespace Blazorcrud.Server.Models
{
    public interface ISkillRepository
    {
        Task<Skill?> GetSkill(int personId);
        Task<Skill> AddSkill(Skill skill);
        Task<Skill?> UpdateSkill(Skill skill);
        Task<Skill?> DeleteSkill(int skillId);
    }
}