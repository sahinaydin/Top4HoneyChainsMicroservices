using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class HoneyTestResult
{
    public int HoneyTestIresultd { get; set; }

    public int HoneyTestId { get; set; }

    public int? HoneyTestStandardItemId { get; set; }

    public string? HoneyTestItemValue { get; set; }
}
