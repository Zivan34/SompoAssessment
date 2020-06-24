using SompoAssessment.Helpers;
using System.Web.Mvc;
using BussinessObjects.SompoAPI;
using SompoPolicyCore.Interface;
using Newtonsoft.Json;

namespace SompoAssessment.Controllers
{
    public class HomeController : Controller
    {
        private IPolicyStatusRequestWriter policyStatusRequestWriter;
        private IPolicyStatusRequestUpdater policyStatusRequestUpdater;

        public HomeController(IPolicyStatusRequestWriter policyStatusRequestWriter,
            IPolicyStatusRequestUpdater policyStatusRequestUpdater)
        {
            this.policyStatusRequestWriter = policyStatusRequestWriter;
            this.policyStatusRequestUpdater = policyStatusRequestUpdater;
        }
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
                policyStatusRequestUpdater.UpdateResponeByID(recordID, JsonConvert.SerializeObject(jsonResult.Data));
            }
            return jsonResult;
        }
    }
}