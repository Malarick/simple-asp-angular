namespace SimpleASPAngular.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TD_SPR
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Kode_Spr { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string Kode_Material { get; set; }

        [StringLength(2)]
        public string Jenis_Material { get; set; }

        [StringLength(255)]
        public string Merk { get; set; }

        [StringLength(255)]
        public string Spesifikasi { get; set; }

        [StringLength(255)]
        public string Keterangan { get; set; }

        public decimal? Volume { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        public DateTime? Tanggal_Rencana_Terima { get; set; }

        public bool? Status_Disetujui { get; set; }

        public virtual TH_SPR Header { get; set; }
    }
}
