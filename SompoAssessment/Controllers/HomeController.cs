﻿using SompoAssessment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessObjects.SompoAPI;
using System.Web.Helpers;
using SompoPolicyCore.Interface;
using SompoPolicyCore.Class;
using Newtonsoft.Json;

namespace SompoAssessment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetPolicyStatus(Request.PolicyStatusRequest request)
        {
            string url = "https://api.sompojapan.com.tr/sample/engine";
            request.Authentication = new Request.Authentication();
            IPolicyStatusRequestWriter policyStatusRequestWriter = new PolicyStatusRequestWriter();
            var response = API.Post<Response.PolicyStatusResults, Request.PolicyStatusRequest>(url, request);
            int recordID = 0;
            if(response.IsSucccess)
            {
                recordID = policyStatusRequestWriter.SavePolicyStatus(request.Object);
            }
            var jsonResult = Json(new { data = response.Data, response.IsSucccess, response.Message }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            if(recordID != 0)
            {
                IPolicyStatusRequestUpdater policyStatusRequestUpdater = new PolicyStatusRequestUpdater();
                policyStatusRequestUpdater.UpdateResponeByID(recordID, JsonConvert.SerializeObject(jsonResult.Data));
            }
            return jsonResult;
        }
    }
}