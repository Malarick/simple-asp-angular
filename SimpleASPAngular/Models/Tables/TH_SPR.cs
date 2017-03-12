namespace SimpleASPAngular.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TH_SPR
    {
        [Key]
        [StringLength(20)]
        public string Kode_Spr { get; set; }

        [StringLength(5)]
        public string Kode_Proyek { get; set; }

        [Required]
        [StringLength(2)]
        public string Kode_Zona { get; set; }

        public DateTime? Tanggal_Spr { get; set; }

        [StringLength(50)]
        public string Tujuan_SPR { get; set; }

        [StringLength(50)]
        public string Nama_Peminta { get; set; }

        public bool? Status_Disetujui1 { get; set; }

        public bool? Status_Disetujui2 { get; set; }

        [StringLength(50)]
        public string Nama_Pembuat { get; set; }

        [StringLength(50)]
        public string Nama_Pengubah { get; set; }

        [StringLength(50)]
        public string Nama_Penyetuju1 { get; set; }

        [StringLength(50)]
        public string Nama_Penyetuju2 { get; set; }

        public DateTime? Tanggal_Dibuat { get; set; }

        public DateTime? Tanggal_Diubah { get; set; }

        public DateTime? Tanggal_Disetujui1 { get; set; }

        public DateTime? Tanggal_Disetujui2 { get; set; }

    }
}
