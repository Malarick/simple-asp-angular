namespace SimpleASPAngular.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_Material_CC
    {
        [Key]
        [StringLength(10)]
        public string Kode_Material { get; set; }

        [StringLength(50)]
        public string Deskripsi { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }
    }
}
