using SimpleASPAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleASPAngular.BusinessLogic.SPR
{
    public class SPRService
    {
        public SimpleASPAngularDB db { get; set; }

        public SPRService(SimpleASPAngularDB db)
        {
            this.db = db;
        }

        public List<SPRHeaderModel> GetSPRHeaderByFilter()
        {
            var SPRHeaderModels = new List<SPRHeaderModel>();
            var SPRHeaders = db.TH_SPR.ToList();
            SPRHeaders.ForEach(s => {
                SPRHeaderModels.Add(EntityToHeaderModel(s));
            });

            return SPRHeaderModels;
        }

        public bool AddSPRHeader(SPRHeaderModel headerModel)
        {
            try
            {
                DateTime? today = DateTime.Now;
                var monthVal = today.Value.Month.ToString();
                monthVal = monthVal.Length < 2 ? "0" + monthVal : monthVal;
                var yearVal = today.Value.Year.ToString();
                var sameMonthYear = db.TH_SPR
                    .Where(h => h.Tanggal_Dibuat.HasValue
                            && h.Tanggal_Dibuat.Value.Year == today.Value.Year
                            && h.Tanggal_Dibuat.Value.Month == today.Value.Month)
                    .ToList()
                    .OrderByDescending(h => h.Tanggal_Dibuat);
                var lastCounter = sameMonthYear.Count() > 0 ? Convert.ToInt32(sameMonthYear.FirstOrDefault().Kode_Spr.Substring(0, 4).TrimStart('0')) : 0;
                var counter = (lastCounter + 1).ToString();
                while (counter.Length < 4) {
                    counter = "0" + counter;
                }


                var header = new TH_SPR {
                    Kode_Spr = counter + "-" + headerModel.Kode_Proyek + "-" + monthVal + "-" + yearVal,
                    Kode_Proyek = headerModel.Kode_Proyek,
                    Kode_Zona = headerModel.Kode_Zona,
                    Tanggal_Spr = headerModel.Tanggal_Spr,
                    Tujuan_SPR = headerModel.Tujuan_SPR,
                    Nama_Peminta = headerModel.Nama_Peminta,
                    Nama_Pembuat = "SYSTEM",
                    Nama_Pengubah = "SYSTEM",
                    Status_Disetujui1 = headerModel.Status_Disetujui1,
                    Status_Disetujui2 = headerModel.Status_Disetujui2,
                    Nama_Penyetuju1 = headerModel.Status_Disetujui1.HasValue && headerModel.Status_Disetujui1.Value ? headerModel.Nama_Penyetuju1 : null,
                    Nama_Penyetuju2 = headerModel.Status_Disetujui2.HasValue && headerModel.Status_Disetujui2.Value ? headerModel.Nama_Penyetuju2 : null,
                    Tanggal_Disetujui1 = headerModel.Status_Disetujui1.HasValue && headerModel.Status_Disetujui1.Value ? today : null,
                    Tanggal_Disetujui2 = headerModel.Status_Disetujui2.HasValue && headerModel.Status_Disetujui2.Value ? today : null,
                    Tanggal_Dibuat = today,
                    Tanggal_Diubah = today
                };

                db.TH_SPR.Add(header);
                db.SaveChanges();
            }
            catch (Exception e) {
                return false;
            }

            return true;
        }

        public bool EditSPRHeader(SPRHeaderModel headerModel)
        {
            try
            {
                DateTime? today = DateTime.Now;
                var header = db.TH_SPR.Find(headerModel.Kode_Spr);
                
                header.Tanggal_Spr = headerModel.Tanggal_Spr;
                header.Tujuan_SPR = headerModel.Tujuan_SPR;
                header.Nama_Peminta = headerModel.Nama_Peminta;
                header.Nama_Pengubah = "SYSTEM";
                header.Status_Disetujui1 = headerModel.Status_Disetujui1;
                header.Status_Disetujui2 = headerModel.Status_Disetujui2;
                header.Nama_Penyetuju1 = headerModel.Status_Disetujui1.HasValue && headerModel.Status_Disetujui1.Value ? headerModel.Nama_Penyetuju1 : null;
                header.Nama_Penyetuju2 = headerModel.Status_Disetujui2.HasValue && headerModel.Status_Disetujui2.Value ? headerModel.Nama_Penyetuju2 : null;
                header.Tanggal_Disetujui1 = headerModel.Status_Disetujui1.HasValue && headerModel.Status_Disetujui1.Value ? today : null;
                header.Tanggal_Disetujui2 = headerModel.Status_Disetujui2.HasValue && headerModel.Status_Disetujui2.Value ? today : null;                
                header.Tanggal_Diubah = today;
                                
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool DeleteSPRHeader(SPRHeaderModel headerModel) {
            try {
                var header = db.TH_SPR.Find(headerModel.Kode_Spr);
                db.TH_SPR.Remove(header);
                db.SaveChanges();
            }
            catch (Exception e) {
                return false;
            }
            return true;
        }

        private SPRHeaderModel EntityToHeaderModel(TH_SPR spr) {
            return null;
        }

        private SPRDetailModel EntityToDetailModel(TD_SPR spr) {
            return null;
        }
    }
}