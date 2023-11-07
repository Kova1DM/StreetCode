﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Streetcode.DAL.Persistence;

#nullable disable

namespace Streetcode.DAL.Persistence.Migrations
{
    [DbContext(typeof(StreetcodeDbContext))]
    partial class StreetcodeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Ukrainian_CP1251_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.Coordinates.Coordinate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CoordinateType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Longtitude")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("coordinates", "add_content");

                    b.HasDiscriminator<string>("CoordinateType").HasValue("coordinate_base");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.StreetcodeTagIndex", b =>
                {
                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.HasKey("StreetcodeId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("streetcode_tag_index", "add_content");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.Subtitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.Property<string>("SubtitleText")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("StreetcodeId");

                    b.ToTable("subtitles", "add_content");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tags", "add_content");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Analytics.StatisticRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("QrId")
                        .HasColumnType("int");

                    b.Property<int>("StreetcodeCoordinateId")
                        .HasColumnType("int");

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StreetcodeCoordinateId")
                        .IsUnique();

                    b.HasIndex("StreetcodeId");

                    b.ToTable("qr_coordinates", "coordinates");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Feedback.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("responses", "feedback");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Jobs.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)");

                    b.HasKey("Id");

                    b.ToTable("job", "jobs");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Audio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BlobName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("audios", "media");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Images.Art", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<int?>("StreetcodeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("StreetcodeId");

                    b.ToTable("arts", "media");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Images.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BlobName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("images", "media");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Images.ImageDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Alt")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.ToTable("image_details", "media");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Images.StreetcodeImage", b =>
                {
                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.HasKey("ImageId", "StreetcodeId");

                    b.HasIndex("StreetcodeId");

                    b.ToTable("streetcode_image", "streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StreetcodeId");

                    b.ToTable("videos", "media");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.News.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique()
                        .HasFilter("[ImageId] IS NOT NULL");

                    b.HasIndex("URL")
                        .IsUnique();

                    b.ToTable("news", "news");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Partners.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<bool>("IsKeyPartner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsVisibleEverywhere")
                        .HasColumnType("bit");

                    b.Property<int>("LogoId")
                        .HasColumnType("int");

                    b.Property<string>("TargetUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UrlTitle")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("LogoId")
                        .IsUnique();

                    b.ToTable("partners", "partners");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Partners.PartnerSourceLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("LogoType")
                        .HasColumnType("tinyint");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<string>("TargetUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("partner_source_links", "partners");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Partners.StreetcodePartner", b =>
                {
                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.HasKey("PartnerId", "StreetcodeId");

                    b.HasIndex("StreetcodeId");

                    b.ToTable("streetcode_partners", "streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Sources.SourceLinkCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("source_link_categories", "sources");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Sources.StreetcodeCategoryContent", b =>
                {
                    b.Property<int>("SourceLinkCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SourceLinkCategoryId", "StreetcodeId");

                    b.HasIndex("StreetcodeId");

                    b.ToTable("streetcode_source_link_categories", "sources");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.RelatedFigure", b =>
                {
                    b.Property<int>("ObserverId")
                        .HasColumnType("int");

                    b.Property<int>("TargetId")
                        .HasColumnType("int");

                    b.HasKey("ObserverId", "TargetId");

                    b.HasIndex("TargetId");

                    b.ToTable("related_figures", "streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.StreetcodeArt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArtId")
                        .HasColumnType("int");

                    b.Property<int>("Index")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int?>("StreetcodeArtSlideId")
                        .HasColumnType("int");

                    b.Property<int?>("StreetcodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StreetcodeArtSlideId");

                    b.HasIndex("StreetcodeId");

                    b.HasIndex("ArtId", "StreetcodeArtSlideId");

                    b.ToTable("streetcode_art", "streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.StreetcodeArtSlide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Index")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.Property<int>("Template")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StreetcodeId");

                    b.ToTable("streetcode_art_slide", "streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("AudioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("DateString")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("EventEndOrPersonDeathDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventStartOrPersonBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StreetcodeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teaser")
                        .HasMaxLength(650)
                        .HasColumnType("nvarchar(650)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TransliterationUrl")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("ViewCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("AudioId")
                        .IsUnique()
                        .HasFilter("[AudioId] IS NOT NULL");

                    b.HasIndex("Index")
                        .IsUnique();

                    b.HasIndex("TransliterationUrl")
                        .IsUnique();

                    b.ToTable("streetcodes", "streetcode");

                    b.HasDiscriminator<string>("StreetcodeType").HasValue("streetcode-base");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.TextContent.Fact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FactContent")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("StreetcodeId");

                    b.ToTable("facts", "streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.TextContent.RelatedTerm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("TermId")
                        .HasColumnType("int");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("TermId");

                    b.ToTable("related_terms", "streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.TextContent.Term", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("terms", "streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.TextContent.Text", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdditionalText")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.Property<string>("TextContent")
                        .IsRequired()
                        .HasMaxLength(15000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("StreetcodeId")
                        .IsUnique();

                    b.ToTable("texts", "streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Team.Positions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("positions", "team");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Team.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.ToTable("team_members", "team");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Team.TeamMemberLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("LogoType")
                        .HasColumnType("tinyint");

                    b.Property<string>("TargetUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("TeamMemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamMemberId");

                    b.ToTable("team_member_links", "team");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Team.TeamMemberPositions", b =>
                {
                    b.Property<int>("TeamMemberId")
                        .HasColumnType("int");

                    b.Property<int>("PositionsId")
                        .HasColumnType("int");

                    b.HasKey("TeamMemberId", "PositionsId");

                    b.HasIndex("PositionsId");

                    b.ToTable("team_member_positions", "team");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Timeline.HistoricalContext", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("historical_contexts", "timeline");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Timeline.HistoricalContextTimeline", b =>
                {
                    b.Property<int>("TimelineId")
                        .HasColumnType("int");

                    b.Property<int>("HistoricalContextId")
                        .HasColumnType("int");

                    b.HasKey("TimelineId", "HistoricalContextId");

                    b.HasIndex("HistoricalContextId");

                    b.ToTable("HistoricalContextsTimelines");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Timeline.TimelineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DateViewPattern")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("StreetcodeId");

                    b.ToTable("timeline_items", "timeline");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Toponyms.StreetcodeToponym", b =>
                {
                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.Property<int>("ToponymId")
                        .HasColumnType("int");

                    b.HasKey("StreetcodeId", "ToponymId");

                    b.HasIndex("ToponymId");

                    b.ToTable("streetcode_toponym", "streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Toponyms.Toponym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdminRegionNew")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("AdminRegionOld")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Community")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Gromada")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Oblast")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("StreetType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("toponyms", "toponyms");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Transactions.TransactionLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UrlTitle")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("StreetcodeId")
                        .IsUnique();

                    b.ToTable("transaction_links", "transactions");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", "Users");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.Coordinates.Types.StreetcodeCoordinate", b =>
                {
                    b.HasBaseType("Streetcode.DAL.Entities.AdditionalContent.Coordinates.Coordinate");

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.HasIndex("StreetcodeId");

                    b.ToTable("coordinates", "add_content");

                    b.HasDiscriminator().HasValue("coordinate_streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.Coordinates.Types.ToponymCoordinate", b =>
                {
                    b.HasBaseType("Streetcode.DAL.Entities.AdditionalContent.Coordinates.Coordinate");

                    b.Property<int>("ToponymId")
                        .HasColumnType("int");

                    b.HasIndex("ToponymId")
                        .IsUnique()
                        .HasFilter("[ToponymId] IS NOT NULL");

                    b.ToTable("coordinates", "add_content");

                    b.HasDiscriminator().HasValue("coordinate_toponym");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.Types.EventStreetcode", b =>
                {
                    b.HasBaseType("Streetcode.DAL.Entities.Streetcode.StreetcodeContent");

                    b.ToTable("streetcodes", "streetcode");

                    b.HasDiscriminator().HasValue("streetcode-event");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.Types.PersonStreetcode", b =>
                {
                    b.HasBaseType("Streetcode.DAL.Entities.Streetcode.StreetcodeContent");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Rank")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("streetcodes", "streetcode");

                    b.HasDiscriminator().HasValue("streetcode-person");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.StreetcodeTagIndex", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany("StreetcodeTagIndices")
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Streetcode.DAL.Entities.AdditionalContent.Tag", "Tag")
                        .WithMany("StreetcodeTagIndices")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Streetcode");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.Subtitle", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany("Subtitles")
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Analytics.StatisticRecord", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.AdditionalContent.Coordinates.Types.StreetcodeCoordinate", "StreetcodeCoordinate")
                        .WithOne("StatisticRecord")
                        .HasForeignKey("Streetcode.DAL.Entities.Analytics.StatisticRecord", "StreetcodeCoordinateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany("StatisticRecords")
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Streetcode");

                    b.Navigation("StreetcodeCoordinate");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Images.Art", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Media.Images.Image", "Image")
                        .WithOne("Art")
                        .HasForeignKey("Streetcode.DAL.Entities.Media.Images.Art", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany("Arts")
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Image");

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Images.ImageDetails", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Media.Images.Image", "Image")
                        .WithOne("ImageDetails")
                        .HasForeignKey("Streetcode.DAL.Entities.Media.Images.ImageDetails", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Images.StreetcodeImage", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Media.Images.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany()
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Video", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany("Videos")
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.News.News", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Media.Images.Image", "Image")
                        .WithOne("News")
                        .HasForeignKey("Streetcode.DAL.Entities.News.News", "ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Partners.Partner", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Media.Images.Image", "Logo")
                        .WithOne("Partner")
                        .HasForeignKey("Streetcode.DAL.Entities.Partners.Partner", "LogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Logo");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Partners.PartnerSourceLink", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Partners.Partner", "Partner")
                        .WithMany("PartnerSourceLinks")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Partners.StreetcodePartner", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Partners.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany()
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Sources.SourceLinkCategory", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Media.Images.Image", "Image")
                        .WithMany("SourceLinkCategories")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Sources.StreetcodeCategoryContent", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Sources.SourceLinkCategory", "SourceLinkCategory")
                        .WithMany("StreetcodeCategoryContents")
                        .HasForeignKey("SourceLinkCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany("StreetcodeCategoryContents")
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SourceLinkCategory");

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.RelatedFigure", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Observer")
                        .WithMany("Observers")
                        .HasForeignKey("ObserverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Target")
                        .WithMany("Targets")
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Observer");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.StreetcodeArt", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Media.Images.Art", "Art")
                        .WithMany("StreetcodeArts")
                        .HasForeignKey("ArtId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeArtSlide", "StreetcodeArtSlide")
                        .WithMany("StreetcodeArts")
                        .HasForeignKey("StreetcodeArtSlideId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany("StreetcodeArts")
                        .HasForeignKey("StreetcodeId");

                    b.Navigation("Art");

                    b.Navigation("Streetcode");

                    b.Navigation("StreetcodeArtSlide");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.StreetcodeArtSlide", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany("StreetcodeArtSlides")
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Media.Audio", "Audio")
                        .WithOne("Streetcode")
                        .HasForeignKey("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "AudioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Audio");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.TextContent.Fact", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Media.Images.Image", "Image")
                        .WithMany("Facts")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany("Facts")
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.TextContent.RelatedTerm", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Streetcode.TextContent.Term", "Term")
                        .WithMany("RelatedTerms")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Term");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.TextContent.Text", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithOne("Text")
                        .HasForeignKey("Streetcode.DAL.Entities.Streetcode.TextContent.Text", "StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Team.TeamMember", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Media.Images.Image", "Image")
                        .WithOne("TeamMember")
                        .HasForeignKey("Streetcode.DAL.Entities.Team.TeamMember", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Team.TeamMemberLink", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Team.TeamMember", "TeamMember")
                        .WithMany("TeamMemberLinks")
                        .HasForeignKey("TeamMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Team.TeamMemberPositions", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Team.Positions", "Positions")
                        .WithMany()
                        .HasForeignKey("PositionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Streetcode.DAL.Entities.Team.TeamMember", "TeamMember")
                        .WithMany()
                        .HasForeignKey("TeamMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Positions");

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Timeline.HistoricalContextTimeline", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Timeline.HistoricalContext", "HistoricalContext")
                        .WithMany("HistoricalContextTimelines")
                        .HasForeignKey("HistoricalContextId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Streetcode.DAL.Entities.Timeline.TimelineItem", "Timeline")
                        .WithMany("HistoricalContextTimelines")
                        .HasForeignKey("TimelineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HistoricalContext");

                    b.Navigation("Timeline");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Timeline.TimelineItem", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany("TimelineItems")
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Toponyms.StreetcodeToponym", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany()
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Streetcode.DAL.Entities.Toponyms.Toponym", "Toponym")
                        .WithMany()
                        .HasForeignKey("ToponymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Streetcode");

                    b.Navigation("Toponym");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Transactions.TransactionLink", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithOne("TransactionLink")
                        .HasForeignKey("Streetcode.DAL.Entities.Transactions.TransactionLink", "StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.Coordinates.Types.StreetcodeCoordinate", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", "Streetcode")
                        .WithMany("Coordinates")
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.Coordinates.Types.ToponymCoordinate", b =>
                {
                    b.HasOne("Streetcode.DAL.Entities.Toponyms.Toponym", "Toponym")
                        .WithOne("Coordinate")
                        .HasForeignKey("Streetcode.DAL.Entities.AdditionalContent.Coordinates.Types.ToponymCoordinate", "ToponymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Toponym");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.Tag", b =>
                {
                    b.Navigation("StreetcodeTagIndices");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Audio", b =>
                {
                    b.Navigation("Streetcode");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Images.Art", b =>
                {
                    b.Navigation("StreetcodeArts");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Media.Images.Image", b =>
                {
                    b.Navigation("Art");

                    b.Navigation("Facts");

                    b.Navigation("ImageDetails");

                    b.Navigation("News");

                    b.Navigation("Partner");

                    b.Navigation("SourceLinkCategories");

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Partners.Partner", b =>
                {
                    b.Navigation("PartnerSourceLinks");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Sources.SourceLinkCategory", b =>
                {
                    b.Navigation("StreetcodeCategoryContents");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.StreetcodeArtSlide", b =>
                {
                    b.Navigation("StreetcodeArts");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.StreetcodeContent", b =>
                {
                    b.Navigation("Arts");

                    b.Navigation("Coordinates");

                    b.Navigation("Facts");

                    b.Navigation("Observers");

                    b.Navigation("StatisticRecords");

                    b.Navigation("StreetcodeArtSlides");

                    b.Navigation("StreetcodeArts");

                    b.Navigation("StreetcodeCategoryContents");

                    b.Navigation("StreetcodeTagIndices");

                    b.Navigation("Subtitles");

                    b.Navigation("Targets");

                    b.Navigation("Text");

                    b.Navigation("TimelineItems");

                    b.Navigation("TransactionLink");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Streetcode.TextContent.Term", b =>
                {
                    b.Navigation("RelatedTerms");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Team.TeamMember", b =>
                {
                    b.Navigation("TeamMemberLinks");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Timeline.HistoricalContext", b =>
                {
                    b.Navigation("HistoricalContextTimelines");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Timeline.TimelineItem", b =>
                {
                    b.Navigation("HistoricalContextTimelines");
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.Toponyms.Toponym", b =>
                {
                    b.Navigation("Coordinate")
                        .IsRequired();
                });

            modelBuilder.Entity("Streetcode.DAL.Entities.AdditionalContent.Coordinates.Types.StreetcodeCoordinate", b =>
                {
                    b.Navigation("StatisticRecord")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
