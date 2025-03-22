using System;
using System.Collections.Generic;

namespace Subscribers.Models;

public partial class Subcrib
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Discription { get; set; }

    public string? Type { get; set; }

    public decimal Price { get; set; }

    public int? Iduser { get; set; }

    public DateOnly Endtime { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual User? IduserNavigation { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
