using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class HoneyTest
{
    public int HoneyTestId { get; set; }

    public string? HoneyTestTitle { get; set; }

    public DateTime? HoneyTestDatetime { get; set; }

    public int? ApiaryId { get; set; }
}
