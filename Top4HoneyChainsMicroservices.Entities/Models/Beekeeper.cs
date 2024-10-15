using System;
using System.Collections.Generic;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class Beekeeper
{
    public Guid BeekeeperId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? IdentityNumber { get; set; }

    public DateOnly BirthDate { get; set; }

    public short? ExperienceTime { get; set; }

    public int? EducationLevel { get; set; }

    public bool? CertificationInfo { get; set; }

    public string? AssociationMembership { get; set; }

    public string BusinessNumber { get; set; } = null!;

    public int? BeekeepingPurposeType { get; set; }

    public int? BeekeepingType { get; set; }
}
