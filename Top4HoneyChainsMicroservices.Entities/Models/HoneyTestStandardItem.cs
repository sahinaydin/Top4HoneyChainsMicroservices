using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class HoneyTestStandardItem
{
    public int HoneyTestStandardItemId { get; set; }

    public int? HoneyStandardId { get; set; }

    public int? HoneyTestItemId { get; set; }

    public string? ReferenceRangeValue { get; set; }

    public string? HoneyTestItemUnit { get; set; }
}
