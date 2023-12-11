using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public partial class RequirementStatus
    {
        public RequirementStatus()
        {
            Requirements = new HashSet<Requirement>();
        }

        public byte RequiStatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Requirement> Requirements { get; set; }
    }

    public enum RequirementStatusEnum
    {
        Open = 0,
        
        Close = 1,
        
        Cancelled = 2
    }
}
