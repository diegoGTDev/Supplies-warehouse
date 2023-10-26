using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public partial class Concept
    {
        public int ConceptId { get; set; }
        public int? RequiId { get; set; }
        public string? SupllyCode { get; set; }
        public short Unts { get; set; }

        public virtual Requirement? Requi { get; set; }
        public virtual Item? SupllyCodeNavigation { get; set; }
    }
}
