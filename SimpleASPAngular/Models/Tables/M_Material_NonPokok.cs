namespace SimpleASPAngular.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_Material_NonPokok
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string Kode_Material { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string Kode_Proyek { get; set; }

        [StringLength(50)]
        public string Deskripsi { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }
    }
}
