using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class WorkOn
{
    public int WorkOnId { get; set; }

    public int? StepId { get; set; }

    public int? StaffId { get; set; }

    public virtual Staff? Staff { get; set; }

    public virtual ProductionStep? Step { get; set; }
}
