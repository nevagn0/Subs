using System;
using System.Collections.Generic;

namespace Subscribers.Models;

public partial class User
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string? Secondname { get; set; }

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Subuser> Subusers { get; set; } = new List<Subuser>();
}
