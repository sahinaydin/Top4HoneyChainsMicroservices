using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class BeekeeperEducationLevel
{
    public int LevelId { get; set; }

    public string LevelTitle { get; set; } = null!;
}
