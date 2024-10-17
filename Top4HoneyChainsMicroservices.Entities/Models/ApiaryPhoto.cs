using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class ApiaryPhoto
{
    public int PhotoId { get; set; }

    public int? ApiaryId { get; set; }

    public string Photo { get; set; }

    public string PhotoDesc { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int ProductionPeriodId { get; set; }

    public bool Approved { get; set; }
}
