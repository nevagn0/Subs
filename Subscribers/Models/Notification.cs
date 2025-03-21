using System;
using System.Collections.Generic;

namespace Subscribers.Models;

public partial class Notification
{
    public string? Messegetext { get; set; }

    public int? Iduser { get; set; }

    public int? Idsub { get; set; }

    public int Id { get; set; }

    public virtual Subcrib? IdsubNavigation { get; set; }

    public virtual User? IduserNavigation { get; set; }
}
