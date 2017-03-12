using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleASPAngular.BusinessLogic.SPR
{
    public class SPRDetailModel
    {
        public string Kode_Spr { get; set; }
        public string Kode_Material { get; set; }
        public string Jenis_Material { get; set; }
        public string Merk { get; set; }
        public string Spesifikasi { get; set; }        
        public string Keterangan { get; set; }
        public decimal? Volume { get; set; }
        public string Unit { get; set; }
        public DateTime? Tanggal_Rencana_Terima { get; set; }
        public bool? Status_Disetujui { get; set; }
    }
}