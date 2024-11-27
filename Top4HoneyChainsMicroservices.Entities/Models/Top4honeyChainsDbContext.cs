using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Top4HoneyChainsMicroservices.Entities.Models;

public partial class Top4honeyChainsDbContext : DbContext
{
    public Top4honeyChainsDbContext()
    {
    }

    public Top4honeyChainsDbContext(DbContextOptions<Top4honeyChainsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Apiary> Apiaries { get; set; }

    public virtual DbSet<ApiaryDisease> ApiaryDiseases { get; set; }

    public virtual DbSet<ApiaryHoneyProduction> ApiaryHoneyProductions { get; set; }

    public virtual DbSet<ApiaryLocationType> ApiaryLocationTypes { get; set; }

    public virtual DbSet<ApiaryPhoto> ApiaryPhotos { get; set; }

    public virtual DbSet<ApirayTreatmentMethod> ApirayTreatmentMethods { get; set; }

    public virtual DbSet<AspnetApplication> AspnetApplications { get; set; }

    public virtual DbSet<AspnetMembership> AspnetMemberships { get; set; }

    public virtual DbSet<AspnetPath> AspnetPaths { get; set; }

    public virtual DbSet<AspnetPersonalizationAllUser> AspnetPersonalizationAllUsers { get; set; }

    public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }

    public virtual DbSet<AspnetProfile> AspnetProfiles { get; set; }

    public virtual DbSet<AspnetRole> AspnetRoles { get; set; }

    public virtual DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; }

    public virtual DbSet<AspnetUser> AspnetUsers { get; set; }

    public virtual DbSet<AspnetWebEventEvent> AspnetWebEventEvents { get; set; }

    public virtual DbSet<Beekeeper> Beekeepers { get; set; }

    public virtual DbSet<BeekeeperEducationLevel> BeekeeperEducationLevels { get; set; }

    public virtual DbSet<BeekeepingPurposeType> BeekeepingPurposeTypes { get; set; }

    public virtual DbSet<BeekeepingType> BeekeepingTypes { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<HoneyDistributionType> HoneyDistributionTypes { get; set; }

    public virtual DbSet<HoneyTest> HoneyTests { get; set; }

    public virtual DbSet<HoneyTestResult> HoneyTestResults { get; set; }

    public virtual DbSet<HoneyTestStandard> HoneyTestStandards { get; set; }

    public virtual DbSet<HoneyTestStandardItem> HoneyTestStandardItems { get; set; }

    public virtual DbSet<HoneyType> HoneyTypes { get; set; }

    public virtual DbSet<ProductionPeriod> ProductionPeriods { get; set; }

    public virtual DbSet<TreatmentMethod> TreatmentMethods { get; set; }

    public virtual DbSet<VwAspnetApplication> VwAspnetApplications { get; set; }

    public virtual DbSet<VwAspnetMembershipUser> VwAspnetMembershipUsers { get; set; }

    public virtual DbSet<VwAspnetProfile> VwAspnetProfiles { get; set; }

    public virtual DbSet<VwAspnetRole> VwAspnetRoles { get; set; }

    public virtual DbSet<VwAspnetUser> VwAspnetUsers { get; set; }

    public virtual DbSet<VwAspnetUsersInRole> VwAspnetUsersInRoles { get; set; }

    public virtual DbSet<VwAspnetWebPartStatePath> VwAspnetWebPartStatePaths { get; set; }

    public virtual DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShareds { get; set; }

    public virtual DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=HASAN\\MSSQLSERVER2017;Database=TOP4HoneyChainsDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apiary>(entity =>
        {
            entity.HasKey(e => e.ApiaryId).HasName("PK__Apiaries__7AF2440E983FF371");

            entity.Property(e => e.ApiaryQrcode).HasColumnName("ApiaryQRCode");
            entity.Property(e => e.ApiaryTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationLatitude).HasColumnType("decimal(12, 9)");
            entity.Property(e => e.LocationLongitude).HasColumnType("decimal(12, 9)");
        });

        modelBuilder.Entity<ApiaryDisease>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ApiaryBe__3214EC071B4205B7");
        });

        modelBuilder.Entity<ApiaryHoneyProduction>(entity =>
        {
            entity.HasKey(e => e.ProductionId).HasName("PK__ApiaryHo__D5D9A2D54CD1EFEC");

            entity.Property(e => e.ProductionAmount).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.ProductionDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ApiaryLocationType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__BeehiveL__516F03B56DA28CE6");

            entity.HasIndex(e => e.TypeTitle, "UQ__BeehiveL__E8252B9E06107E05").IsUnique();

            entity.Property(e => e.TypeTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ApiaryPhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__ApiaryPh__21B7B5E2D92C95F6");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Photo)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.PhotoDesc).IsUnicode(false);
        });

        modelBuilder.Entity<AspnetApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId)
                .HasName("PK__aspnet_A__C93A4C988C371CDB")
                .IsClustered(false);

            entity.ToTable("aspnet_Applications");

            entity.HasIndex(e => e.LoweredApplicationName, "UQ__aspnet_A__17477DE41CCD7C9C").IsUnique();

            entity.HasIndex(e => e.ApplicationName, "UQ__aspnet_A__309103319C8A5963").IsUnique();

            entity.HasIndex(e => e.LoweredApplicationName, "aspnet_Applications_Index").IsClustered();

            entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ApplicationName).HasMaxLength(256);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspnetMembership>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_M__1788CC4DFC5ACF50")
                .IsClustered(false);

            entity.ToTable("aspnet_Membership");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredEmail }, "aspnet_Membership_index").IsClustered();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredEmail).HasMaxLength(256);
            entity.Property(e => e.MobilePin)
                .HasMaxLength(16)
                .HasColumnName("MobilePIN");
            entity.Property(e => e.Password).HasMaxLength(128);
            entity.Property(e => e.PasswordAnswer).HasMaxLength(128);
            entity.Property(e => e.PasswordQuestion).HasMaxLength(256);
            entity.Property(e => e.PasswordSalt).HasMaxLength(128);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetMemberships)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__Appli__7132C993");

            entity.HasOne(d => d.User).WithOne(p => p.AspnetMembership)
                .HasForeignKey<AspnetMembership>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__UserI__7226EDCC");
        });

        modelBuilder.Entity<AspnetPath>(entity =>
        {
            entity.HasKey(e => e.PathId)
                .HasName("PK__aspnet_P__CD67DC588B4FACC3")
                .IsClustered(false);

            entity.ToTable("aspnet_Paths");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredPath }, "aspnet_Paths_index")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LoweredPath).HasMaxLength(256);
            entity.Property(e => e.Path).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetPaths)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pa__Appli__22CA2527");
        });

        modelBuilder.Entity<AspnetPersonalizationAllUser>(entity =>
        {
            entity.HasKey(e => e.PathId).HasName("PK__aspnet_P__CD67DC59BB766B83");

            entity.ToTable("aspnet_PersonalizationAllUsers");

            entity.Property(e => e.PathId).ValueGeneratedNever();
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PageSettings).HasColumnType("image");

            entity.HasOne(d => d.Path).WithOne(p => p.AspnetPersonalizationAllUser)
                .HasForeignKey<AspnetPersonalizationAllUser>(d => d.PathId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pe__PathI__2882FE7D");
        });

        modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__aspnet_P__3214EC06FCE7C696")
                .IsClustered(false);

            entity.ToTable("aspnet_PersonalizationPerUser");

            entity.HasIndex(e => new { e.PathId, e.UserId }, "aspnet_PersonalizationPerUser_index1")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.UserId, e.PathId }, "aspnet_PersonalizationPerUser_ncindex2").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PageSettings).HasColumnType("image");

            entity.HasOne(d => d.Path).WithMany(p => p.AspnetPersonalizationPerUsers)
                .HasForeignKey(d => d.PathId)
                .HasConstraintName("FK__aspnet_Pe__PathI__2C538F61");

            entity.HasOne(d => d.User).WithMany(p => p.AspnetPersonalizationPerUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__aspnet_Pe__UserI__2D47B39A");
        });

        modelBuilder.Entity<AspnetProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__aspnet_P__1788CC4CBDBE8E54");

            entity.ToTable("aspnet_Profile");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PropertyNames).HasColumnType("ntext");
            entity.Property(e => e.PropertyValuesBinary).HasColumnType("image");
            entity.Property(e => e.PropertyValuesString).HasColumnType("ntext");

            entity.HasOne(d => d.User).WithOne(p => p.AspnetProfile)
                .HasForeignKey<AspnetProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pr__UserI__062DE679");
        });

        modelBuilder.Entity<AspnetRole>(entity =>
        {
            entity.HasKey(e => e.RoleId)
                .HasName("PK__aspnet_R__8AFACE1BFB7EC83E")
                .IsClustered(false);

            entity.ToTable("aspnet_Roles");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName }, "aspnet_Roles_index1")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredRoleName).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetRoles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Ro__Appli__0FB750B3");
        });

        modelBuilder.Entity<AspnetSchemaVersion>(entity =>
        {
            entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion }).HasName("PK__aspnet_S__5A1E6BC133C68CC5");

            entity.ToTable("aspnet_SchemaVersions");

            entity.Property(e => e.Feature).HasMaxLength(128);
            entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
        });

        modelBuilder.Entity<AspnetUser>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_U__1788CC4DEC0391B0")
                .IsClustered(false);

            entity.ToTable("aspnet_Users");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName }, "aspnet_Users_Index")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.ApplicationId, e.LastActivityDate }, "aspnet_Users_Index2");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredUserName).HasMaxLength(256);
            entity.Property(e => e.MobileAlias)
                .HasMaxLength(16)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetUsers)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Us__Appli__60FC61CA");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspnetUsersInRole",
                    r => r.HasOne<AspnetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__aspnet_Us__RoleI__147C05D0"),
                    l => l.HasOne<AspnetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__aspnet_Us__UserI__1387E197"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__aspnet_U__AF2760AD2DA47DE7");
                        j.ToTable("aspnet_UsersInRoles");
                        j.HasIndex(new[] { "RoleId" }, "aspnet_UsersInRoles_index");
                    });
        });

        modelBuilder.Entity<AspnetWebEventEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__aspnet_W__7944C81073C6C167");

            entity.ToTable("aspnet_WebEvent_Events");

            entity.Property(e => e.EventId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApplicationPath).HasMaxLength(256);
            entity.Property(e => e.ApplicationVirtualPath).HasMaxLength(256);
            entity.Property(e => e.Details).HasColumnType("ntext");
            entity.Property(e => e.EventOccurrence).HasColumnType("decimal(19, 0)");
            entity.Property(e => e.EventSequence).HasColumnType("decimal(19, 0)");
            entity.Property(e => e.EventTime).HasColumnType("datetime");
            entity.Property(e => e.EventTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.EventType).HasMaxLength(256);
            entity.Property(e => e.ExceptionType).HasMaxLength(256);
            entity.Property(e => e.MachineName).HasMaxLength(256);
            entity.Property(e => e.Message).HasMaxLength(1024);
            entity.Property(e => e.RequestUrl).HasMaxLength(1024);
        });

        modelBuilder.Entity<Beekeeper>(entity =>
        {
            entity.HasKey(e => e.BeekeeperId).HasName("PK__Beekeepe__BA84374CB23C3AD9");

            entity.HasIndex(e => e.IdentityNumber, "UQ__Beekeepe__6354A73F23203E12").IsUnique();

            entity.Property(e => e.BeekeeperId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AssociationMembership)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.BusinessNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ExperienceTime).HasDefaultValue((short)0);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdentityNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePhoto).IsUnicode(false);
        });

        modelBuilder.Entity<BeekeeperEducationLevel>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__Educatio__09F03C266C53B106");

            entity.HasIndex(e => e.LevelTitle, "UQ__Educatio__84B18355CC86A2D3").IsUnique();

            entity.Property(e => e.LevelTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BeekeepingPurposeType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Beekeepi__516F03B529E304FF");

            entity.HasIndex(e => e.TypeTitle, "UQ__Beekeepi__E8252B9E466CAEF7").IsUnique();

            entity.Property(e => e.TypeTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BeekeepingType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Beekeepi__516F03B50C8DE081");

            entity.HasIndex(e => e.TypeTitle, "UQ__Beekeepi__E8252B9E1104749B").IsUnique();

            entity.Property(e => e.TypeTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasKey(e => e.DiseaseId).HasName("PK__BeehiveD__69B53389B2D5CFA8");

            entity.HasIndex(e => e.DiseaseTitle, "UQ__BeehiveD__C2AF8427E1B1733A").IsUnique();

            entity.Property(e => e.DiseaseTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HoneyDistributionType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__HoneyDis__516F03B565A580A2");

            entity.HasIndex(e => e.TypeTitle, "UQ__HoneyDis__E8252B9EBCA4C748").IsUnique();

            entity.Property(e => e.TypeTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HoneyTest>(entity =>
        {
            entity.HasKey(e => e.HoneyTestId).HasName("PK_Table_1");

            entity.ToTable(tb => tb.HasTrigger("TR_TestAdded"));

            entity.Property(e => e.HoneyTestDatetime).HasColumnType("datetime");
            entity.Property(e => e.HoneyTestTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HoneyTestResult>(entity =>
        {
            entity.HasKey(e => e.HoneyTestIresultd).HasName("PK__HoneyTes__3C2CE9E9E5842EF8");

            entity.Property(e => e.HoneyTestIresultd).HasColumnName("HoneyTestIResultd");
            entity.Property(e => e.HoneyTestItemValue)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HoneyTestStandard>(entity =>
        {
            entity.HasKey(e => e.StandardId);

            entity.Property(e => e.StandardDescription).IsUnicode(false);
            entity.Property(e => e.StandardTitle)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HoneyTestStandardItem>(entity =>
        {
            entity.Property(e => e.HoneyTestItemDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoneyTestItemTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoneyTestItemUnit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceRangeValue)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HoneyType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__HoneyTyp__516F03B59C57B810");

            entity.HasIndex(e => e.TypeTitle, "UQ__HoneyTyp__E8252B9E79E7B6B2").IsUnique();

            entity.Property(e => e.TypeTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductionPeriod>(entity =>
        {
            entity.HasKey(e => e.ProductionPeriodId).HasName("PK__Producti__EB4172B14E971992");

            entity.Property(e => e.ProductionPeriodEndDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProductionPeriodStartDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProductionPeriodTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TreatmentMethod>(entity =>
        {
            entity.HasKey(e => e.TreatmentId);

            entity.Property(e => e.TreatmentDesc)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.TreatmentTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwAspnetApplication>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Applications");

            entity.Property(e => e.ApplicationName).HasMaxLength(256);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetMembershipUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_MembershipUsers");

            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredEmail).HasMaxLength(256);
            entity.Property(e => e.MobileAlias).HasMaxLength(16);
            entity.Property(e => e.MobilePin)
                .HasMaxLength(16)
                .HasColumnName("MobilePIN");
            entity.Property(e => e.PasswordAnswer).HasMaxLength(128);
            entity.Property(e => e.PasswordQuestion).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetProfile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Profiles");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwAspnetRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Roles");

            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredRoleName).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Users");

            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredUserName).HasMaxLength(256);
            entity.Property(e => e.MobileAlias).HasMaxLength(16);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetUsersInRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_UsersInRoles");
        });

        modelBuilder.Entity<VwAspnetWebPartStatePath>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_Paths");

            entity.Property(e => e.LoweredPath).HasMaxLength(256);
            entity.Property(e => e.Path).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetWebPartStateShared>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_Shared");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwAspnetWebPartStateUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_User");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
