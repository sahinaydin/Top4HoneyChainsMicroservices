using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class TreatmentMethod
{
    public int TreatmentId { get; set; }

    public string? TreatmentTitle { get; set; }

    public string? TreatmentDesc { get; set; }
}
