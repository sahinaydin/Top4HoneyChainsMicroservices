using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class Disease
{
    public int DiseaseId { get; set; }

    public string DiseaseTitle { get; set; } = null!;
}
