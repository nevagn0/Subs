using System;
using System.Collections.Generic;

namespace Subscribers.Models;

public partial class Analy
{
    public int? Idexp { get; set; }

    public int Id { get; set; }

    public virtual Expense? IdexpNavigation { get; set; }
}
