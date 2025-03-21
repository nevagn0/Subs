using System;
using System.Collections.Generic;

namespace Subscribers.Models;

public partial class Expense
{
    public int? Iduser { get; set; }

    public int? Idsub { get; set; }

    public decimal? TotalCost { get; set; }

    public int Id { get; set; }

    public virtual ICollection<Analy> Analies { get; set; } = new List<Analy>();

    public virtual Subuser? Subuser { get; set; }
}
