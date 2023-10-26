using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public partial class Material
    {
        public Material()
        {
            Items = new HashSet<Item>();
        }

        public byte MaterialId { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
