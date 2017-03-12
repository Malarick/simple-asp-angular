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
using SimpleASPAngular.BusinessLogic.Material;

namespace SimpleASPAngular.Controllers.API
{
    [RoutePrefix("api/Materials")]
    public class MaterialsController : ApiController
    {
        private SimpleASPAngularDB db { get; set; }
        private MaterialService service { get; set; }

        public MaterialsController()
        {
            db = new SimpleASPAngularDB();
            service = new MaterialService(db);
        }

        // GET: api/Material
        [Route("")]
        public IHttpActionResult GetAllMaterials()
        {
            return Json(db.M_Material_CC.ToList());
        }

        [Route("unit/{unit}")]
        public IHttpActionResult GetMaterialsByUnit(string unit)
        {
            var result = service.GetMaterialsByUnit(unit);
            return Json(result);
        }

        // GET: api/Material/5
        [Route("id/{id}")]
        [ResponseType(typeof(M_Material_CC))]
        public IHttpActionResult GetMaterialById(string id)
        {
            M_Material_CC m_Material_CC = db.M_Material_CC.Find(id);
            return Json(m_Material_CC);
        }
                
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_Material_CCExists(string id)
        {
            return db.M_Material_CC.Count(e => e.Kode_Material == id) > 0;
        }
    }
}