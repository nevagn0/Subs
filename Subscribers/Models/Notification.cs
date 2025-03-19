using System;
using System.Collections.Generic;

namespace Subscribers.Models;

public partial class Notification
{
    public int Id { get; set; }

    public string? Messegetext { get; set; }

    public int? Iduser { get; set; }

    public int? Idsub { get; set; }

    public virtual Subuser? Subuser { get; set; }
}
