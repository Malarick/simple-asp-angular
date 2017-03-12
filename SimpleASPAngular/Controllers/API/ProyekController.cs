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
    [RoutePrefix("api/Proyek")]
    public class ProyekController : ApiController
    {
        private SimpleASPAngularDB db = new SimpleASPAngularDB();

        // GET: api/Proyek
        [Route("")]
        public IHttpActionResult GetAllProyek()
        {
            return Json(db.M_Proyek);
        }

        // GET: api/Proyek/5
        [Route("id/{id}")]
        [ResponseType(typeof(M_Proyek))]
        public IHttpActionResult GetProyekById(string id)
        {
            M_Proyek m_Proyek = db.M_Proyek.Find(id);
            return Json(m_Proyek);
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_ProyekExists(string id)
        {
            return db.M_Proyek.Count(e => e.Kode_Proyek == id) > 0;
        }
    }
}