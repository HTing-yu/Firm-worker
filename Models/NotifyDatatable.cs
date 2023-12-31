﻿using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class NotifyDatatable
{
    public int NNumber { get; set; }

    public int? CNumber { get; set; }

    public int? FNumber { get; set; }

    public int ONumber { get; set; }

    public string OStatus { get; set; } = null!;

    public bool? NRead { get; set; }

    public virtual CustomerAccounttable? CNumberNavigation { get; set; }

    public virtual FirmAccounttable? FNumberNavigation { get; set; }

    public virtual OrderDatatable ONumberNavigation { get; set; } = null!;
}
