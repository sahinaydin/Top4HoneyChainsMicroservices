using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class ApiaryDisease
{
    public int Id { get; set; }

    public int? DiseaseId { get; set; }

    public int? ApiaryId { get; set; }

    public int? ProductionPeriodId { get; set; }
}
