using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public partial class Location
    {
        public Location()
        {
            Items = new HashSet<Item>();
        }

        public byte LocationId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
