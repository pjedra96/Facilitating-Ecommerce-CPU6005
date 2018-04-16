using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WesthoughtonWorldOfWicker.Data;

namespace WesthoughtonWorldOfWicker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.Cart", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CartId")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("CartItemId");

                    b.HasIndex("ProductId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email");

                    b.Property<string>("Message")
                        .HasAnnotation("MaxLength", 300);

                    b.Property<string>("Name");

                    b.Property<string>("Topic");

                    b.HasKey("ContactId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 70);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("County")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 160);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 160);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 24);

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("Id");

                    b.ToTable("Info");
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardNumber");

                    b.Property<int>("InfoId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int?>("ProductId");

                    b.Property<decimal>("Total");

                    b.Property<string>("Username");

                    b.HasKey("OrderId");

                    b.HasIndex("InfoId");

                    b.HasIndex("ProductId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitCost");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("ModelName")
                        .IsRequired();

                    b.Property<int>("ModelNumber");

                    b.Property<decimal>("UnitCost");

                    b.Property<string>("productImageUrl");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<string>("Email");

                    b.Property<int?>("OrderDetailId");

                    b.Property<int>("OrderId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Rating");

                    b.HasKey("ReviewId");

                    b.HasIndex("OrderDetailId");

                    b.HasIndex("ProductId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WesthoughtonWorldOfWicker.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WesthoughtonWorldOfWicker.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WesthoughtonWorldOfWicker.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.Cart", b =>
                {
                    b.HasOne("WesthoughtonWorldOfWicker.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.Order", b =>
                {
                    b.HasOne("WesthoughtonWorldOfWicker.Models.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WesthoughtonWorldOfWicker.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.OrderDetail", b =>
                {
                    b.HasOne("WesthoughtonWorldOfWicker.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WesthoughtonWorldOfWicker.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.Product", b =>
                {
                    b.HasOne("WesthoughtonWorldOfWicker.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WesthoughtonWorldOfWicker.Models.Review", b =>
                {
                    b.HasOne("WesthoughtonWorldOfWicker.Models.OrderDetail", "OrderDetail")
                        .WithMany()
                        .HasForeignKey("OrderDetailId");

                    b.HasOne("WesthoughtonWorldOfWicker.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
        }
    }
}
