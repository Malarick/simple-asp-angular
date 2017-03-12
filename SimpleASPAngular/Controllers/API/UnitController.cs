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
    [RoutePrefix("api/Unit")]
    public class UnitController : ApiController
    {
        private SimpleASPAngularDB db = new SimpleASPAngularDB();

        // GET: api/Unit
        [Route("")]
        public IHttpActionResult Getm_unit()
        {
            return Json(db.m_unit);
        }

        // GET: api/Unit/5
        [Route("id/{id}")]
        [ResponseType(typeof(m_unit))]
        public IHttpActionResult Getm_unit(string id)
        {
            m_unit m_unit = db.m_unit.Find(id);
            return Json(m_unit);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool m_unitExists(string id)
        {
            return db.m_unit.Count(e => e.Unit == id) > 0;
        }
    }
}