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

        private SPRHeaderModel EntityToHeaderModel(TH_SPR spr) {
            return null;
        }

        private SPRDetailModel EntityToDetailModel(TD_SPR spr) {
            return null;
        }
    }
}