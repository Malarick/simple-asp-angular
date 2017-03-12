using SimpleASPAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleASPAngular.BusinessLogic.Proyek
{
    public class ProyekService
    {
        public SimpleASPAngularDB db { get; set; }

        public ProyekService(SimpleASPAngularDB db) {
            this.db = db;
        }
    }
}