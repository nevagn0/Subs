using System;
using System.Collections.Generic;

namespace Subscribers.Models;

public partial class Subuser
{
    public int Iduser { get; set; }

    public int Idsub { get; set; }

    public DateOnly? Starttime { get; set; }

    public DateOnly? Endtime { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual Subcrib IdsubNavigation { get; set; } = null!;

    public virtual User IduserNavigation { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
