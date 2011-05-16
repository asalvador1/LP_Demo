using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using PruebaMvcExt.Models;

namespace PruebaMvcExt.Controllers
{
    public class ListaPreciosController : BaseController
    {
        //
        // GET: /ListaPrecios/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NuevaPaso1()
        {
            return View();
        }

        public ActionResult NuevaPaso2()
        {
            
            return View();
        }

        public ActionResult NuevaPaso3()
        {
            return View();
        }

        public ActionResult NuevaPaso4()
        {
            return View();
        }

        #region Catalogos
        public JsonResult GetPeriodos()
        {
            List<SelectListItem> tempColl = new List<SelectListItem>();
            tempColl.Add(new SelectListItem
            {
                Text = "Trimestral",
                Value = "3"
            });
            Hashtable result = new Hashtable();
            result["Rows"] = tempColl;
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDealers()
        {
            List<Dealer> tempColl = ListDealers();

            Hashtable result = new Hashtable();
            result["Rows"] = tempColl;
            return this.Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetDealersAndModelos()
        {
            List<Dealer> tempColl = ListDealers();
            List<Modelo> modelos = ListModelos();
            modelos.ForEach(el => el.Incentivos = new ProgramaConceptos
            {
                DescuentoSobreBase = "2.0%",
                PlazoComercial = "90 días"
            });
            List<Modelo> modelosDealer = new List<Modelo>();
            //hack                       
            foreach (var m in modelos)
            {
                foreach (var d in tempColl)
                {
                    Dealer dd = new Dealer { GFX = d.GFX, Descripcion = d.Descripcion };
                    Modelo mm = new Modelo(m);
                    mm.DealerAsociado = dd;
                    modelosDealer.Add(mm);
                }
            }
            
           

            Hashtable result = new Hashtable();
            result["Rows"] = modelosDealer;
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        private static List<Dealer> ListDealers()
        {
            List<Dealer> tempColl = new List<Dealer>();
            tempColl.Add(
                new Dealer
                {
                    Descripcion = "A. MERCANTILES",
                    GFX = "930008"
                });
            tempColl.Add(
                new Dealer
                {
                    Descripcion = "CACESA",
                    GFX = "930271"
                });
            tempColl.Add(
                new Dealer
                {
                    Descripcion = "DIEZ CAMIONES",
                    GFX = "930636"
                });
            tempColl.Add(
                new Dealer
                {
                    Descripcion = "KASA",
                    GFX = "931774"
                });
            tempColl.Add(
                new Dealer
                {
                    Descripcion = "RAFEDHER",
                    GFX = "931881"
                });
            return tempColl;
        }


        public JsonResult GetModelos()
        {
            List<Modelo> modelos = ListModelos();
            return this.Json(modelos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModelosIncentivos()
        {
            List<Modelo> modelos = ListModelos();
            modelos.ForEach(el => el.Incentivos = new ProgramaConceptos
            {
                DescuentoSobreBase = "2.0%",
                PlazoComercial = "90 días"
            });
            Hashtable result = new Hashtable();
            result["rows"] = modelos;
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDescuentosBase()
        {
            List<SelectListItem> tempColl = new List<SelectListItem>();
            tempColl.Add(new SelectListItem
            {
                Text = "1.0%",
                Value = "1.0%"
            });
            tempColl.Add(new SelectListItem
            {
                Text = "2.0%",
                Value = "2.0%"
            });
            tempColl.Add(new SelectListItem
            {
                Text = "3.5%",
                Value = "3.5%"
            });
            return this.Json(tempColl, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlazosComerciales()
        {
            List<SelectListItem> tempColl = new List<SelectListItem>();
            tempColl.Add(new SelectListItem
            {
                Text = "90 días",
                Value = "90 días"
            });
            tempColl.Add(new SelectListItem
            {
                Text = "75 días",
                Value = "75 días"
            });
            tempColl.Add(new SelectListItem
            {
                Text = "60 días",
                Value = "60 días"
            });
            return this.Json(tempColl, JsonRequestBehavior.AllowGet);
        }

        private static List<Modelo> ListModelos()
        {
            List<Modelo> modelos = new List<Modelo>();
            modelos.Add(new Modelo
            {
                ModeloDescripcion = "4700 SFC 4X2 BUS (PC025)",
                Modelo7 = "PC02500",
                ClasifLocal = "Buses",
                ClasifUsa = "Bus",
                Familia = "4700 SFC"
                ,SPABase = "0%",
                SPAProgramacionInventario ="0%"
            });
            modelos.Add(new Modelo
            {
                ModeloDescripcion = "3300CE 4X2 BUS (PC035)",
                Modelo7 = "PC03500",
                ClasifLocal = "Buses",
                ClasifUsa = "Bus",
                Familia = "3300 CE"
                ,SPABase = "0%",
                SPAProgramacionInventario ="0%"
            });
            modelos.Add(new Modelo
            {
                ModeloDescripcion = "9200i SBA 6X4 (L9227)",
                Modelo7 = "L922700",
                ClasifLocal = "Heavy",
                ClasifUsa = "HVY",
                Familia = "9200"
                ,SPABase = "0%",
                SPAProgramacionInventario ="0%"
            });
            modelos.Add(new Modelo
            {
                ModeloDescripcion = "9400i SBA 6X4 (L9427)",
                Modelo7 = "L942700",
                ClasifLocal = "Heavy",
                ClasifUsa = "HVY",
                Familia = "9400"
                ,SPABase = "0%",
                SPAProgramacionInventario ="0%"
            });
            modelos.Add(new Modelo
            {
                ModeloDescripcion = "CF500 4X2 (KL045)",
                Modelo7 = "KL04500",
                ClasifLocal = "Light",
                ClasifUsa = "MED",
                Familia = "CF 500"
                ,SPABase = "0%",
                SPAProgramacionInventario ="0%"
            });
            modelos.Add(new Modelo
            {
                ModeloDescripcion = "CF600 4X2 (KL055)",
                Modelo7 = "KL05500",
                ClasifLocal = "Light",
                ClasifUsa = "MED",
                Familia = "CF 600"
                ,SPABase = "0%",
                SPAProgramacionInventario ="0%"
            });
            modelos.Add(new Modelo
            {
                ModeloDescripcion = "4200 SBA 4X2 (MA015)",
                Modelo7 = "MA01500",
                ClasifLocal = "Medium",
                ClasifUsa = "MED",
                Familia = "4200"                
                ,SPABase = "0%",
                SPAProgramacionInventario = "0%"
            });
            modelos.Add(new Modelo
            {
                ModeloDescripcion = "4300 SBA 4X2 (MA025)",
                Modelo7 = "MA02500",
                ClasifLocal = "Medium",
                ClasifUsa = "MED",
                Familia = "4300"
                ,SPABase = "0%",
                SPAProgramacionInventario ="0%"
            });
            return modelos;
        }


            
        #endregion

    }
}
