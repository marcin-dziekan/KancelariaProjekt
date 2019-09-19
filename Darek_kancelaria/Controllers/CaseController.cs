using Darek_kancelaria.Models;
using Darek_kancelaria.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.IO;

namespace Darek_kancelaria.Controllers
{
    public class CaseController : Controller
    {
        private CaseRepo _cr;
        private PriceRepo _pp;
        private PersonRepo _pr;
        public CaseController()
        {
            _cr = new CaseRepo();
            _pp = new PriceRepo();
            _pr = new PersonRepo();
        }

        [Authorize(Roles = ("Admin, Partner"))]
        public ActionResult CaseDetails(int id)
        {
            var cases = new Cases();
            var cs = _cr.GetCase(id);
            cases.Case = cs;
            cases.personelModel = _pr.GetUserById(cs.UserId);
            return View(cases);
        }

        ////////////////////////////// JSON Methods ////////////////////////////////
        [Authorize]
        public JsonResult SaveCase(string type, string signature, string instance, string id)
        {
            if (!String.IsNullOrEmpty(type) && !String.IsNullOrEmpty(instance) && !String.IsNullOrEmpty(id))
            {
                try
                {

                    var cases = new CaseModel
                    {
                        Type = type,
                        ActSignature = signature,
                        Instance = instance,
                        PriceAll = "0",
                        UserId = id,
                        AddDate = DateTime.Now,
                        Status = false
                    };
                    _cr.Add(cases);
                    _cr.SaveChanges();

                    return Json(cases, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json("ERROR", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("ERROR", JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Add files to database
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin, Partner")]
        public JsonResult UploadFile(string caseId)
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];

                    }
                    return Json("ADDED", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("EMPTY", JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {
                return Json("ERROR", JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Admin, Partner")]
        public JsonResult UploadEvidence(string caseId)
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];

                    }
                    return Json("ADDED", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("EMPTY", JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {
                return Json("ERROR", JsonRequestBehavior.AllowGet);
            }
        }
    }
}