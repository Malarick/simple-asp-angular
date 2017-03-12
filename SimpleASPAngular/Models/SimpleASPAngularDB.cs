namespace SimpleASPAngular.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SimpleASPAngularDB : DbContext
    {
        public SimpleASPAngularDB()
            : base("name=SimpleASPAngularDB")
        {
        }

        public virtual DbSet<M_Material_CC> M_Material_CC { get; set; }
        public virtual DbSet<M_Material_NonPokok> M_Material_NonPokok { get; set; }
        public virtual DbSet<M_Proyek> M_Proyek { get; set; }
        public virtual DbSet<m_unit> m_unit { get; set; }
        public virtual DbSet<TD_SPR> TD_SPR { get; set; }
        public virtual DbSet<TH_SPR> TH_SPR { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M_Material_CC>()
                .Property(e => e.Kode_Material)
                .IsUnicode(false);

            modelBuilder.Entity<M_Material_CC>()
                .Property(e => e.Deskripsi)
                .IsUnicode(false);

            modelBuilder.Entity<M_Material_CC>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<M_Material_NonPokok>()
                .Property(e => e.Kode_Material)
                .IsUnicode(false);

            modelBuilder.Entity<M_Material_NonPokok>()
                .Property(e => e.Kode_Proyek)
                .IsUnicode(false);

            modelBuilder.Entity<M_Material_NonPokok>()
                .Property(e => e.Deskripsi)
                .IsUnicode(false);

            modelBuilder.Entity<M_Material_NonPokok>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<M_Proyek>()
                .Property(e => e.Kode_Proyek)
                .IsUnicode(false);

            modelBuilder.Entity<M_Proyek>()
                .Property(e => e.Nama_Proyek)
                .IsUnicode(false);

            modelBuilder.Entity<m_unit>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<TD_SPR>()
                .Property(e => e.Kode_Spr)
                .IsUnicode(false);

            modelBuilder.Entity<TD_SPR>()
                .Property(e => e.Kode_Material)
                .IsUnicode(false);

            modelBuilder.Entity<TD_SPR>()
                .Property(e => e.Jenis_Material)
                .IsUnicode(false);

            modelBuilder.Entity<TD_SPR>()
                .Property(e => e.Merk)
                .IsUnicode(false);

            modelBuilder.Entity<TD_SPR>()
                .Property(e => e.Spesifikasi)
                .IsUnicode(false);

            modelBuilder.Entity<TD_SPR>()
                .Property(e => e.Keterangan)
                .IsUnicode(false);

            modelBuilder.Entity<TD_SPR>()
                .Property(e => e.Volume)
                .HasPrecision(18, 4);

            modelBuilder.Entity<TD_SPR>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<TH_SPR>()
                .Property(e => e.Kode_Spr)
                .IsUnicode(false);

            modelBuilder.Entity<TH_SPR>()
                .Property(e => e.Kode_Proyek)
                .IsUnicode(false);

            modelBuilder.Entity<TH_SPR>()
                .Property(e => e.Kode_Zona)
                .IsUnicode(false);

            modelBuilder.Entity<TH_SPR>()
                .Property(e => e.Tujuan_SPR)
                .IsUnicode(false);

            modelBuilder.Entity<TH_SPR>()
                .Property(e => e.Nama_Peminta)
                .IsUnicode(false);

            modelBuilder.Entity<TH_SPR>()
                .Property(e => e.Nama_Pembuat)
                .IsUnicode(false);

            modelBuilder.Entity<TH_SPR>()
                .Property(e => e.Nama_Pengubah)
                .IsUnicode(false);

            modelBuilder.Entity<TH_SPR>()
                .Property(e => e.Nama_Penyetuju1)
                .IsUnicode(false);

            modelBuilder.Entity<TH_SPR>()
                .Property(e => e.Nama_Penyetuju2)
                .IsUnicode(false);
        }
    }
}
