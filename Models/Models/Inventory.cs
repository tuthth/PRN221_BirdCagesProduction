using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int? MaterialId { get; set; }

    public int? Quantity { get; set; }

    public virtual Material? Material { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
