using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleASPAngular.Models;

namespace SimpleASPAngular.BusinessLogic.Material
{
    public class MaterialService
    {
        private SimpleASPAngularDB db { get; set; }

        public MaterialService(SimpleASPAngularDB db)
        {
            this.db = db;
        }

        public List<MaterialModel> GetMaterialsByUnit(string unit)
        {
            var materialModels = new List<MaterialModel>();
            var materials = db.M_Material_CC
                .Where(m => m.Unit.Equals(unit))
                .ToList();

            materials.ForEach(m => 
            {
                materialModels.Add(EntityToModel(m));
            });

            return materialModels;
        }

        private MaterialModel EntityToModel(M_Material_CC material)
        {
            var materialModel = new MaterialModel
            {
                Kode_Material = material.Kode_Material,
                Deskripsi = material.Deskripsi,
                Unit = material.Unit
            };

            return materialModel;
        }
    }
}