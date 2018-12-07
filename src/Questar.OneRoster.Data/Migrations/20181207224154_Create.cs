using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questar.OneRoster.Data.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataProtectionKey",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FriendlyName = table.Column<string>(nullable: true),
                    Xml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataCollection",
                columns: table => new
                {
                    MetadataCollectionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataCollection", x => x.MetadataCollectionId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicSession",
                columns: table => new
                {
                    Type = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    SchoolYear = table.Column<int>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicSession_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicSession_AcademicSession_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AcademicSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Metadata",
                columns: table => new
                {
                    CollectionId = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => new { x.CollectionId, x.Key });
                    table.ForeignKey(
                        name: "FK_Metadata_MetadataCollection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Org",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Identifier = table.Column<string>(maxLength: 256, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Org", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Org_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Org_Org_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Org",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Title = table.Column<string>(maxLength: 64, nullable: true),
                    Importance = table.Column<int>(nullable: false),
                    VendorResourceId = table.Column<string>(maxLength: 256, nullable: false),
                    VendorId = table.Column<string>(maxLength: 256, nullable: true),
                    ApplicationId = table.Column<string>(maxLength: 256, nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resource_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    GivenName = table.Column<string>(maxLength: 64, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 64, nullable: true),
                    FamilyName = table.Column<string>(maxLength: 64, nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    Sms = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Code = table.Column<string>(maxLength: 256, nullable: true),
                    SchoolYearId = table.Column<Guid>(nullable: false),
                    OrgId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Org_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Org",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_AcademicSession_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "AcademicSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceRole",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceRole", x => new { x.ResourceId, x.Role });
                    table.ForeignKey(
                        name: "FK_ResourceRole_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Demographics",
                columns: table => new
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
                    Id = table.Column<Guid>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demographics_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Demographics_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Demographics_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAgent",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    AgentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAgent", x => new { x.UserId, x.AgentId });
                    table.ForeignKey(
                        name: "FK_UserAgent_User_AgentId",
                        column: x => x.AgentId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAgent_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGrade",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    GradeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGrade", x => new { x.UserId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_UserGrade_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGrade_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserIdentifier",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 256, nullable: false),
                    Identifier = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIdentifier", x => new { x.UserId, x.Type, x.Identifier });
                    table.ForeignKey(
                        name: "FK_UserIdentifier_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrg",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    OrgId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrg", x => new { x.UserId, x.OrgId });
                    table.ForeignKey(
                        name: "FK_UserOrg_Org_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Org",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrg_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Type = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Code = table.Column<string>(maxLength: 32, nullable: true),
                    Location = table.Column<string>(maxLength: 256, nullable: true),
                    CourseId = table.Column<Guid>(nullable: false),
                    SchoolId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_Org_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Org",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseGrade",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    GradeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGrade", x => new { x.CourseId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_CourseGrade_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseGrade_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseResource",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResource", x => new { x.CourseId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_CourseResource_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseResource_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSubject",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubject", x => new { x.CourseId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_CourseSubject_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassAcademicSession",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(nullable: false),
                    AcademicSessionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAcademicSession", x => new { x.ClassId, x.AcademicSessionId });
                    table.ForeignKey(
                        name: "FK_ClassAcademicSession_AcademicSession_AcademicSessionId",
                        column: x => x.AcademicSessionId,
                        principalTable: "AcademicSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassAcademicSession_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassGrade",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(nullable: false),
                    GradeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassGrade", x => new { x.ClassId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_ClassGrade_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassGrade_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassPeriod",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(nullable: false),
                    Period = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPeriod", x => new { x.ClassId, x.Period });
                    table.ForeignKey(
                        name: "FK_ClassPeriod_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassResource",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassResource", x => new { x.ClassId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_ClassResource_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassResource_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubject",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubject", x => new { x.ClassId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_ClassSubject_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    BeginDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: false),
                    Primary = table.Column<bool>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollment_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AssignDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    GradingPeriodId = table.Column<Guid>(nullable: false),
                    ResultValueMin = table.Column<float>(nullable: false),
                    ResultValueMax = table.Column<float>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItem_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItem_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItem_AcademicSession_GradingPeriodId",
                        column: x => x.GradingPeriodId,
                        principalTable: "AcademicSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineItem_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Comment = table.Column<string>(nullable: true),
                    LineItemId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    Score = table.Column<float>(nullable: false),
                    ScoreDate = table.Column<DateTime>(nullable: false),
                    ScoreStatus = table.Column<int>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_LineItem_LineItemId",
                        column: x => x.LineItemId,
                        principalTable: "LineItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Result_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Result_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicSession_MetadataCollectionId",
                table: "AcademicSession",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicSession_ParentId",
                table: "AcademicSession",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MetadataCollectionId",
                table: "Category",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_CourseId",
                table: "Class",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_MetadataCollectionId",
                table: "Class",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_SchoolId",
                table: "Class",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAcademicSession_AcademicSessionId",
                table: "ClassAcademicSession",
                column: "AcademicSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassGrade_GradeId",
                table: "ClassGrade",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassResource_ResourceId",
                table: "ClassResource",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubject_SubjectId",
                table: "ClassSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_MetadataCollectionId",
                table: "Course",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_OrgId",
                table: "Course",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SchoolYearId",
                table: "Course",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGrade_GradeId",
                table: "CourseGrade",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResource_ResourceId",
                table: "CourseResource",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_SubjectId",
                table: "CourseSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Demographics_MetadataCollectionId",
                table: "Demographics",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Demographics_UserId",
                table: "Demographics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_ClassId",
                table: "Enrollment",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_MetadataCollectionId",
                table: "Enrollment",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_UserId",
                table: "Enrollment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Code",
                table: "Grade",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_CategoryId",
                table: "LineItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_ClassId",
                table: "LineItem",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_GradingPeriodId",
                table: "LineItem",
                column: "GradingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_MetadataCollectionId",
                table: "LineItem",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Org_Identifier",
                table: "Org",
                column: "Identifier");

            migrationBuilder.CreateIndex(
                name: "IX_Org_MetadataCollectionId",
                table: "Org",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Org_ParentId",
                table: "Org",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_MetadataCollectionId",
                table: "Resource",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_LineItemId",
                table: "Result",
                column: "LineItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_MetadataCollectionId",
                table: "Result",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_StudentId",
                table: "Result",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Code",
                table: "Subject",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_User_Identifier",
                table: "User",
                column: "Identifier");

            migrationBuilder.CreateIndex(
                name: "IX_User_MetadataCollectionId",
                table: "User",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserAgent_AgentId",
                table: "UserAgent",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrade_GradeId",
                table: "UserGrade",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrg_OrgId",
                table: "UserOrg",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassAcademicSession");

            migrationBuilder.DropTable(
                name: "ClassGrade");

            migrationBuilder.DropTable(
                name: "ClassPeriod");

            migrationBuilder.DropTable(
                name: "ClassResource");

            migrationBuilder.DropTable(
                name: "ClassSubject");

            migrationBuilder.DropTable(
                name: "CourseGrade");

            migrationBuilder.DropTable(
                name: "CourseResource");

            migrationBuilder.DropTable(
                name: "CourseSubject");

            migrationBuilder.DropTable(
                name: "DataProtectionKey");

            migrationBuilder.DropTable(
                name: "Demographics");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Metadata");

            migrationBuilder.DropTable(
                name: "ResourceRole");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "UserAgent");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserGrade");

            migrationBuilder.DropTable(
                name: "UserIdentifier");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserOrg");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Org");

            migrationBuilder.DropTable(
                name: "AcademicSession");

            migrationBuilder.DropTable(
                name: "MetadataCollection");
        }
    }
}
