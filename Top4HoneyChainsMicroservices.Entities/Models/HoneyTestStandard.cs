using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class HoneyTestStandard
{
    public int StandardId { get; set; }

    public string? StandardTitle { get; set; }

    public string? StandardDescription { get; set; }
}
