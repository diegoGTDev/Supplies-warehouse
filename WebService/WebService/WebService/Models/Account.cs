using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public partial class Account
    {
        public Account()
        {
            RequirementAccountNavigations = new HashSet<Requirement>();
            RequirementResponsableNavigations = new HashSet<Requirement>();
        }

        public short AccId { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte Role { get; set; }
        public byte Department { get; set; }

        public virtual Department DepartmentNavigation { get; set; } = null!;
        public virtual Role RoleNavigation { get; set; } = null!;
        public virtual ICollection<Requirement> RequirementAccountNavigations { get; set; }
        public virtual ICollection<Requirement> RequirementResponsableNavigations { get; set; }
    }
}
