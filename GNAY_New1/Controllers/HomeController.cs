using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GNAY_New1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult SubmitQuery(string name, string email, string phone, string message)
        {
            // send email
            try
            {
                #region sending email
                string emaiBody = string.Format(@"<table style='border: 1px solid green; border-collapse: collapse;'>
                                <tr><td style='border: 1px solid green;'>Name</td><td style='border: 1px solid green;'> {0}</td></tr>
                                <tr><td style='border: 1px solid green;'>Contact</td><td style='border: 1px solid green;'> {1}</td></tr>
                                <tr><td style='border: 1px solid green;'>Emailid</td><td style='border: 1px solid green;'> {2}</td></tr>
                                <tr><td style='border: 1px solid green;'>Message</td><td style='border: 1px solid green;'> {3}</td></tr>
                                </table>", name.Trim(), phone.Trim(), email.Trim(), message.Trim());

                string emailSub = "Enquiry for greaternoidaawasyojna.com";
                Static.SendEmail(emailSub, emaiBody,"");
                return Json(new { result = "submitted" });
                #endregion
            }
            catch (Exception ex)
            {
                return Json(new { result = "failed", error = ex.Message });
            }
        }
    }
}