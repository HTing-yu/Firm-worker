﻿using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class MemberMembertable
{
    public int MNumber { get; set; }

    public int GNumber { get; set; }

    public int GMaxpeople { get; set; }

    public int MNowpeople { get; set; }

    public bool MStatus { get; set; }

    public virtual GroupDatatable GNumberNavigation { get; set; } = null!;
}
