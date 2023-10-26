using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebService.Models
{
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }

        public byte CategoryId { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Item> Items { get; set; }
    }
}
