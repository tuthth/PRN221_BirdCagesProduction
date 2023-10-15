using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class ProductionStep
{
    public int StepId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<WorkOn> WorkOns { get; set; } = new List<WorkOn>();
}
