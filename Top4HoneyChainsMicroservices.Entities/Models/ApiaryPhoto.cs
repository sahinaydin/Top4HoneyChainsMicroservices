using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class ApiaryPhoto
{
    public int PhotoId { get; set; }

    public int? ApiaryId { get; set; }

    public string? PhotoDesc { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ProductionPeriodId { get; set; }

    public bool? Approved { get; set; }

    public byte[]? ImageData { get; set; }

    public string? PhotoFileName { get; set; }

    public string? ContentType { get; set; }
}
