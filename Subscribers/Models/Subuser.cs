using System;
using System.Collections.Generic;

namespace Subscribers.Models;

public partial class Subuser
{
    public int Iduser { get; set; }

    public int Idsub { get; set; }

    public DateOnly? Starttime { get; set; }

    public DateOnly? Endtime { get; set; }
}
