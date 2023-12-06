using WebService.Models;

namespace WebService.Services{
    public interface iRequirementService{
        void AddRequirement(Requirement requirement);
        void UpdateRequirement(Requirement requirement);
        void DeleteRequirement(int id);
        Requirement GetRequirement(int id);
        IEnumerable<Requirement> GetAllRequirements();
        }
}