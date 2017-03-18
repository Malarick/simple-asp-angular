using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SimpleASPAngular.Models;
using SimpleASPAngular.BusinessLogic.SPR;

namespace SimpleASPAngular.Controllers.API
{
    [RoutePrefix("api/SPRDetail")]
    public class SPRDetailController : ApiController
    {
        private SimpleASPAngularDB db = new SimpleASPAngularDB();
        private SPRService service { get; set; }

        public SPRDetailController() {
            this.service = new SPRService(db);
        }

        // GET: api/SPRDetail
        [Route("")]
        public IHttpActionResult GetTD_SPR()
        {
            return Json(db.TD_SPR);
        }

        // GET: api/SPRDetail/5
        [ResponseType(typeof(TD_SPR))]
        public IHttpActionResult GetDetailsByHeaderId(string id)
        {
            var result = service.GetDetailsByHeaderId(id);
            return Json(result);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddSPRDetail([FromBody] SPRDetailModel detail)
        {
            var info = service.AddSPRDetail(detail);
            return Json(info);
        }

        [HttpPost]
        [Route("edit")]
        public IHttpActionResult EditSPRDetail([FromBody] SPRDetailModel detail)
        {
            var info = service.EditSPRDetail(detail);
            return Json(info);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult DeleteSPRDetail([FromBody] SPRDetailModel detail)
        {
            var info = service.DeleteSPRDetail(detail);
            return Json(info);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TD_SPRExists(string id)
        {
            return db.TD_SPR.Count(e => e.Kode_Spr == id) > 0;
        }
    }
}