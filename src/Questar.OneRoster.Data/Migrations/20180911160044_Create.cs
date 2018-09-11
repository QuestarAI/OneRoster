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
                "Grade",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Grade", x => x.Id); });

            migrationBuilder.CreateTable(
                "MetadataCollection",
                table => new
                {
                    MetadataCollectionId = table.Column<Guid>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_MetadataCollection", x => x.MetadataCollectionId); });

            migrationBuilder.CreateTable(
                "Role",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Role", x => x.Id); });

            migrationBuilder.CreateTable(
                "AcademicSession",
                table => new
                {
                    AcademicSessionId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    SchoolYear = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicSession", x => x.AcademicSessionId);
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
                        "AcademicSessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Category",
                table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        "FK_Category_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Metadata",
                table => new
                {
                    CollectionId = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => new
                    {
                        x.CollectionId,
                        x.Key
                    });
                    table.ForeignKey(
                        "FK_Metadata_MetadataCollection_CollectionId",
                        x => x.CollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Organization",
                table => new
                {
                    OrganizationId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    ParentId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationId);
                    table.ForeignKey(
                        "FK_Organization_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Organization_Organization_ParentId",
                        x => x.ParentId,
                        "Organization",
                        "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Resource",
                table => new
                {
                    ResourceId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
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
                    Id = table.Column<Guid>(nullable: false),
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
                    Position = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    GivenName = table.Column<string>(maxLength: 64, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 64, nullable: true),
                    FamilyName = table.Column<string>(maxLength: 64, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
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
                    CourseId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Code = table.Column<string>(maxLength: 256, nullable: false),
                    SchoolYearId = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.ForeignKey(
                        "FK_Course_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Course_Organization_OrganizationId",
                        x => x.OrganizationId,
                        "Organization",
                        "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Course_AcademicSession_SchoolYearId",
                        x => x.SchoolYearId,
                        "AcademicSession",
                        "AcademicSessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "ResourcePosition",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcePosition", x => x.Id);
                    table.ForeignKey(
                        "FK_ResourcePosition_Resource_ResourceId",
                        x => x.ResourceId,
                        "Resource",
                        "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Demographics",
                table => new
                {
                    UserId1 = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographics", x => x.UserId);
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
                    table.ForeignKey(
                        "FK_Demographics_User_UserId1",
                        x => x.UserId1,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "UserAgent",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    AgentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAgent", x => new
                    {
                        x.UserId,
                        x.AgentId
                    });
                    table.ForeignKey(
                        "FK_UserAgent_User_AgentId",
                        x => x.AgentId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_UserAgent_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserClaim",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    GradeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGrade", x => new
                    {
                        x.UserId,
                        x.GradeId
                    });
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
                "UserLogin",
                table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new
                    {
                        x.LoginProvider,
                        x.ProviderKey
                    });
                    table.ForeignKey(
                        "FK_UserLogin_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserOrganization",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganization", x => new
                    {
                        x.UserId,
                        x.OrganizationId
                    });
                    table.ForeignKey(
                        "FK_UserOrganization_Organization_OrganizationId",
                        x => x.OrganizationId,
                        "Organization",
                        "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_UserOrganization_User_UserId",
                        x => x.UserId,
                        "User",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "UserRole",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new
                    {
                        x.UserId,
                        x.RoleId
                    });
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
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new
                    {
                        x.UserId,
                        x.LoginProvider,
                        x.Name
                    });
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
                    ClassId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Code = table.Column<string>(maxLength: 64, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 64, nullable: false),
                    CourseId = table.Column<Guid>(nullable: false),
                    SchoolId = table.Column<Guid>(nullable: false),
                    AcademicSessionId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                    table.ForeignKey(
                        "FK_Class_AcademicSession_AcademicSessionId",
                        x => x.AcademicSessionId,
                        "AcademicSession",
                        "AcademicSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Class_Course_CourseId",
                        x => x.CourseId,
                        "Course",
                        "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Class_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Class_Organization_SchoolId",
                        x => x.SchoolId,
                        "Organization",
                        "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "CourseResource",
                table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResource", x => new
                    {
                        x.CourseId,
                        x.ResourceId
                    });
                    table.ForeignKey(
                        "FK_CourseResource_Course_CourseId",
                        x => x.CourseId,
                        "Course",
                        "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CourseResource_Resource_ResourceId",
                        x => x.ResourceId,
                        "Resource",
                        "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClassResource",
                table => new
                {
                    ClassId = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassResource", x => new
                    {
                        x.ClassId,
                        x.ResourceId
                    });
                    table.ForeignKey(
                        "FK_ClassResource_Class_ClassId",
                        x => x.ClassId,
                        "Class",
                        "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ClassResource_Resource_ResourceId",
                        x => x.ResourceId,
                        "Resource",
                        "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Enrollment",
                table => new
                {
                    EnrollmentId = table.Column<Guid>(nullable: false),
                    BeginDate = table.Column<DateTimeOffset>(nullable: true),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentId);
                    table.ForeignKey(
                        "FK_Enrollment_Class_ClassId",
                        x => x.ClassId,
                        "Class",
                        "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Enrollment_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "LineItem",
                table => new
                {
                    LineItemId = table.Column<Guid>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.LineItemId);
                    table.ForeignKey(
                        "FK_LineItem_Category_CategoryId",
                        x => x.CategoryId,
                        "Category",
                        "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_LineItem_Class_ClassId",
                        x => x.ClassId,
                        "Class",
                        "ClassId",
                        onDelete: ReferentialAction.Cascade);
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
                    ResultId = table.Column<Guid>(nullable: false),
                    LineItemId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MetadataCollectionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ResultId);
                    table.ForeignKey(
                        "FK_Result_LineItem_LineItemId",
                        x => x.LineItemId,
                        "LineItem",
                        "LineItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Result_MetadataCollection_MetadataCollectionId",
                        x => x.MetadataCollectionId,
                        "MetadataCollection",
                        "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Result_User_UserId",
                        x => x.UserId,
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
                "IX_Class_AcademicSessionId",
                "Class",
                "AcademicSessionId");

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
                "IX_ClassResource_ResourceId",
                "ClassResource",
                "ResourceId");

            migrationBuilder.CreateIndex(
                "IX_Course_MetadataCollectionId",
                "Course",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Course_OrganizationId",
                "Course",
                "OrganizationId");

            migrationBuilder.CreateIndex(
                "IX_Course_SchoolYearId",
                "Course",
                "SchoolYearId");

            migrationBuilder.CreateIndex(
                "IX_CourseResource_ResourceId",
                "CourseResource",
                "ResourceId");

            migrationBuilder.CreateIndex(
                "IX_Demographics_MetadataCollectionId",
                "Demographics",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Demographics_UserId1",
                "Demographics",
                "UserId1");

            migrationBuilder.CreateIndex(
                "IX_Enrollment_ClassId",
                "Enrollment",
                "ClassId");

            migrationBuilder.CreateIndex(
                "IX_Enrollment_MetadataCollectionId",
                "Enrollment",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_LineItem_CategoryId",
                "LineItem",
                "CategoryId");

            migrationBuilder.CreateIndex(
                "IX_LineItem_ClassId",
                "LineItem",
                "ClassId");

            migrationBuilder.CreateIndex(
                "IX_LineItem_MetadataCollectionId",
                "LineItem",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Organization_MetadataCollectionId",
                "Organization",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Organization_ParentId",
                "Organization",
                "ParentId");

            migrationBuilder.CreateIndex(
                "IX_Resource_MetadataCollectionId",
                "Resource",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_ResourcePosition_ResourceId",
                "ResourcePosition",
                "ResourceId");

            migrationBuilder.CreateIndex(
                "IX_Result_LineItemId",
                "Result",
                "LineItemId");

            migrationBuilder.CreateIndex(
                "IX_Result_MetadataCollectionId",
                "Result",
                "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                "IX_Result_UserId",
                "Result",
                "UserId");

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
                "AgentId",
                unique: true);

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
                "IX_UserOrganization_OrganizationId",
                "UserOrganization",
                "OrganizationId");

            migrationBuilder.CreateIndex(
                "IX_UserRole_RoleId",
                "UserRole",
                "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "ClassResource");

            migrationBuilder.DropTable(
                "CourseResource");

            migrationBuilder.DropTable(
                "Demographics");

            migrationBuilder.DropTable(
                "Enrollment");

            migrationBuilder.DropTable(
                "Metadata");

            migrationBuilder.DropTable(
                "ResourcePosition");

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
                "UserLogin");

            migrationBuilder.DropTable(
                "UserOrganization");

            migrationBuilder.DropTable(
                "UserRole");

            migrationBuilder.DropTable(
                "UserToken");

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
                "Organization");

            migrationBuilder.DropTable(
                "AcademicSession");

            migrationBuilder.DropTable(
                "MetadataCollection");
        }
    }
}