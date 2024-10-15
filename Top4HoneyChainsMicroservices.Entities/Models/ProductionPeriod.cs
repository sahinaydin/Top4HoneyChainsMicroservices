using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class ProductionPeriod
{
    public int ProductionPeriodId { get; set; }

    public string? ProductionPeriodTitle { get; set; }

    public DateOnly? ProductionPeriodStartDate { get; set; }

    public DateOnly? ProductionPeriodEndDate { get; set; }
}
