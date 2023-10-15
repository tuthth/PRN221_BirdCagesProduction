using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Material
{
    public int MaterialId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
