using WebService.Models;
using WebService.Requests;

namespace WebService.Services{
    public interface iRequirementService{
        void AddRequirement(RequirementRequest requirement);
        void UpdateRequirement(Requirement requirement);
        void DeleteRequirement(int id);
        Requirement GetRequirement(int id);
        IEnumerable<Requirement> GetAllRequirements();
        IEnumerable<Requirement> GetAllRequirementsById(short id);
    }
}