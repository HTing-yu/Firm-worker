﻿using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class ProductDatatable
{
    public int FNumber { get; set; }

    public int PNumber { get; set; }

    public string PName { get; set; } = null!;

    public string? PSpec { get; set; }

    public string PCategory { get; set; } = null!;

    public int PPrice { get; set; }

    public string? PDescribe { get; set; }

    public string? PSavedate { get; set; }

    public string? PSaveway { get; set; }

    public int PInventory { get; set; }

    public int? PShip { get; set; }

    public int? PPayment { get; set; }

    public virtual FirmAccounttable FNumberNavigation { get; set; } = null!;

    public virtual ICollection<GroupDatatable> GroupDatatables { get; set; } = new List<GroupDatatable>();

    public virtual ICollection<OrderDatatable> OrderDatatables { get; set; } = new List<OrderDatatable>();

    public virtual ICollection<ProductPicturetable> ProductPicturetables { get; set; } = new List<ProductPicturetable>();

    public virtual ICollection<PaymentDatatable> PaymentNumbers { get; set; } = new List<PaymentDatatable>();

    public virtual ICollection<ShipDatatable> ShipNumbers { get; set; } = new List<ShipDatatable>();
}
