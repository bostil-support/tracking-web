using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        UserName = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
            //        Email = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Banks",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        BankABI = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Banks", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Files",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Title = table.Column<string>(nullable: true),
            //        FilePath = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Files", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LegalEntities",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        Code = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LegalEntities", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RiskTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RiskTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Severities",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Severities", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Statuses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Statuses", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        RoleId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        UserId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(nullable: false),
            //        ProviderKey = table.Column<string>(nullable: false),
            //        ProviderDisplayName = table.Column<string>(nullable: true),
            //        UserId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        RoleId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: false),
            //        Value = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Interventions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Title = table.Column<string>(nullable: true),
            //        TrackingUserId = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Interventions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Interventions_AspNetUsers_TrackingUserId",
            //            column: x => x.TrackingUserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Surveys",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Titolo_Rilievo = table.Column<string>(nullable: true),
            //        Descrizione_Rilievo = table.Column<string>(nullable: true),
            //        ImportDownloadDate = table.Column<DateTime>(nullable: false),
            //        Severita_Rilievo = table.Column<string>(nullable: true),
            //        Utente_Censimento = table.Column<string>(nullable: true),
            //        Cod_ABI = table.Column<string>(nullable: true),
            //        Legal_Entity = table.Column<string>(nullable: true),
            //        Owner_Azione_di_Mitigazione = table.Column<string>(nullable: true),
            //        Azione_di_Mitigazione = table.Column<string>(nullable: true),
            //        StatusId = table.Column<int>(nullable: true),
            //        Data_Scadenza = table.Column<DateTime>(nullable: true),
            //        Id_Intervento = table.Column<int>(nullable: false),
            //        Titolo_Intervento = table.Column<string>(nullable: true),
            //        Oggetto_Valutato = table.Column<string>(nullable: true),
            //        Id_Oggetto_Valutato = table.Column<int>(nullable: false),
            //        IsUpdated = table.Column<bool>(nullable: false),
            //        RiskTypeId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Surveys", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Surveys_Interventions_Id_Intervento",
            //            column: x => x.Id_Intervento,
            //            principalTable: "Interventions",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Surveys_RiskTypes_RiskTypeId",
            //            column: x => x.RiskTypeId,
            //            principalTable: "RiskTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Surveys_Statuses_StatusId",
            //            column: x => x.StatusId,
            //            principalTable: "Statuses",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DescriptiveAttributes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        UID_Analisi = table.Column<Guid>(nullable: false),
            //        Id_Rilievo = table.Column<string>(nullable: true),
            //        Processo_Livello_1 = table.Column<string>(nullable: true),
            //        Processo_Livello_2 = table.Column<string>(nullable: true),
            //        Processo_Livello_3 = table.Column<string>(nullable: true),
            //        Normativa_Livello_1 = table.Column<string>(nullable: true),
            //        Normativa_Livello_2 = table.Column<string>(nullable: true),
            //        Normativa_Livello_3 = table.Column<string>(nullable: true),
            //        Rischio = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DescriptiveAttributes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_DescriptiveAttributes_Surveys_Id_Rilievo",
            //            column: x => x.Id_Rilievo,
            //            principalTable: "Surveys",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Notes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        FileId = table.Column<int>(nullable: true),
            //        UserId = table.Column<string>(nullable: true),
            //        SurveyId = table.Column<string>(nullable: true),
            //        Date = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Notes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Notes_Files_FileId",
            //            column: x => x.FileId,
            //            principalTable: "Files",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Notes_Surveys_SurveyId",
            //            column: x => x.SurveyId,
            //            principalTable: "Surveys",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Notes_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DescriptiveAttributes_Id_Rilievo",
            //    table: "DescriptiveAttributes",
            //    column: "Id_Rilievo",
            //    unique: true,
            //    filter: "[Id_Rilievo] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Interventions_TrackingUserId",
            //    table: "Interventions",
            //    column: "TrackingUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Notes_FileId",
            //    table: "Notes",
            //    column: "FileId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Notes_SurveyId",
            //    table: "Notes",
            //    column: "SurveyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Notes_UserId",
            //    table: "Notes",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Surveys_Id_Intervento",
            //    table: "Surveys",
            //    column: "Id_Intervento");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Surveys_RiskTypeId",
            //        table: "Surveys",
            //        column: "RiskTypeId");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Surveys_StatusId",
            //        table: "Surveys",
            //        column: "StatusId");
            //}
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //    migrationBuilder.DropTable(
            //        name: "AspNetRoleClaims");

            //    migrationBuilder.DropTable(
            //        name: "AspNetUserClaims");

            //    migrationBuilder.DropTable(
            //        name: "AspNetUserLogins");

            //    migrationBuilder.DropTable(
            //        name: "AspNetUserRoles");

            //    migrationBuilder.DropTable(
            //        name: "AspNetUserTokens");

            //    migrationBuilder.DropTable(
            //        name: "Banks");

            //    migrationBuilder.DropTable(
            //        name: "DescriptiveAttributes");

            //    migrationBuilder.DropTable(
            //        name: "LegalEntities");

            //    migrationBuilder.DropTable(
            //        name: "Notes");

            //    migrationBuilder.DropTable(
            //        name: "Severities");

            //    migrationBuilder.DropTable(
            //        name: "AspNetRoles");

            //    migrationBuilder.DropTable(
            //        name: "Files");

            migrationBuilder.DropTable(
                name: "Surveys");

            //    migrationBuilder.DropTable(
            //        name: "Interventions");

            //    migrationBuilder.DropTable(
            //        name: "RiskTypes");

            //    migrationBuilder.DropTable(
            //        name: "Statuses");

            //    migrationBuilder.DropTable(
            //        name: "AspNetUsers");
            //}
        }
    }
}
