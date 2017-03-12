using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleASPAngular.BusinessLogic.SPR
{
    public class SPRHeaderModel
    {
        public string Kode_Spr { get; set; }
        public string Kode_Proyek { get; set; }
        public string Kode_Zona { get; set; }
        public DateTime? Tanggal_Spr { get; set; }
        public string Tujuan_SPR { get; set; }
        public string Nama_Peminta { get; set; }
        public bool? Status_Disetujui1 { get; set; }
        public bool? Status_Disetujui2 { get; set; }
        public string Nama_Pembuat { get; set; }
        public string Nama_Pengubah { get; set; }
        public string Nama_Penyetuju1 { get; set; }
        public string Nama_Penyetuju2 { get; set; }
        public DateTime? Tanggal_Dibuat { get; set; }
        public DateTime? Tanggal_Diubah { get; set; }
        public DateTime? Tanggal_Disetujui1 { get; set; }
        public DateTime? Tanggal_Disetujui2 { get; set; }
        public List<SPRDetailModel> Details { get; set; }

        public SPRHeaderModel() {
            this.Details = new List<SPRDetailModel>();
        }
    }

    public class FilterModel
    {
        public bool? StatusPersetujuan { get; set; }
        public bool? AdaDetail { get; set; }
        public bool? Status { get; set; }
    }
}