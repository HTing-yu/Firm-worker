﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test.Models;

public partial class ShopwebContext : DbContext
{
    public ShopwebContext()
    {
    }

    public ShopwebContext(DbContextOptions<ShopwebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerAccounttable> CustomerAccounttables { get; set; }

    public virtual DbSet<FirmAccounttable> FirmAccounttables { get; set; }

    public virtual DbSet<FirmPagetable> FirmPagetables { get; set; }

    public virtual DbSet<GroupDatatable> GroupDatatables { get; set; }

    public virtual DbSet<MemberMembertable> MemberMembertables { get; set; }

    public virtual DbSet<NotifyDatatable> NotifyDatatables { get; set; }

    public virtual DbSet<OrderAssesstable> OrderAssesstables { get; set; }

    public virtual DbSet<OrderDatatable> OrderDatatables { get; set; }

    public virtual DbSet<PaymentDatatable> PaymentDatatables { get; set; }

    public virtual DbSet<ProductDatatable> ProductDatatables { get; set; }

    public virtual DbSet<ProductPicturetable> ProductPicturetables { get; set; }

    public virtual DbSet<ShipDatatable> ShipDatatables { get; set; }

    public virtual DbSet<TalkDatatable> TalkDatatables { get; set; }

    public virtual DbSet<TalkMembertable> TalkMembertables { get; set; }

    public virtual DbSet<TalkPersontable> TalkPersontables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WIND;Database=shopweb;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;User ID=sa;Password=qw0961e5715");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerAccounttable>(entity =>
        {
            entity.HasKey(e => e.CNumber).HasName("PK_c_accounttable");

            entity.ToTable("Customer_accounttable");

            entity.Property(e => e.CNumber).HasColumnName("c_number");
            entity.Property(e => e.CAccount)
                .HasMaxLength(50)
                .HasColumnName("c_account");
            entity.Property(e => e.CMailpass).HasColumnName("c_mailpass");
            entity.Property(e => e.CNickname)
                .HasMaxLength(10)
                .HasColumnName("c_nickname");
            entity.Property(e => e.CPassword)
                .HasMaxLength(50)
                .HasColumnName("c_password");
        });

        modelBuilder.Entity<FirmAccounttable>(entity =>
        {
            entity.HasKey(e => e.FNumber).HasName("PK_f_accounttable");

            entity.ToTable("Firm_accounttable");

            entity.Property(e => e.FNumber).HasColumnName("f_number");
            entity.Property(e => e.FAccount)
                .HasMaxLength(50)
                .HasColumnName("f_account");
            entity.Property(e => e.FMailpass).HasColumnName("f_mailpass");
            entity.Property(e => e.FNickname)
                .HasMaxLength(50)
                .HasColumnName("f_nickname");
            entity.Property(e => e.FPassword)
                .HasMaxLength(50)
                .HasColumnName("f_password");
        });

        modelBuilder.Entity<FirmPagetable>(entity =>
        {
            entity.HasKey(e => e.FNumber).HasName("PK_f_pagetable");

            entity.ToTable("Firm_pagetable");

            entity.Property(e => e.FNumber)
                .ValueGeneratedNever()
                .HasColumnName("f_number");
            entity.Property(e => e.FMessage)
                .HasMaxLength(500)
                .HasColumnName("f_message");
            entity.Property(e => e.FPagename)
                .HasMaxLength(50)
                .HasColumnName("f_pagename");
            entity.Property(e => e.FPicurl)
                .HasMaxLength(500)
                .HasColumnName("f_picurl");

            entity.HasOne(d => d.FNumberNavigation).WithOne(p => p.FirmPagetable)
                .HasForeignKey<FirmPagetable>(d => d.FNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Firm_pagetable_Firm_accounttable");
        });

        modelBuilder.Entity<GroupDatatable>(entity =>
        {
            entity.HasKey(e => e.GNumber).HasName("PK_g_datatable");

            entity.ToTable("Group_datatable");

            entity.Property(e => e.GNumber).HasColumnName("g_number");
            entity.Property(e => e.FNumber).HasColumnName("f_number");
            entity.Property(e => e.GEnd)
                .HasColumnType("date")
                .HasColumnName("g_end");
            entity.Property(e => e.GMaxpeople).HasColumnName("g_maxpeople");
            entity.Property(e => e.GPrice).HasColumnName("g_price");
            entity.Property(e => e.GStart)
                .HasColumnType("date")
                .HasColumnName("g_start");
            entity.Property(e => e.PNumber).HasColumnName("p_number");

            entity.HasOne(d => d.FNumberNavigation).WithMany(p => p.GroupDatatables)
                .HasForeignKey(d => d.FNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Group_datatable_Firm_accounttable");

            entity.HasOne(d => d.PNumberNavigation).WithMany(p => p.GroupDatatables)
                .HasForeignKey(d => d.PNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_g_datatable_p_datatable");
        });

        modelBuilder.Entity<MemberMembertable>(entity =>
        {
            entity.HasKey(e => e.MNumber).HasName("PK_m_membertable");

            entity.ToTable("Member_membertable");

            entity.Property(e => e.MNumber).HasColumnName("m_number");
            entity.Property(e => e.GMaxpeople).HasColumnName("g_maxpeople");
            entity.Property(e => e.GNumber).HasColumnName("g_number");
            entity.Property(e => e.MNowpeople).HasColumnName("m_nowpeople");
            entity.Property(e => e.MStatus).HasColumnName("m_status");

            entity.HasOne(d => d.GNumberNavigation).WithMany(p => p.MemberMembertables)
                .HasForeignKey(d => d.GNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_m_membertable_g_datatable");
        });

        modelBuilder.Entity<NotifyDatatable>(entity =>
        {
            entity.HasKey(e => e.NNumber);

            entity.ToTable("Notify_datatable");

            entity.Property(e => e.NNumber).HasColumnName("n_number");
            entity.Property(e => e.CNumber).HasColumnName("c_number");
            entity.Property(e => e.FNumber).HasColumnName("f_number");
            entity.Property(e => e.NRead).HasColumnName("n_read");
            entity.Property(e => e.ONumber).HasColumnName("o_number");
            entity.Property(e => e.OStatus)
                .HasMaxLength(50)
                .HasColumnName("o_status");

            entity.HasOne(d => d.CNumberNavigation).WithMany(p => p.NotifyDatatables)
                .HasForeignKey(d => d.CNumber)
                .HasConstraintName("FK_Notify_datatable_Customer_accounttable");

            entity.HasOne(d => d.FNumberNavigation).WithMany(p => p.NotifyDatatables)
                .HasForeignKey(d => d.FNumber)
                .HasConstraintName("FK_Notify_datatable_Firm_accounttable");

            entity.HasOne(d => d.ONumberNavigation).WithMany(p => p.NotifyDatatables)
                .HasForeignKey(d => d.ONumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_n_datatable_o_datatable");
        });

        modelBuilder.Entity<OrderAssesstable>(entity =>
        {
            entity.HasKey(e => e.ONumber);

            entity.ToTable("Order_assesstable");

            entity.Property(e => e.ONumber)
                .ValueGeneratedNever()
                .HasColumnName("o_number");
            entity.Property(e => e.OCcomment)
                .HasMaxLength(500)
                .HasColumnName("o_ccomment");
            entity.Property(e => e.OCscore).HasColumnName("o_cscore");
            entity.Property(e => e.OFcomment)
                .HasMaxLength(500)
                .HasColumnName("o_fcomment");
            entity.Property(e => e.OFscore).HasColumnName("o_fscore");

            entity.HasOne(d => d.ONumberNavigation).WithOne(p => p.OrderAssesstable)
                .HasForeignKey<OrderAssesstable>(d => d.ONumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_o_assesstable_o_datatable");
        });

        modelBuilder.Entity<OrderDatatable>(entity =>
        {
            entity.HasKey(e => e.ONumber).HasName("PK_o_datatable");

            entity.ToTable("Order_datatable");

            entity.Property(e => e.ONumber).HasColumnName("o_number");
            entity.Property(e => e.CNumber).HasColumnName("c_number");
            entity.Property(e => e.FNumber).HasColumnName("f_number");
            entity.Property(e => e.MNumber).HasColumnName("m_number");
            entity.Property(e => e.OBuynumber).HasColumnName("o_buynumber");
            entity.Property(e => e.OEnd)
                .HasColumnType("date")
                .HasColumnName("o_end");
            entity.Property(e => e.OPayment).HasColumnName("o_payment");
            entity.Property(e => e.OPlace)
                .HasMaxLength(500)
                .HasColumnName("o_place");
            entity.Property(e => e.OPrice).HasColumnName("o_price");
            entity.Property(e => e.OShip).HasColumnName("o_ship");
            entity.Property(e => e.OShipstatus)
                .HasMaxLength(50)
                .HasColumnName("o_shipstatus");
            entity.Property(e => e.OStart)
                .HasColumnType("date")
                .HasColumnName("o_start");
            entity.Property(e => e.OStatus)
                .HasMaxLength(50)
                .HasColumnName("o_status");
            entity.Property(e => e.OType).HasColumnName("o_type");
            entity.Property(e => e.PNumber).HasColumnName("p_number");

            entity.HasOne(d => d.CNumberNavigation).WithMany(p => p.OrderDatatables)
                .HasForeignKey(d => d.CNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_datatable_Customer_accounttable");

            entity.HasOne(d => d.OPaymentNavigation).WithMany(p => p.OrderDatatables)
                .HasForeignKey(d => d.OPayment)
                .HasConstraintName("FK_Order_datatable_Payment_datatable");

            entity.HasOne(d => d.OShipNavigation).WithMany(p => p.OrderDatatables)
                .HasForeignKey(d => d.OShip)
                .HasConstraintName("FK_Order_datatable_Ship_datatable");

            entity.HasOne(d => d.PNumberNavigation).WithMany(p => p.OrderDatatables)
                .HasForeignKey(d => d.PNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_o_datatable_p_datatable");
        });

        modelBuilder.Entity<PaymentDatatable>(entity =>
        {
            entity.HasKey(e => e.PaymentNumber);

            entity.ToTable("Payment_datatable");

            entity.Property(e => e.PaymentNumber)
                .ValueGeneratedNever()
                .HasColumnName("Payment_number");
            entity.Property(e => e.PaymentName)
                .HasMaxLength(50)
                .HasColumnName("Payment_name");
        });

        modelBuilder.Entity<ProductDatatable>(entity =>
        {
            entity.HasKey(e => e.PNumber).HasName("PK_p_datatable");

            entity.ToTable("Product_datatable");

            entity.Property(e => e.PNumber).HasColumnName("p_number");
            entity.Property(e => e.FNumber).HasColumnName("f_number");
            entity.Property(e => e.PCategory)
                .HasMaxLength(50)
                .HasColumnName("p_category");
            entity.Property(e => e.PDescribe)
                .HasMaxLength(500)
                .HasColumnName("p_describe");
            entity.Property(e => e.PInventory).HasColumnName("p_Inventory");
            entity.Property(e => e.PName)
                .HasMaxLength(50)
                .HasColumnName("p_name");
            entity.Property(e => e.PPayment).HasColumnName("p_payment");
            entity.Property(e => e.PPrice).HasColumnName("p_price");
            entity.Property(e => e.PSavedate)
                .HasMaxLength(500)
                .HasColumnName("p_savedate");
            entity.Property(e => e.PSaveway)
                .HasMaxLength(50)
                .HasColumnName("p_saveway");
            entity.Property(e => e.PShip).HasColumnName("p_ship");
            entity.Property(e => e.PSpec)
                .HasMaxLength(50)
                .HasColumnName("p_spec");

            entity.HasOne(d => d.FNumberNavigation).WithMany(p => p.ProductDatatables)
                .HasForeignKey(d => d.FNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_datatable_Firm_accounttable");

            entity.HasMany(d => d.PaymentNumbers).WithMany(p => p.PNumbers)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductToPayment",
                    r => r.HasOne<PaymentDatatable>().WithMany()
                        .HasForeignKey("PaymentNumber")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_to_Payment_Payment_datatable"),
                    l => l.HasOne<ProductDatatable>().WithMany()
                        .HasForeignKey("PNumber")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_to_Payment_Product_datatable"),
                    j =>
                    {
                        j.HasKey("PNumber", "PaymentNumber");
                        j.ToTable("Product_to_Payment");
                        j.IndexerProperty<int>("PNumber").HasColumnName("p_number");
                        j.IndexerProperty<int>("PaymentNumber").HasColumnName("Payment_number");
                    });

            entity.HasMany(d => d.ShipNumbers).WithMany(p => p.PNumbers)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductToShip",
                    r => r.HasOne<ShipDatatable>().WithMany()
                        .HasForeignKey("ShipNumber")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_to_Ship_Ship_datatable"),
                    l => l.HasOne<ProductDatatable>().WithMany()
                        .HasForeignKey("PNumber")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_to_Ship_Product_datatable"),
                    j =>
                    {
                        j.HasKey("PNumber", "ShipNumber");
                        j.ToTable("Product_to_Ship");
                        j.IndexerProperty<int>("PNumber").HasColumnName("p_number");
                        j.IndexerProperty<int>("ShipNumber").HasColumnName("ship_number");
                    });
        });

        modelBuilder.Entity<ProductPicturetable>(entity =>
        {
            entity.HasKey(e => e.PSort);

            entity.ToTable("Product_picturetable");

            entity.Property(e => e.PSort).HasColumnName("p_sort");
            entity.Property(e => e.PNumber).HasColumnName("p_number");
            entity.Property(e => e.PPicnumber).HasColumnName("p_picnumber");
            entity.Property(e => e.PUrl)
                .HasMaxLength(500)
                .HasColumnName("p_url");

            entity.HasOne(d => d.PNumberNavigation).WithMany(p => p.ProductPicturetables)
                .HasForeignKey(d => d.PNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_p_picturetable_p_datatable");
        });

        modelBuilder.Entity<ShipDatatable>(entity =>
        {
            entity.HasKey(e => e.ShipNumber);

            entity.ToTable("Ship_datatable");

            entity.Property(e => e.ShipNumber)
                .ValueGeneratedNever()
                .HasColumnName("ship_number");
            entity.Property(e => e.ShipName)
                .HasMaxLength(50)
                .HasColumnName("ship_name");
        });

        modelBuilder.Entity<TalkDatatable>(entity =>
        {
            entity.HasKey(e => e.TNumber).HasName("PK_t_datatable");

            entity.ToTable("Talk_datatable");

            entity.Property(e => e.TNumber).HasColumnName("t_number");
            entity.Property(e => e.CNumber).HasColumnName("c_number");
            entity.Property(e => e.FNumber).HasColumnName("f_number");
            entity.Property(e => e.TMessage)
                .HasMaxLength(500)
                .HasColumnName("t_message");
            entity.Property(e => e.TPost).HasColumnName("t_post");
            entity.Property(e => e.TRead).HasColumnName("t_read");
            entity.Property(e => e.TTime)
                .HasColumnType("datetime")
                .HasColumnName("t_time");

            entity.HasOne(d => d.CNumberNavigation).WithMany(p => p.TalkDatatables)
                .HasForeignKey(d => d.CNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Talk_datatable_Customer_accounttable");

            entity.HasOne(d => d.FNumberNavigation).WithMany(p => p.TalkDatatables)
                .HasForeignKey(d => d.FNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Talk_datatable_Firm_accounttable");
        });

        modelBuilder.Entity<TalkMembertable>(entity =>
        {
            entity.HasKey(e => e.TalkMemberId);

            entity.ToTable("Talk_membertable");

            entity.Property(e => e.TalkMemberId).HasColumnName("Talk_member_id");
            entity.Property(e => e.CNumber).HasColumnName("c_number");
            entity.Property(e => e.FNumber).HasColumnName("f_number");

            entity.HasOne(d => d.CNumberNavigation).WithMany(p => p.TalkMembertables)
                .HasForeignKey(d => d.CNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Talk_membertable_Customer_accounttable");

            entity.HasOne(d => d.FNumberNavigation).WithMany(p => p.TalkMembertables)
                .HasForeignKey(d => d.FNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Talk_membertable_Firm_accounttable");
        });

        modelBuilder.Entity<TalkPersontable>(entity =>
        {
            entity.HasKey(e => e.TForPk);

            entity.ToTable("Talk_persontable");

            entity.Property(e => e.TForPk).HasColumnName("t_forPK");
            entity.Property(e => e.CNumber).HasColumnName("c_number");
            entity.Property(e => e.FNumber).HasColumnName("f_number");
            entity.Property(e => e.TId)
                .HasMaxLength(500)
                .HasColumnName("t_id");

            entity.HasOne(d => d.CNumberNavigation).WithMany(p => p.TalkPersontables)
                .HasForeignKey(d => d.CNumber)
                .HasConstraintName("FK_Talk_persontable_Customer_accounttable");

            entity.HasOne(d => d.FNumberNavigation).WithMany(p => p.TalkPersontables)
                .HasForeignKey(d => d.FNumber)
                .HasConstraintName("FK_Talk_persontable_Firm_accounttable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
