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
using SimpleASPAngular.BusinessLogic.MaterialNonPokok;

namespace SimpleASPAngular.Controllers.API
{
    [RoutePrefix("api/MaterialNonPokok")]
    public class MaterialNonPokokController : ApiController
    {
        private SimpleASPAngularDB db = new SimpleASPAngularDB();
        private MaterialNonPokokService service { get; set; }

        public MaterialNonPokokController()
        {
            this.service = new MaterialNonPokokService(db);
        }

        // GET: api/MaterialNonPokok
        [Route("")]
        public IHttpActionResult GetAllMaterialNonPokok()
        {
            return Json(db.M_Material_NonPokok);
        }

        [Route("unit/{unit}")]
        public IHttpActionResult GetMaterialNonPokokByUnit(string unit)
        {
            return Json(service.GetMaterialNonPokokByUnit(unit));
        }

        // GET: api/MaterialNonPokok/5
        [Route("id/{id}/{idProyek}")]
        [ResponseType(typeof(M_Material_NonPokok))]
        public IHttpActionResult GetMaterialNonPokokById(string id, string idProyek)
        {
            M_Material_NonPokok m_Material_NonPokok = db.M_Material_NonPokok.Find(id, idProyek);
            return Json(m_Material_NonPokok);
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_Material_NonPokokExists(string id)
        {
            return db.M_Material_NonPokok.Count(e => e.Kode_Material == id) > 0;
        }
    }
}