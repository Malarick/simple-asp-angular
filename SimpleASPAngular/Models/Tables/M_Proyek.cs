namespace SimpleASPAngular.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_Proyek
    {
        [Key]
        [StringLength(5)]
        public string Kode_Proyek { get; set; }

        [StringLength(50)]
        public string Nama_Proyek { get; set; }
    }
}
