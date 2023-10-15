using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Expense
{
    public int ExpenseId { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public DateTime? DateIncurred { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
