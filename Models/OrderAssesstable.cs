﻿using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class OrderAssesstable
{
    public int ONumber { get; set; }

    public double? OCscore { get; set; }

    public string? OCcomment { get; set; }

    public double? OFscore { get; set; }

    public string? OFcomment { get; set; }

    public virtual OrderDatatable ONumberNavigation { get; set; } = null!;
}
