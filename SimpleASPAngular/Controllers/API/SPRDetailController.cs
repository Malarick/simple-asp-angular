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
    public class SPRDetailController : ApiController
    {
        private SimpleASPAngularDB db = new SimpleASPAngularDB();

        // GET: api/SPRDetail
        public IQueryable<TD_SPR> GetTD_SPR()
        {
            return db.TD_SPR;
        }

        // GET: api/SPRDetail/5
        [ResponseType(typeof(TD_SPR))]
        public IHttpActionResult GetTD_SPR(string id)
        {
            TD_SPR tD_SPR = db.TD_SPR.Find(id);
            if (tD_SPR == null)
            {
                return NotFound();
            }

            return Ok(tD_SPR);
        }

        // PUT: api/SPRDetail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTD_SPR(string id, TD_SPR tD_SPR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tD_SPR.Kode_Spr)
            {
                return BadRequest();
            }

            db.Entry(tD_SPR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TD_SPRExists(id))
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

        // POST: api/SPRDetail
        [ResponseType(typeof(TD_SPR))]
        public IHttpActionResult PostTD_SPR(TD_SPR tD_SPR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TD_SPR.Add(tD_SPR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TD_SPRExists(tD_SPR.Kode_Spr))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tD_SPR.Kode_Spr }, tD_SPR);
        }

        // DELETE: api/SPRDetail/5
        [ResponseType(typeof(TD_SPR))]
        public IHttpActionResult DeleteTD_SPR(string id)
        {
            TD_SPR tD_SPR = db.TD_SPR.Find(id);
            if (tD_SPR == null)
            {
                return NotFound();
            }

            db.TD_SPR.Remove(tD_SPR);
            db.SaveChanges();

            return Ok(tD_SPR);
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