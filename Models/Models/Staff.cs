using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<WorkOn> WorkOns { get; set; } = new List<WorkOn>();
}
