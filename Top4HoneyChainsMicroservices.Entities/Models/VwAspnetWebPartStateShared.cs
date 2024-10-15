using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class VwAspnetWebPartStateShared
{
    public Guid PathId { get; set; }

    public int? DataSize { get; set; }

    public DateTime LastUpdatedDate { get; set; }
}
