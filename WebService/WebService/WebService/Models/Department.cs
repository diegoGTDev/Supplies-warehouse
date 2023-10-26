using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public partial class Department
    {
        public Department()
        {
            Accounts = new HashSet<Account>();
        }

        public byte DepartmentId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
