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
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
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
                name: "AcademicSession",
                columns: table => new
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
                        name: "FK_AcademicSession_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicSession_AcademicSession_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AcademicSession",
                        principalColumn: "AcademicSessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
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
                name: "Organization",
                columns: table => new
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
                        name: "FK_Organization_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_Organization_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
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
                        name: "FK_Course_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_AcademicSession_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "AcademicSession",
                        principalColumn: "AcademicSessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourcePosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcePosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourcePosition_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Demographics",
                columns: table => new
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
                    table.ForeignKey(
                        name: "FK_Demographics_User_UserId1",
                        column: x => x.UserId1,
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAgent_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
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
                name: "UserOrganization",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganization", x => new { x.UserId, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_UserOrganization_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrganization_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                        name: "FK_Class_AcademicSession_AcademicSessionId",
                        column: x => x.AcademicSessionId,
                        principalTable: "AcademicSession",
                        principalColumn: "AcademicSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_Organization_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
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
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseResource_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
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
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassResource_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
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
                        name: "FK_Enrollment_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollment_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
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
                        name: "FK_LineItem_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItem_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Result_LineItem_LineItemId",
                        column: x => x.LineItemId,
                        principalTable: "LineItem",
                        principalColumn: "LineItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Result_MetadataCollection_MetadataCollectionId",
                        column: x => x.MetadataCollectionId,
                        principalTable: "MetadataCollection",
                        principalColumn: "MetadataCollectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Result_User_UserId",
                        column: x => x.UserId,
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
                name: "IX_Class_AcademicSessionId",
                table: "Class",
                column: "AcademicSessionId");

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
                name: "IX_ClassResource_ResourceId",
                table: "ClassResource",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_MetadataCollectionId",
                table: "Course",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_OrganizationId",
                table: "Course",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SchoolYearId",
                table: "Course",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResource_ResourceId",
                table: "CourseResource",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Demographics_MetadataCollectionId",
                table: "Demographics",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Demographics_UserId1",
                table: "Demographics",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_ClassId",
                table: "Enrollment",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_MetadataCollectionId",
                table: "Enrollment",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_CategoryId",
                table: "LineItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_ClassId",
                table: "LineItem",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_MetadataCollectionId",
                table: "LineItem",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_MetadataCollectionId",
                table: "Organization",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ParentId",
                table: "Organization",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_MetadataCollectionId",
                table: "Resource",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePosition_ResourceId",
                table: "ResourcePosition",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_LineItemId",
                table: "Result",
                column: "LineItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_MetadataCollectionId",
                table: "Result",
                column: "MetadataCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_UserId",
                table: "Result",
                column: "UserId");

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
                column: "AgentId",
                unique: true);

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
                name: "IX_UserOrganization_OrganizationId",
                table: "UserOrganization",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassResource");

            migrationBuilder.DropTable(
                name: "CourseResource");

            migrationBuilder.DropTable(
                name: "Demographics");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Metadata");

            migrationBuilder.DropTable(
                name: "ResourcePosition");

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
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserOrganization");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

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
                name: "Organization");

            migrationBuilder.DropTable(
                name: "AcademicSession");

            migrationBuilder.DropTable(
                name: "MetadataCollection");
        }
    }
}
