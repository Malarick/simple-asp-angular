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

namespace SimpleASPAngular.Controllers.API
{
    [RoutePrefix("api/SPRHeader")]
    public class SPRHeaderController : ApiController
    {
        private SimpleASPAngularDB db = new SimpleASPAngularDB();

        // GET: api/SPRHeader
        [Route("")]
        public IHttpActionResult GetHeaders()
        {
            return Json(db.TH_SPR);
        }

        // GET: api/SPRHeader/5
        [Route("id/{id}")]
        [ResponseType(typeof(TH_SPR))]
        public IHttpActionResult GetHeaderById(string id)
        {
            TH_SPR tH_SPR = db.TH_SPR.Find(id);
            return Json(tH_SPR);
        }

        // PUT: api/SPRHeader/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTH_SPR(string id, TH_SPR tH_SPR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tH_SPR.Kode_Spr)
            {
                return BadRequest();
            }

            db.Entry(tH_SPR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TH_SPRExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SPRHeader
        [ResponseType(typeof(TH_SPR))]
        public IHttpActionResult PostTH_SPR(TH_SPR tH_SPR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TH_SPR.Add(tH_SPR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TH_SPRExists(tH_SPR.Kode_Spr))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tH_SPR.Kode_Spr }, tH_SPR);
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