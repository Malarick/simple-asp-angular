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
    [RoutePrefix("api/SPRHeader")]
    public class SPRHeaderController : ApiController
    {
        private SimpleASPAngularDB db = new SimpleASPAngularDB();
        private SPRService service { get; set; }

        public SPRHeaderController() {
            this.service = new SPRService(db);
        }

        // GET: api/SPRHeader
        [Route("")]
        public IHttpActionResult GetSPRHeaders()
        {
            var result = service.GetSPRHeaders();
            return Json(result);
        }

        // GET: api/SPRHeader/5
        [Route("id/{id}")]
        [ResponseType(typeof(TH_SPR))]
        public IHttpActionResult GetHeaderById(string id)
        {
            TH_SPR tH_SPR = db.TH_SPR.Find(id);
            return Json(tH_SPR);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddSPRHeader([FromBody] SPRHeaderModel header)
        {
            var info = service.AddSPRHeader(header);
            return Json(info);
        }

        [HttpPost]
        [Route("edit")]
        public IHttpActionResult EditSPRHeader([FromBody] SPRHeaderModel header)
        {
            var info = service.EditSPRHeader(header);
            return Json(info);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult DeleteSPRHeader([FromBody] SPRHeaderModel header)
        {
            var info = service.DeleteSPRHeader(header);
            return Json(info);
        }

        // DELETE: api/SPRHeader/5
        [ResponseType(typeof(TH_SPR))]
        public IHttpActionResult DeleteTH_SPR(string id)
        {
            TH_SPR tH_SPR = db.TH_SPR.Find(id);
            if (tH_SPR == null)
            {
                return NotFound();
            }

            db.TH_SPR.Remove(tH_SPR);
            db.SaveChanges();

            return Ok(tH_SPR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TH_SPRExists(string id)
        {
            return db.TH_SPR.Count(e => e.Kode_Spr == id) > 0;
        }
    }
}