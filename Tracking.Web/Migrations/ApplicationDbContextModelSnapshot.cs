﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tracking.Web.Data;

namespace Tracking.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Tracking.Web.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankABI");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Tracking.Web.Models.DescriptiveAttributes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Normativa_Livello_1");

                    b.Property<string>("Normativa_Livello_2");

                    b.Property<string>("Normativa_Livello_3");

                    b.Property<string>("Processo_Livello_1");

                    b.Property<string>("Processo_Livello_2");

                    b.Property<string>("Processo_Livello_3");

                    b.Property<string>("Risk")
                        .HasColumnName("Rischio");

                    b.Property<string>("SurveyId")
                        .HasColumnName("Id_Rilievo");

                    b.Property<Guid>("UID_Analisi");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId")
                        .IsUnique()
                        .HasFilter("[Id_Rilievo] IS NOT NULL");

                    b.ToTable("DescriptiveAttributes");
                });

            modelBuilder.Entity("Tracking.Web.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FilePath");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Tracking.Web.Models.Intervention", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.Property<string>("TrackingUserId");

                    b.HasKey("Id");

                    b.HasIndex("TrackingUserId");

                    b.ToTable("Interventions");
                });

            modelBuilder.Entity("Tracking.Web.Models.LegalEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("LegalEntities");
                });

            modelBuilder.Entity("Tracking.Web.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("FileId");

                    b.Property<string>("SurveyId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("SurveyId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Tracking.Web.Models.RiskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RiskTypes");
                });

            modelBuilder.Entity("Tracking.Web.Models.Severity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Severities");
                });

            modelBuilder.Entity("Tracking.Web.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Tracking.Web.Models.Survey", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionDescription")
                        .HasColumnName("Azione_di_Mitigazione");

                    b.Property<string>("ActionOwner")
                        .HasColumnName("Owner_Azione_di_Mitigazione");

                    b.Property<string>("Cod_ABI");

                    b.Property<string>("Description")
                        .HasColumnName("Descrizione_Rilievo");

                    b.Property<DateTime?>("DueDateLocal")
                        .HasColumnName("Data_Scadenza");

                    b.Property<string>("EvaluatedObject")
                        .HasColumnName("Oggetto_Valutato");

                    b.Property<int>("EvaluatedObjectId")
                        .HasColumnName("Id_Oggetto_Valutato");

                    b.Property<DateTime>("ImportDownloadDate");

                    b.Property<int>("InterventionId")
                        .HasColumnName("Id_Intervento");

                    b.Property<string>("InterventionName")
                        .HasColumnName("Titolo_Intervento");

                    b.Property<bool>("IsUpdated");

                    b.Property<string>("LegalEntityName")
                        .HasColumnName("Legal_Entity");

                    b.Property<int?>("RiskTypeId");

                    b.Property<int?>("StatusId");

                    b.Property<string>("SurveySeverity")
                        .HasColumnName("Severita_Rilievo");

                    b.Property<string>("Title")
                        .HasColumnName("Titolo_Rilievo");

                    b.Property<string>("UserName")
                        .HasColumnName("Utente_Censimento");

                    b.HasKey("Id");

                    b.HasIndex("InterventionId");

                    b.HasIndex("RiskTypeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("Tracking.Web.Models.TrackingRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Tracking.Web.Models.TrackingUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Tracking.Web.Models.TrackingRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Tracking.Web.Models.TrackingUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Tracking.Web.Models.TrackingUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Tracking.Web.Models.TrackingRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tracking.Web.Models.TrackingUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Tracking.Web.Models.TrackingUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tracking.Web.Models.DescriptiveAttributes", b =>
                {
                    b.HasOne("Tracking.Web.Models.Survey", "Survey")
                        .WithOne("DescriptiveAttributes")
                        .HasForeignKey("Tracking.Web.Models.DescriptiveAttributes", "SurveyId");
                });

            modelBuilder.Entity("Tracking.Web.Models.Intervention", b =>
                {
                    b.HasOne("Tracking.Web.Models.TrackingUser")
                        .WithMany("UsersInterventions")
                        .HasForeignKey("TrackingUserId");
                });

            modelBuilder.Entity("Tracking.Web.Models.Note", b =>
                {
                    b.HasOne("Tracking.Web.Models.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId");

                    b.HasOne("Tracking.Web.Models.Survey", "Survey")
                        .WithMany("Notes")
                        .HasForeignKey("SurveyId");

                    b.HasOne("Tracking.Web.Models.TrackingUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Tracking.Web.Models.Survey", b =>
                {
                    b.HasOne("Tracking.Web.Models.Intervention")
                        .WithMany("Surveys")
                        .HasForeignKey("InterventionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tracking.Web.Models.RiskType")
                        .WithMany("Surveys")
                        .HasForeignKey("RiskTypeId");

                    b.HasOne("Tracking.Web.Models.Status", "Status")
                        .WithMany("Surveys")
                        .HasForeignKey("StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
