using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public partial class Measure
    {
        public Measure()
        {
            Items = new HashSet<Item>();
        }

        public byte MeasureId { get; set; }
        public string? Symbol { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
