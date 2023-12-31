﻿using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class TalkDatatable
{
    public int TNumber { get; set; }

    public int CNumber { get; set; }

    public int FNumber { get; set; }

    public DateTime TTime { get; set; }

    public string TMessage { get; set; } = null!;

    public int TRead { get; set; }

    public int TPost { get; set; }

    public virtual CustomerAccounttable CNumberNavigation { get; set; } = null!;

    public virtual FirmAccounttable FNumberNavigation { get; set; } = null!;
}
