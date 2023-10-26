using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public partial class Requirement
    {
        public Requirement()
        {
            Concepts = new HashSet<Concept>();
        }

        public int RequiId { get; set; }
        public short? Account { get; set; }
        public string? Description { get; set; }
        public byte? Status { get; set; }
        public DateTime Date { get; set; }
        public short? Responsable { get; set; }
        public byte? RequiStatus { get; set; }

        public virtual Account? AccountNavigation { get; set; }
        public virtual Account? ResponsableNavigation { get; set; }
        public virtual RequirementStatus? StatusNavigation { get; set; }
        public virtual ICollection<Concept> Concepts { get; set; }
    }
}
