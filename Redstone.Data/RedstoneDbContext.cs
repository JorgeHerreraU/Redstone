using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Redstone.Domain.Models;

namespace Redstone.Data
{
    public partial class RedstoneDbContext : DbContext
    {
        public RedstoneDbContext()
        {
        }

        public RedstoneDbContext(DbContextOptions<RedstoneDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategory { get; set; }
        public virtual DbSet<ServiceOffered> ServiceOffered { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }
        public virtual DbSet<Stagesupply> Stagesupply { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=ec2-52-22-216-69.compute-1.amazonaws.com;Username=nuxjmdslibvhfj;Password=083bbd65dd2d2f28dd6279c9bb311a1d3e427643cd4748aafac8c7a3834d8846;Database=d103isv8tus35j;SSL Mode=Require;Trust Server Certificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(x => x.CustomerId)
                    .HasName("address_customer_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.Apartment)
                    .HasColumnName("apartment")
                    .HasViewColumnName("apartment")
                    .HasMaxLength(250);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasViewColumnName("city")
                    .HasMaxLength(250);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasViewColumnName("customer_id");

                entity.Property(e => e.District)
                    .HasColumnName("district")
                    .HasViewColumnName("district")
                    .HasMaxLength(250);

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasViewColumnName("number");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasViewColumnName("street")
                    .HasMaxLength(250);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.Address)
                    .HasForeignKey<Address>(x => x.CustomerId)
                    .HasConstraintName("address_customer_id_fk");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasViewColumnName("email")
                    .HasMaxLength(250);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasViewColumnName("firstname")
                    .HasMaxLength(250);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasViewColumnName("lastname")
                    .HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasViewColumnName("phone")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasIndex(x => x.StageId)
                    .HasName("payment_stage_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.FormOfPayment)
                    .IsRequired()
                    .HasColumnName("form_of_payment")
                    .HasViewColumnName("form_of_payment")
                    .HasMaxLength(50);

                entity.Property(e => e.PaidAmmount)
                    .HasColumnName("paid_ammount")
                    .HasViewColumnName("paid_ammount");

                entity.Property(e => e.StageId)
                    .HasColumnName("stage_id")
                    .HasViewColumnName("stage_id");

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("transaction_date")
                    .HasViewColumnName("transaction_date");

                entity.HasOne(d => d.Stage)
                    .WithOne(p => p.Payment)
                    .HasForeignKey<Payment>(x => x.StageId)
                    .HasConstraintName("payment_stage_id_fk");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("report");

                entity.HasIndex(x => x.StageId)
                    .HasName("report_stage_id_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.Plants)
                    .HasColumnName("plants")
                    .HasViewColumnName("plants")
                    .HasMaxLength(255);

                entity.Property(e => e.Relief)
                    .HasColumnName("relief")
                    .HasViewColumnName("relief")
                    .HasMaxLength(255);

                entity.Property(e => e.Rocks)
                    .HasColumnName("rocks")
                    .HasViewColumnName("rocks")
                    .HasMaxLength(255);

                entity.Property(e => e.Soil)
                    .HasColumnName("soil")
                    .HasViewColumnName("soil")
                    .HasMaxLength(255);

                entity.Property(e => e.StageId)
                    .HasColumnName("stage_id")
                    .HasViewColumnName("stage_id");

                entity.Property(e => e.Vegetation)
                    .HasColumnName("vegetation")
                    .HasViewColumnName("vegetation")
                    .HasMaxLength(255);

                entity.Property(e => e.Water)
                    .HasColumnName("water")
                    .HasViewColumnName("water")
                    .HasMaxLength(255);

                entity.Property(e => e.Wind)
                    .HasColumnName("wind")
                    .HasViewColumnName("wind")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Stage)
                    .WithOne(p => p.Report)
                    .HasForeignKey<Report>(x => x.StageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("report_stage_id_fk");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.CartId)
                    .HasColumnName("cart_id")
                    .HasViewColumnName("cart_id");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasViewColumnName("customer_id");

                entity.Property(e => e.RequestDate)
                    .HasColumnName("request_date")
                    .HasViewColumnName("request_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ServiceofferedId)
                    .HasColumnName("serviceoffered_id")
                    .HasViewColumnName("serviceoffered_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Service)
                    .HasForeignKey(x => x.CustomerId)
                    .HasConstraintName("service_customer_id_fk");

                entity.HasOne(d => d.Serviceoffered)
                    .WithMany(p => p.Service)
                    .HasForeignKey(x => x.ServiceofferedId)
                    .HasConstraintName("service_services_offered_id_fk");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.ToTable("service_category");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasViewColumnName("description")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ServiceOffered>(entity =>
            {
                entity.ToTable("service_offered");

                entity.HasIndex(x => x.CategoryId)
                    .HasName("services_offered_service_category_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id")
                    .HasDefaultValueSql("nextval('services_offered_id_seq'::regclass)");

                entity.Property(e => e.BasePrice)
                    .HasColumnName("base_price")
                    .HasViewColumnName("base_price");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasViewColumnName("category_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasViewColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasViewColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithOne(p => p.ServiceOffered)
                    .HasForeignKey<ServiceOffered>(x => x.CategoryId)
                    .HasConstraintName("services_offered_service_category_id_fk");
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.ToTable("stage");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.Ammount)
                    .HasColumnName("ammount")
                    .HasViewColumnName("ammount");

                entity.Property(e => e.IsCompleted)
                    .HasColumnName("is_completed")
                    .HasViewColumnName("is_completed");

                entity.Property(e => e.IsPaid)
                    .HasColumnName("is_paid")
                    .HasViewColumnName("is_paid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasViewColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Schedule)
                    .HasColumnName("schedule")
                    .HasViewColumnName("schedule");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("service_id")
                    .HasViewColumnName("service_id");

                entity.Property(e => e.TeamId)
                    .HasColumnName("team_id")
                    .HasViewColumnName("team_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Stage)
                    .HasForeignKey(x => x.ServiceId)
                    .HasConstraintName("stage_service_id_fk");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Stage)
                    .HasForeignKey(x => x.TeamId)
                    .HasConstraintName("stage_team_id_fk");
            });

            modelBuilder.Entity<Stagesupply>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("stagesupply");

                entity.HasIndex(x => new { x.StageId, x.SupplyId })
                    .HasName("idx_stage_supply");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasViewColumnName("quantity");

                entity.Property(e => e.StageId)
                    .HasColumnName("stage_id")
                    .HasViewColumnName("stage_id");

                entity.Property(e => e.SupplyId)
                    .HasColumnName("supply_id")
                    .HasViewColumnName("supply_id");

                entity.HasOne(d => d.Stage)
                    .WithMany()
                    .HasForeignKey(x => x.StageId)
                    .HasConstraintName("stagesupply_stage_id_fk");

                entity.HasOne(d => d.Supply)
                    .WithMany()
                    .HasForeignKey(x => x.SupplyId)
                    .HasConstraintName("stagesupply_supply_id_fk");
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.ToTable("supply");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasViewColumnName("category")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasViewColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasViewColumnName("stock");

                entity.Property(e => e.Unitprice)
                    .HasColumnName("unitprice")
                    .HasViewColumnName("unitprice");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.HasIndex(x => x.CategoryId)
                    .HasName("team_category_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasViewColumnName("category_id");

                entity.Property(e => e.Fee)
                    .HasColumnName("fee")
                    .HasViewColumnName("fee");

                entity.Property(e => e.IsBudgeting)
                    .HasColumnName("is_budgeting")
                    .HasViewColumnName("is_budgeting");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasViewColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasViewColumnName("type")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithOne(p => p.Team)
                    .HasForeignKey<Team>(x => x.CategoryId)
                    .HasConstraintName("team_service_category_id_fk");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasViewColumnName("createdAt")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasViewColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasViewColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Profile)
                    .HasColumnName("profile")
                    .HasViewColumnName("profile")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Customer'::character varying");

                entity.Property(e => e.ResetPasswordExpires)
                    .HasColumnName("resetPasswordExpires")
                    .HasViewColumnName("resetPasswordExpires")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.ResetPasswordToken)
                    .HasColumnName("resetPasswordToken")
                    .HasViewColumnName("resetPasswordToken")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasViewColumnName("updatedAt")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasViewColumnName("username")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
