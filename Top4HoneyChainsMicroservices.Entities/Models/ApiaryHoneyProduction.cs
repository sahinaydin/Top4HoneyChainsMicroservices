using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class ApiaryHoneyProduction
{
    public int ProductionId { get; set; }

    public int? ApiaryId { get; set; }

    public int? ProductionPeriodId { get; set; }

    public int? ProducedHoneyType { get; set; }

    public int? HoneyDistributionType { get; set; }

    public decimal? ProductionAmount { get; set; }

    public DateOnly? ProductionDate { get; set; }
}
