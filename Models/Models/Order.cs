using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? DatePlaced { get; set; }

    public int? ExpenseId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Expense? Expense { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
