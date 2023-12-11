using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebService.Models
{
    public partial class Requirement
    {
        public Requirement()
        {
            Concepts = new HashSet<Concept>();
            Status = (int)StatusEnum.EXIST;
        }

        public int RequiId { get; set; }
        public short? Account { get; set; }
        public string? Description { get; set; }
        public byte? Status { get; set; }
        public DateTime Date { get; set; }
        public short? Responsable { get; set; }
        public byte? RequiStatus { get; set; }

        [JsonIgnore]
        public virtual Account? AccountNavigation { get; set; }
        [JsonIgnore]
        public virtual Account? ResponsableNavigation { get; set; }
        [JsonIgnore]
        public virtual RequirementStatus? StatusNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Concept> Concepts { get; set; }
    }

    public enum StatusEnum{
        EXIST = 1,
        DELETED = 0
    }
}
