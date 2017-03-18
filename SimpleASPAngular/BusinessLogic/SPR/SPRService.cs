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

        public List<SPRHeaderModel> GetSPRHeaders() {
            var SPRHeaderModels = new List<SPRHeaderModel>();
            var SPRHeaders = db.TH_SPR.ToList();
            SPRHeaders.ForEach(s => {
                SPRHeaderModels.Add(EntityToHeaderModel(s));
            });

            return SPRHeaderModels;
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

        public List<SPRDetailModel> GetDetailsByHeaderId(string id) {
            var detailModels = new List<SPRDetailModel>();
            var details = db.TD_SPR
                .Where(d => d.Kode_Spr == id)
                .OrderBy(o => o.Kode_Material)
                .ToList();
            details.ForEach(d => {
                detailModels.Add(EntityToDetailModel(d));
            });

            return detailModels;
        }

        public bool AddSPRDetail(SPRDetailModel detailModel) {
            try {
                var detail = new TD_SPR
                {
                    Kode_Spr = detailModel.Kode_Spr,
                    Kode_Material = detailModel.Kode_Material,
                    Jenis_Material = detailModel.Jenis_Material,
                    Merk = detailModel.Merk,
                    Spesifikasi = detailModel.Spesifikasi,
                    Keterangan = detailModel.Keterangan,
                    Volume = detailModel.Volume,
                    Unit = detailModel.Unit,
                    Tanggal_Rencana_Terima = detailModel.Tanggal_Rencana_Terima,
                    Status_Disetujui = detailModel.Status_Disetujui
                };

                var existing = db.TD_SPR.Find(detailModel.Kode_Spr, detailModel.Kode_Material);
                if(existing != null) {
                    return false;
                }

                db.TD_SPR.Add(detail);
                db.SaveChanges();
            } catch (Exception ex) {
                return false;
            }

            return true;
        }

        public bool EditSPRDetail(SPRDetailModel detailModel) {
            try {
                var detail = db.TD_SPR.Find(detailModel.Kode_Spr, detailModel.Kode_Material);
                detail.Jenis_Material = detailModel.Jenis_Material;
                detail.Merk = detailModel.Merk;
                detail.Spesifikasi = detailModel.Spesifikasi;
                detail.Keterangan = detailModel.Keterangan;
                detail.Volume = detailModel.Volume;
                detail.Unit = detailModel.Unit;
                detail.Tanggal_Rencana_Terima = detailModel.Tanggal_Rencana_Terima;
                detail.Status_Disetujui = detailModel.Status_Disetujui;

                db.SaveChanges();
            } catch (Exception ex) {
                return false;
            }

            return true;
        }

        public bool DeleteSPRDetail(SPRDetailModel detailModel) {
            try {
                var detail = db.TD_SPR.Find(detailModel.Kode_Spr, detailModel.Kode_Material);
                db.TD_SPR.Remove(detail);
                db.SaveChanges();
            } catch (Exception ex) {
                return false;
            }
            return true;
        }

        private SPRHeaderModel EntityToHeaderModel(TH_SPR spr) {
            var headerModel = new SPRHeaderModel {
                Kode_Spr = spr.Kode_Spr,
                Kode_Proyek = spr.Kode_Proyek,
                Kode_Zona = spr.Kode_Zona,
                Tanggal_Spr = spr.Tanggal_Spr,
                Tujuan_SPR = spr.Tujuan_SPR,
                Nama_Peminta = spr.Nama_Peminta,
                Status_Disetujui1 = spr.Status_Disetujui1,
                Status_Disetujui2 = spr.Status_Disetujui2,
                Nama_Pembuat = spr.Nama_Pembuat,
                Nama_Pengubah = spr.Nama_Pengubah,
                Nama_Penyetuju1 = spr.Nama_Penyetuju1,
                Nama_Penyetuju2 = spr.Nama_Penyetuju2,
                Tanggal_Dibuat = spr.Tanggal_Dibuat,
                Tanggal_Diubah = spr.Tanggal_Diubah,
                Tanggal_Disetujui1 = spr.Tanggal_Disetujui1,
                Tanggal_Disetujui2 = spr.Tanggal_Disetujui2
            };

            headerModel.Details = new List<SPRDetailModel>();
            spr.Details.ToList().ForEach(d => {
                var detailModel = new SPRDetailModel {
                    Kode_Spr = d.Kode_Spr,
                    Kode_Material = d.Kode_Material,
                    Jenis_Material = d.Jenis_Material,
                    Merk = d.Merk,
                    Spesifikasi = d.Spesifikasi,
                    Keterangan = d.Keterangan,
                    Volume = d.Volume,
                    Unit = d.Unit,
                    Tanggal_Rencana_Terima = d.Tanggal_Rencana_Terima,
                    Status_Disetujui = d.Status_Disetujui,
                    Header = new SPRHeaderModel
                    {
                        Kode_Spr = d.Header.Kode_Spr,
                        Tanggal_Spr = d.Header.Tanggal_Spr
                    }
                };
                
                if (d.Jenis_Material.Equals("01"))
                {
                    detailModel.Nama_Material = db.M_Material_CC.Find(d.Kode_Material).Deskripsi;
                }
                else
                {
                    detailModel.Nama_Material = db.M_Material_NonPokok.Find(d.Kode_Material, spr.Kode_Proyek).Deskripsi;
                }

                headerModel.Details.Add(detailModel);
            });
            
            return headerModel;
        }

        private SPRDetailModel EntityToDetailModel(TD_SPR spr) {
            var detailModel = new SPRDetailModel{
                Kode_Spr = spr.Kode_Spr,
                Kode_Material = spr.Kode_Material,
                Jenis_Material = spr.Jenis_Material,
                Merk = spr.Merk,
                Spesifikasi = spr.Spesifikasi,
                Keterangan = spr.Keterangan,
                Volume = spr.Volume,
                Unit = spr.Unit,
                Tanggal_Rencana_Terima = spr.Tanggal_Rencana_Terima,
                Status_Disetujui = spr.Status_Disetujui,
                Header = new SPRHeaderModel {
                    Kode_Spr = spr.Header.Kode_Spr,
                    Tanggal_Spr = spr.Header.Tanggal_Spr
                }
            };

            return detailModel;
        }
    }
}