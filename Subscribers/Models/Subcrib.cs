using System;
using System.Collections.Generic;

namespace Subscribers.Models;

public partial class Subcrib
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Discription { get; set; }

    public string? Type { get; set; }

    public decimal? Price { get; set; }
}
