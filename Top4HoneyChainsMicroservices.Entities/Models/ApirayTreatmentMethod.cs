using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class ApirayTreatmentMethod
{
    public int Id { get; set; }

    public int? ApirayId { get; set; }

    public int? TreatmentMethodId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? ProductionPeriodId { get; set; }
}
