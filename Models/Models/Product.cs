using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? StepId { get; set; }

    public int InventoryId { get; set; }

    public virtual Inventory Inventory { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ProductionStep? Step { get; set; }
}
