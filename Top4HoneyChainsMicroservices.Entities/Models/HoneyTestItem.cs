using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class HoneyTestItem
{
    public int HoneyTestItemId { get; set; }

    public string HoneyTestItemTitle { get; set; } = null!;
}
