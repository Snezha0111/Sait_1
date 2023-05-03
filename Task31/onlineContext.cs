using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Task31
{
    public partial class onlineContext : DbContext
    {
        public onlineContext()
        {
        }

        public onlineContext(DbContextOptions<onlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<DeliveryRazb> DeliveryRazbs { get; set; } = null!;
        public virtual DbSet<InfoProduct> InfoProducts { get; set; } = null!;
        public virtual DbSet<Order1> Order1s { get; set; } = null!;
        public virtual DbSet<OrderRazb> OrderRazbs { get; set; } = null!;
        public virtual DbSet<PointOfIssue> PointOfIssues { get; set; } = null!;
        public virtual DbSet<ProviderProduct> ProviderProducts { get; set; } = null!;
        public virtual DbSet<Recipient> Recipients { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Cart__BA39E84F99731981");

                entity.ToTable("Cart");

                entity.Property(e => e.IdProduct)
                    .ValueGeneratedNever()
                    .HasColumnName("id_product");

                entity.Property(e => e.CountProduct).HasColumnName("count_product");

                entity.Property(e => e.PriceProduct)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price_product");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithOne(p => p.Cart)
                    .HasForeignKey<Cart>(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Info_Product");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__Delivery__DD5B8F3FBCAA0CDB");

                entity.ToTable("Delivery");

                entity.Property(e => e.IdOrder)
                    .ValueGeneratedNever()
                    .HasColumnName("id_order");

                entity.Property(e => e.DateDelivery)
                    .HasColumnType("date")
                    .HasColumnName("date_delivery");

                entity.Property(e => e.PriceDelivery)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price_delivery");

                entity.Property(e => e.SumWeightOrder)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("sum_weight_order");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithOne(p => p.Delivery)
                    .HasForeignKey<Delivery>(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delivery_Order1");
            });

            modelBuilder.Entity<DeliveryRazb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Delivery_razb");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdPoint).HasColumnName("id_point");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delivery_razb_Delivery");

                entity.HasOne(d => d.IdPointNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPoint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delivery_razb_Point_of_issue");
            });

            modelBuilder.Entity<InfoProduct>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Info_Pro__BA39E84F10C6AB07");

                entity.ToTable("Info_Product");

                entity.Property(e => e.IdProduct)
                    .ValueGeneratedNever()
                    .HasColumnName("id_product");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.HeightProduct)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("height_product");

                entity.Property(e => e.ImageProduct)
                    .HasMaxLength(100)
                    .HasColumnName("image_product");

                entity.Property(e => e.LengthProduct)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("length_product");

                entity.Property(e => e.NameProduct)
                    .HasMaxLength(100)
                    .HasColumnName("name_product");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.ProviderProduct).HasColumnName("provider_product");

                entity.Property(e => e.WeightProduct)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("weight_product");

                entity.Property(e => e.WidthProduct)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("width_product");

                entity.HasOne(d => d.ProviderProductNavigation)
                    .WithMany(p => p.InfoProducts)
                    .HasForeignKey(d => d.ProviderProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Info_Product_Provider_product");
            });

            modelBuilder.Entity<Order1>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__Order1__DD5B8F3F6B689B45");

                entity.ToTable("Order1");

                entity.Property(e => e.IdOrder)
                    .ValueGeneratedNever()
                    .HasColumnName("id_order");

                entity.Property(e => e.DateOrder)
                    .HasColumnType("date")
                    .HasColumnName("date_order");

                entity.Property(e => e.IdRec).HasColumnName("id_rec");

                entity.Property(e => e.MethodOfObtaining)
                    .HasMaxLength(30)
                    .HasColumnName("method_of_obtaining");

                entity.Property(e => e.NamePointOfIssue)
                    .HasMaxLength(50)
                    .HasColumnName("name_point_of_issue");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(30)
                    .HasColumnName("payment_method");

                entity.Property(e => e.PriceOrder)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price_order");

                entity.Property(e => e.StatusOrder)
                    .HasMaxLength(30)
                    .HasColumnName("status_order");

                entity.HasOne(d => d.IdRecNavigation)
                    .WithMany(p => p.Order1s)
                    .HasForeignKey(d => d.IdRec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order1_Recipient");
            });

            modelBuilder.Entity<OrderRazb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Order_razb");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_razb_Order1");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_razb_Cart");
            });

            modelBuilder.Entity<PointOfIssue>(entity =>
            {
                entity.HasKey(e => e.IdPoint)
                    .HasName("PK__Point_of__0AD99761E2728ACD");

                entity.ToTable("Point_of_issue");

                entity.Property(e => e.IdPoint)
                    .ValueGeneratedNever()
                    .HasColumnName("id_point");

                entity.Property(e => e.AdresPoint)
                    .HasMaxLength(200)
                    .HasColumnName("adres_point");

                entity.Property(e => e.EndOfWork).HasColumnName("end_of_work");

                entity.Property(e => e.NamePoint)
                    .HasMaxLength(40)
                    .HasColumnName("name_point");

                entity.Property(e => e.StartOfWork).HasColumnName("start_of_work");
            });

            modelBuilder.Entity<ProviderProduct>(entity =>
            {
                entity.HasKey(e => e.IdProvider)
                    .HasName("PK__Provider__BCFF02340CA01B52");

                entity.ToTable("Provider_product");

                entity.Property(e => e.IdProvider)
                    .ValueGeneratedNever()
                    .HasColumnName("id_provider");

                entity.Property(e => e.Adres)
                    .HasMaxLength(200)
                    .HasColumnName("adres");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.NameProvider)
                    .HasMaxLength(100)
                    .HasColumnName("name_provider");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Recipient>(entity =>
            {
                entity.HasKey(e => e.IdRec)
                    .HasName("PK__Recipien__6ABE6F0876D8A97F");

                entity.ToTable("Recipient");

                entity.Property(e => e.IdRec)
                    .ValueGeneratedNever()
                    .HasColumnName("id_rec");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.EmailRes)
                    .HasMaxLength(100)
                    .HasColumnName("Email_res");

                entity.Property(e => e.Gender)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("last_name");

                entity.Property(e => e.LoginRec)
                    .HasMaxLength(50)
                    .HasColumnName("login_rec");

                entity.Property(e => e.PasswordRec)
                    .HasMaxLength(40)
                    .HasColumnName("password_rec");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(100)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone")
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .HasColumnName("surname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
