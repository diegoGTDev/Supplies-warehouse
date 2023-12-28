using WebService.Data;
using WebService.Models;
using WebService.Models.Response;
using WebService.Requests;

namespace WebService.Services
{
    public class RequirementService : iRequirementService
    {

        public void AddRequirement(RequirementRequest requirement)
        {
            using (var context = new db_warehouseContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                   // try
                    //{
                        var userId = context.Accounts.Where(d => d.Name == requirement.user).FirstOrDefault().AccId;

                        var newRequirement = new Requirement
                        {
                            Description = requirement.description,
                            Account = userId,
                            Responsable = null,
                            RequiStatus = (int)RequirementStatusEnum.Open,
                            Status = (int)StatusEnum.EXIST,
                            Date = System.DateTime.Now,



                        };

                        context.Requirements.Add(newRequirement);

                        context.SaveChanges();
                        

                        foreach (var concept in requirement.concepts)
                        {
                            var newConcept = new Concept
                            {
                                RequiId = newRequirement.RequiId,
                                SupllyCode = concept.supply_code,
                                Unts = (short)concept.units,
                            };
                            context.Concepts.Add(newConcept);
                            context.SaveChanges();
                        };
                        transaction.Commit();
                    //} catch(Exception ex){
                       // transaction.Rollback();
                      //  throw new Exception("An error appears while adding the requirement " + ex.Message);
                   // }
                }

            }

        }
        public void DeleteRequirement(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Requirement> GetAllRequirements()
        {
            
            using (var db = new db_warehouseContext()){
                var requirements = db.Requirements.ToList();
                return requirements;
            }
            
        }

        public IEnumerable<Requirement> GetAllRequirementsById(short id){
            using (var db = new db_warehouseContext()){
                var requirement = db.Requirements.Where(d => d.Account == id).ToList();
                return requirement;
            }
        }

        public Requirement GetRequirement(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRequirement(Requirement requirement)
        {
            throw new NotImplementedException();
        }
    }
}