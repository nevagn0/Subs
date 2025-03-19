using System;
using System.Collections.Generic;

namespace Subscribers.Models;

public partial class Expense
{
    public int Id { get; set; }

    public int? Iduser { get; set; }

    public int? Idsub { get; set; }

    public decimal? TotalCost { get; set; }

    public virtual Subuser? Subuser { get; set; }
}
