namespace Questar.OneRoster.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "DataProtectionKey",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FriendlyName = table.Column<string>(nullable: true),
                    Xml = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_DataProtectionKey", x => x.Id); });

            migrationBuilder.CreateTable(
                "Grade",
                table => new { Id = table.Column<Guid>(), Code = table.Column<string>() },
                constraints: table => { table.PrimaryKey("PK_Grade", x => x.Id); });

            migrationBuilder.CreateTable(
                "MetadataCollection",
                table => new { MetadataCollectionId = table.Column<Guid>() },
                constraints: table => { table.PrimaryKey("PK_MetadataCollection", x => x.MetadataCollectionId); });

            migrationBuilder.CreateTable(
                "Role",
                table => new { Id = table.Column<Guid>(), Name = table.Column<string>(maxLength: 256, nullable: true), NormalizedName = table.Column<string>(maxLength: 256, nullable: true), ConcurrencyStamp = table.Column<string>(nullable: true) },
                constraints: table => { table.PrimaryKey("PK_Role", x => x.Id); });

            migrationBuilder.CreateTable(
                "Subject",
                table => new { Id = table.Column<Guid>(), Name = table.Column<string>(), Code = table.Column<string>() },
                constraints: table => { table.PrimaryKey("PK_Subject", x => x.Id); });

            migrationBuilder.CreateTable(
                "AcademicSession",
                table => new
                {
                    Type = table.Column<int>(),
                    Title = table.Column<string>(maxLength: 256),
                    StartDate = table.Column<DateTime>(),
                    EndDate = table.Column<DateTime>(),
                    ParentId = table.Column<Guid>(nullable: true),
                    SchoolYear = table.Column<int>(),
                    Id = table.Column<Guid>(),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(),
                    Modified = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicSession", x => x.Id);
                    table.ForeignKey(
                        "FK_AcademicSession_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AcademicSession_AcademicSession_ParentId",
                        x => x.ParentId,
                        "AcademicSession",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Category",
                table => new
                {
                    Title = table.Column<string>(),
                    Id = table.Column<Guid>(),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(),
                    Modified = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        "FK_Category_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Metadata",
                table => new { CollectionId = table.Column<Guid>(), Key = table.Column<string>(maxLength: 64), Value = table.Column<string>(maxLength: 256, nullable: true) },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => new { x.CollectionId, x.Key });
                    table.ForeignKey(
                        "FK_Metadata_MetadataCollection_CollectionId",
                        x => x.CollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Org",
                table => new
                {
                    Name = table.Column<string>(maxLength: 256),
                    Type = table.Column<int>(),
                    Identifier = table.Column<string>(maxLength: 256, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(),
                    Modified = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Org", x => x.Id);
                    table.ForeignKey(
                        "FK_Org_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Org_Org_ParentId",
                        x => x.ParentId,
                        "Org",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Resource",
                table => new
                {
                    Title = table.Column<string>(maxLength: 64, nullable: true),
                    Importance = table.Column<int>(),
                    VendorResourceId = table.Column<string>(maxLength: 256),
                    VendorId = table.Column<string>(maxLength: 256, nullable: true),
                    ApplicationId = table.Column<string>(maxLength: 256, nullable: true),
                    Id = table.Column<Guid>(),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(),
                    Modified = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                    table.ForeignKey(
                        "FK_Resource_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "User",
                table => new
                {
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(),
                    TwoFactorEnabled = table.Column<bool>(),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(),
                    AccessFailedCount = table.Column<int>(),
                    Id = table.Column<Guid>(),
                    Type = table.Column<int>(),
                    Enabled = table.Column<bool>(),
                    GivenName = table.Column<string>(maxLength: 64),
                    MiddleName = table.Column<string>(maxLength: 64, nullable: true),
                    FamilyName = table.Column<string>(maxLength: 64),
                    Identifier = table.Column<string>(nullable: true),
                    Sms = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(),
                    Modified = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        "FK_User_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "RoleClaim",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        "FK_RoleClaim_Role_RoleId",
                        x => x.RoleId,
                        "Role",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Course",
                table => new
                {
                    Title = table.Column<string>(maxLength: 256),
                    Code = table.Column<string>(maxLength: 256, nullable: true),
                    SchoolYearId = table.Column<Guid>(),
                    OrgId = table.Column<Guid>(),
                    Id = table.Column<Guid>(),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(),
                    Modified = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        "FK_Course_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Course_Org_OrgId",
                        x => x.OrgId,
                        "Org",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Course_AcademicSession_SchoolYearId",
                        x => x.SchoolYearId,
                        "AcademicSession",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ResourceRole",
                table => new { ResourceId = table.Column<Guid>(), Role = table.Column<int>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceRole", x => new { x.ResourceId, x.Role });
                    table.ForeignKey(
                        "FK_ResourceRole_Resource_ResourceId",
                        x => x.ResourceId,
                        "Resource",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Demographics",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Sex = table.Column<int>(nullable: true),
                    AmericanIndianOrAlaskaNative = table.Column<bool>(nullable: true),
                    Asian = table.Column<bool>(nullable: true),
                    BlackOrAfricanAmerican = table.Column<bool>(nullable: true),
                    NativeHawaiianOrOtherPacificIslander = table.Column<bool>(nullable: true),
                    White = table.Column<bool>(nullable: true),
                    DemographicRaceTwoOrMoreRaces = table.Column<bool>(nullable: true),
                    HispanicOrLatinoEthnicity = table.Column<bool>(nullable: true),
                    CountryOfBirthCode = table.Column<string>(nullable: true),
                    StateOfBirthAbbreviation = table.Column<string>(nullable: true),
                    CityOfBirth = table.Column<string>(nullable: true),
                    PublicSchoolResidenceStatus = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(),
                    Modified = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographics", x => x.Id);
                    table.ForeignKey(
                        "FK_Demographics_User_Id",
                        x => x.Id,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Demographics_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Demographics_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "UserAgent",
                table => new { UserId = table.Column<Guid>(), AgentId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAgent", x => new { x.UserId, x.AgentId });
                    table.ForeignKey(
                        "FK_UserAgent_User_AgentId",
                        x => x.AgentId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserAgent_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "UserClaim",
                table => new
                {
                    UserId = table.Column<Guid>(),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        "FK_UserClaim_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserGrade",
                table => new { UserId = table.Column<Guid>(), GradeId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGrade", x => new { x.UserId, x.GradeId });
                    table.ForeignKey(
                        "FK_UserGrade_Grade_GradeId",
                        x => x.GradeId,
                        "Grade",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserGrade_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserIdentifier",
                table => new { UserId = table.Column<Guid>(), Type = table.Column<string>(maxLength: 256), Identifier = table.Column<string>(maxLength: 256) },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIdentifier", x => new { x.UserId, x.Type, x.Identifier });
                    table.ForeignKey(
                        "FK_UserIdentifier_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserLogin",
                table => new { LoginProvider = table.Column<string>(), ProviderKey = table.Column<string>(), ProviderDisplayName = table.Column<string>(nullable: true), UserId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        "FK_UserLogin_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserOrg",
                table => new { UserId = table.Column<Guid>(), OrgId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrg", x => new { x.UserId, x.OrgId });
                    table.ForeignKey(
                        "FK_UserOrg_Org_OrgId",
                        x => x.OrgId,
                        "Org",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserOrg_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserRole",
                table => new { UserId = table.Column<Guid>(), RoleId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        "FK_UserRole_Role_RoleId",
                        x => x.RoleId,
                        "Role",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserRole_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserToken",
                table => new { LoginProvider = table.Column<string>(), Name = table.Column<string>(), Value = table.Column<string>(nullable: true), UserId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        "FK_UserToken_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Class",
                table => new
                {
                    Type = table.Column<int>(),
                    Title = table.Column<string>(maxLength: 256),
                    Code = table.Column<string>(maxLength: 32, nullable: true),
                    Location = table.Column<string>(maxLength: 256, nullable: true),
                    CourseId = table.Column<Guid>(),
                    SchoolId = table.Column<Guid>(),
                    Id = table.Column<Guid>(),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(),
                    Modified = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        "FK_Class_Course_CourseId",
                        x => x.CourseId,
                        "Course",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Class_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Class_Org_SchoolId",
                        x => x.SchoolId,
                        "Org",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "CourseGrade",
                table => new { CourseId = table.Column<Guid>(), GradeId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGrade", x => new { x.CourseId, x.GradeId });
                    table.ForeignKey(
                        "FK_CourseGrade_Course_CourseId",
                        x => x.CourseId,
                        "Course",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CourseGrade_Grade_GradeId",
                        x => x.GradeId,
                        "Grade",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "CourseResource",
                table => new { CourseId = table.Column<Guid>(), ResourceId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResource", x => new { x.CourseId, x.ResourceId });
                    table.ForeignKey(
                        "FK_CourseResource_Course_CourseId",
                        x => x.CourseId,
                        "Course",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CourseResource_Resource_ResourceId",
                        x => x.ResourceId,
                        "Resource",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "CourseSubject",
                table => new { CourseId = table.Column<Guid>(), SubjectId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubject", x => new { x.CourseId, x.SubjectId });
                    table.ForeignKey(
                        "FK_CourseSubject_Course_CourseId",
                        x => x.CourseId,
                        "Course",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CourseSubject_Subject_SubjectId",
                        x => x.SubjectId,
                        "Subject",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClassAcademicSession",
                table => new { ClassId = table.Column<Guid>(), AcademicSessionId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAcademicSession", x => new { x.ClassId, x.AcademicSessionId });
                    table.ForeignKey(
                        "FK_ClassAcademicSession_AcademicSession_AcademicSessionId",
                        x => x.AcademicSessionId,
                        "AcademicSession",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ClassAcademicSession_Class_ClassId",
                        x => x.ClassId,
                        "Class",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "ClassGrade",
                table => new { ClassId = table.Column<Guid>(), GradeId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassGrade", x => new { x.ClassId, x.GradeId });
                    table.ForeignKey(
                        "FK_ClassGrade_Class_ClassId",
                        x => x.ClassId,
                        "Class",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ClassGrade_Grade_GradeId",
                        x => x.GradeId,
                        "Grade",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClassPeriod",
                table => new { ClassId = table.Column<Guid>(), Period = table.Column<string>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPeriod", x => new { x.ClassId, x.Period });
                    table.ForeignKey(
                        "FK_ClassPeriod_Class_ClassId",
                        x => x.ClassId,
                        "Class",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClassResource",
                table => new { ClassId = table.Column<Guid>(), ResourceId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassResource", x => new { x.ClassId, x.ResourceId });
                    table.ForeignKey(
                        "FK_ClassResource_Class_ClassId",
                        x => x.ClassId,
                        "Class",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ClassResource_Resource_ResourceId",
                        x => x.ResourceId,
                        "Resource",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClassSubject",
                table => new { ClassId = table.Column<Guid>(), SubjectId = table.Column<Guid>() },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubject", x => new { x.ClassId, x.SubjectId });
                    table.ForeignKey(
                        "FK_ClassSubject_Class_ClassId",
                        x => x.ClassId,
                        "Class",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ClassSubject_Subject_SubjectId",
                        x => x.SubjectId,
                        "Subject",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Enrollment",
                table => new
                {
                    BeginDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(),
                    ClassId = table.Column<Guid>(),
                    Primary = table.Column<bool>(nullable: true),
                    Id = table.Column<Guid>(),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(),
                    Modified = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Id);
                    table.ForeignKey(
                        "FK_Enrollment_Class_ClassId",
                        x => x.ClassId,
                        "Class",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Enrollment_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Enrollment_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "LineItem",
                table => new
                {
                    Title = table.Column<string>(),
                    Description = table.Column<string>(nullable: true),
                    AssignDate = table.Column<DateTime>(),
                    DueDate = table.Column<DateTime>(),
                    ClassId = table.Column<Guid>(),
                    CategoryId = table.Column<Guid>(),
                    GradingPeriodId = table.Column<Guid>(),
                    ResultValueMin = table.Column<float>(),
                    ResultValueMax = table.Column<float>(),
                    Id = table.Column<Guid>(),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(),
                    Modified = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.Id);
                    table.ForeignKey(
                        "FK_LineItem_Category_CategoryId",
                        x => x.CategoryId,
                        "Category",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_LineItem_Class_ClassId",
                        x => x.ClassId,
                        "Class",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_LineItem_AcademicSession_GradingPeriodId",
                        x => x.GradingPeriodId,
                        "AcademicSession",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_LineItem_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Result",
                table => new
                {
                    Comment = table.Column<string>(nullable: true),
                    LineItemId = table.Column<Guid>(),
                    StudentId = table.Column<Guid>(),
                    Score = table.Column<float>(),
                    ScoreDate = table.Column<DateTime>(),
                    ScoreStatus = table.Column<int>(),
                    Id = table.Column<Guid>(),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(),
                    Modified = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        "FK_Result_LineItem_LineItemId",
                        x => x.LineItemId,
                        "LineItem",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Result_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Result_User_StudentId",
                        x => x.StudentId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AcademicSession_MetadataCollectionId",
                "AcademicSession",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_AcademicSession_ParentId",
                "AcademicSession",
                "ParentId");

            migrationBuilder.CreateIndex(
                "IX_Category_MetadataCollectionId",
                "Category",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Class_CourseId",
                "Class",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_Class_MetadataCollectionId",
                "Class",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Class_SchoolId",
                "Class",
                "SchoolId");

            migrationBuilder.CreateIndex(
                "IX_ClassAcademicSession_AcademicSessionId",
                "ClassAcademicSession",
                "AcademicSessionId");

            migrationBuilder.CreateIndex(
                "IX_ClassGrade_GradeId",
                "ClassGrade",
                "GradeId");

            migrationBuilder.CreateIndex(
                "IX_ClassResource_ResourceId",
                "ClassResource",
                "ResourceId");

            migrationBuilder.CreateIndex(
                "IX_ClassSubject_SubjectId",
                "ClassSubject",
                "SubjectId");

            migrationBuilder.CreateIndex(
                "IX_Course_MetadataCollectionId",
                "Course",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Course_OrgId",
                "Course",
                "OrgId");

            migrationBuilder.CreateIndex(
                "IX_Course_SchoolYearId",
                "Course",
                "SchoolYearId");

            migrationBuilder.CreateIndex(
                "IX_CourseGrade_GradeId",
                "CourseGrade",
                "GradeId");

            migrationBuilder.CreateIndex(
                "IX_CourseResource_ResourceId",
                "CourseResource",
                "ResourceId");

            migrationBuilder.CreateIndex(
                "IX_CourseSubject_SubjectId",
                "CourseSubject",
                "SubjectId");

            migrationBuilder.CreateIndex(
                "IX_Demographics_MetadataCollectionId",
                "Demographics",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Demographics_UserId",
                "Demographics",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_Enrollment_ClassId",
                "Enrollment",
                "ClassId");

            migrationBuilder.CreateIndex(
                "IX_Enrollment_MetadataCollectionId",
                "Enrollment",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Enrollment_UserId",
                "Enrollment",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_Grade_Code",
                "Grade",
                "Code");

            migrationBuilder.CreateIndex(
                "IX_LineItem_CategoryId",
                "LineItem",
                "CategoryId");

            migrationBuilder.CreateIndex(
                "IX_LineItem_ClassId",
                "LineItem",
                "ClassId");

            migrationBuilder.CreateIndex(
                "IX_LineItem_GradingPeriodId",
                "LineItem",
                "GradingPeriodId");

            migrationBuilder.CreateIndex(
                "IX_LineItem_MetadataCollectionId",
                "LineItem",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Org_Identifier",
                "Org",
                "Identifier");

            migrationBuilder.CreateIndex(
                "IX_Org_MetadataCollectionId",
                "Org",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Org_ParentId",
                "Org",
                "ParentId");

            migrationBuilder.CreateIndex(
                "IX_Resource_MetadataCollectionId",
                "Resource",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Result_LineItemId",
                "Result",
                "LineItemId");

            migrationBuilder.CreateIndex(
                "IX_Result_MetadataCollectionId",
                "Result",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Result_StudentId",
                "Result",
                "StudentId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "Role",
                "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_RoleClaim_RoleId",
                "RoleClaim",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_Subject_Code",
                "Subject",
                "Code");

            migrationBuilder.CreateIndex(
                "IX_User_Identifier",
                "User",
                "Identifier");

            migrationBuilder.CreateIndex(
                "IX_User_MetadataCollectionId",
                "User",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "User",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "User",
                "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_UserAgent_AgentId",
                "UserAgent",
                "AgentId");

            migrationBuilder.CreateIndex(
                "IX_UserClaim_UserId",
                "UserClaim",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserGrade_GradeId",
                "UserGrade",
                "GradeId");

            migrationBuilder.CreateIndex(
                "IX_UserLogin_UserId",
                "UserLogin",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserOrg_OrgId",
                "UserOrg",
                "OrgId");

            migrationBuilder.CreateIndex(
                "IX_UserRole_RoleId",
                "UserRole",
                "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "ClassAcademicSession");

            migrationBuilder.DropTable(
                "ClassGrade");

            migrationBuilder.DropTable(
                "ClassPeriod");

            migrationBuilder.DropTable(
                "ClassResource");

            migrationBuilder.DropTable(
                "ClassSubject");

            migrationBuilder.DropTable(
                "CourseGrade");

            migrationBuilder.DropTable(
                "CourseResource");

            migrationBuilder.DropTable(
                "CourseSubject");

            migrationBuilder.DropTable(
                "DataProtectionKey");

            migrationBuilder.DropTable(
                "Demographics");

            migrationBuilder.DropTable(
                "Enrollment");

            migrationBuilder.DropTable(
                "Metadata");

            migrationBuilder.DropTable(
                "ResourceRole");

            migrationBuilder.DropTable(
                "Result");

            migrationBuilder.DropTable(
                "RoleClaim");

            migrationBuilder.DropTable(
                "UserAgent");

            migrationBuilder.DropTable(
                "UserClaim");

            migrationBuilder.DropTable(
                "UserGrade");

            migrationBuilder.DropTable(
                "UserIdentifier");

            migrationBuilder.DropTable(
                "UserLogin");

            migrationBuilder.DropTable(
                "UserOrg");

            migrationBuilder.DropTable(
                "UserRole");

            migrationBuilder.DropTable(
                "UserToken");

            migrationBuilder.DropTable(
                "Subject");

            migrationBuilder.DropTable(
                "Resource");

            migrationBuilder.DropTable(
                "LineItem");

            migrationBuilder.DropTable(
                "Grade");

            migrationBuilder.DropTable(
                "Role");

            migrationBuilder.DropTable(
                "User");

            migrationBuilder.DropTable(
                "Category");

            migrationBuilder.DropTable(
                "Class");

            migrationBuilder.DropTable(
                "Course");

            migrationBuilder.DropTable(
                "Org");

            migrationBuilder.DropTable(
                "AcademicSession");

            migrationBuilder.DropTable(
                "MetadataCollection");
        }
    }
}