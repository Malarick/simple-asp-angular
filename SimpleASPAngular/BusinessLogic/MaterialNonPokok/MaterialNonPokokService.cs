using SimpleASPAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleASPAngular.BusinessLogic.MaterialNonPokok
{
    public class MaterialNonPokokService
    {
        public SimpleASPAngularDB db { get; set; }

        public MaterialNonPokokService(SimpleASPAngularDB db)
        {
            this.db = db;
        }

        public List<MaterialNonPokokModel> GetMaterialNonPokokByUnit(string unit) {
            var materialNonPokokModels = new List<MaterialNonPokokModel>();
            var materials = db.M_Material_NonPokok
                .Where(m => m.Unit.Equals(unit))
                .ToList();
            materials.ForEach(m =>
            {
                materialNonPokokModels.Add(EntityToModel(m));
            });

            return materialNonPokokModels;
        }

        public MaterialNonPokokModel GetMaterialById(string id) {
            var material = db.M_Material_NonPokok.Where(m => id.Equals(id)).FirstOrDefault();
            return EntityToModel(material);
        }

        private MaterialNonPokokModel EntityToModel(M_Material_NonPokok material) {
            var model = new MaterialNonPokokModel
            {
                Kode_Material = material.Kode_Material,
                Kode_Proyek = material.Kode_Proyek,
                Deskripsi = material.Deskripsi,
                Unit = material.Unit
            };

            return model;
        }
    }
}