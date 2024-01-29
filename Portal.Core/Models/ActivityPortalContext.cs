using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using ActivityPortal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Portal.Core.Models;

public partial class ActivityPortalContext : DbContext
{
    public ActivityPortalContext()
    {
    }

    public ActivityPortalContext(DbContextOptions<ActivityPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<GuidesEvent> GuidesEvents { get; set; }

    public virtual DbSet<Lookup> Lookups { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MembersEvent> MembersEvents { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersRole> UsersRoles { get; set; }
    public virtual DbSet<WebsiteInformation> WebsiteInformations { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-9HF7JU6;Database=ActivityPortal;Trusted_Connection=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC0705BF650D");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Destination)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Events)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Events__Category__48CFD27E");

            entity.HasOne(d => d.User).WithMany(p => p.Events)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Events__UserId__47DBAE45");
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guides__3214EC07FFDD1578");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Nationality)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Profession)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Member).WithMany(p => p.Guides)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__Guides__MemberId__440B1D61");
        });

        modelBuilder.Entity<GuidesEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guides_E__3214EC07B653CA2C");

            entity.ToTable("Guides_Events");


            entity.HasOne(d => d.Event).WithMany(p => p.GuidesEvents)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Guides_Ev__Event__5070F446");

            entity.HasOne(d => d.Guide).WithMany(p => p.GuidesEvents)
                .HasForeignKey(d => d.GuideId)
                .HasConstraintName("FK__Guides_Ev__Guide__4F7CD00D");
        });

        modelBuilder.Entity<Lookup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lookups__3214EC07F92B04F8");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Orders)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Lookups)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Lookups__UserId__412EB0B6");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Members__3214EC07DB390024");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Nationality)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Profession)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MembersEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Members___3214EC07E10091AF");

            entity.ToTable("Members_Events");

            entity.HasOne(d => d.Events).WithMany(p => p.MembersEvents)
                .HasForeignKey(d => d.EventsId)
                .HasConstraintName("FK__Members_E__Event__5441852A");

            entity.HasOne(d => d.Member).WithMany(p => p.MembersEvents)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__Members_E__Membe__534D60F1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC0727A2E2AE");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07D8510A4E");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FisrtName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsersRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users_Ro__3214EC076918AFD3");

            entity.ToTable("Users_Roles");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Role).WithMany(p => p.UsersRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users_Rol__RoleI__4CA06362");

            entity.HasOne(d => d.User).WithMany(p => p.UsersRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Users_Rol__UserI__4BAC3F29");
        });

        modelBuilder.Entity<WebsiteInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WebsiteI__3213E83FB9A48A9D");

            entity.ToTable("WebsiteInformation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.About)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("about");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Main)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("main");
            entity.Property(e => e.Phone)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Service1)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("service1");
            entity.Property(e => e.Service2)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("service2");
            entity.Property(e => e.Service3)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("service3");
            entity.Property(e => e.Service4)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("service4");
        });

        OnModelCreatingPartial(modelBuilder);

        
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
