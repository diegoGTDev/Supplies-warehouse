using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebService.Models
{
    public partial class Item
    {
        public Item()
        {
            Concepts = new HashSet<Concept>();
        }

        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public byte? Category { get; set; }
        public byte? Measure { get; set; }
        public byte? Location { get; set; }
        public byte? Material { get; set; }
        public short? Quantity { get; set; }

        [JsonIgnore]
        public virtual Category? CategoryNavigation { get; set; }
        [JsonIgnore]
        public virtual Location? LocationNavigation { get; set; }
        [JsonIgnore]
        public virtual Material? MaterialNavigation { get; set; }
        [JsonIgnore]
        public virtual Measure? MeasureNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<Concept> Concepts { get; set; }
    }
}
