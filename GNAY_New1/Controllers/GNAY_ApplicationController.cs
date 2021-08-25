using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using GNAY_New1;
using GNAY_New1.Models;

namespace GNAY_New1.Controllers
{
    public class GNAY_ApplicationController : Controller
    {
        //rzp_test_6GzieAHfpUCJgh
        //6JiXBONvMHa8btXtmMc2NBmH
        private TorqueSolutionsEntities db = new TorqueSolutionsEntities();

        // GET: GNAY_Application
        [Authorize]
        public ActionResult Index()
        {
            return View(db.GNAY_Application.ToList());
        }

        public ActionResult SubmittedMessage()
        {
            return View();
        }

        // GET: GNAY_Application/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GNAY_Application gNAY_Application = db.GNAY_Application.Find(id);
            if (gNAY_Application == null)
            {
                return HttpNotFound();
            }
            return View(gNAY_Application);
        }

        public ActionResult DrawResult()
        {
            ViewBag.DrawMessage = "";
            return View("DrawResult", new DrawResultModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DrawResult([Bind(Include = "ApplicationNumber")] DrawResultModel drawresult)
        {
            string message = "";

            DateTime timeUtc = DateTime.UtcNow;
            DateTime indiaTime = DateTime.Now;
            try
            {
                TimeZoneInfo indiaZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                indiaTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, indiaZone);
                message = $"Current date and time are {indiaTime.ToString("dd-MMM-yyyy")} {indiaTime.ToLongTimeString()}.";
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine("The registry does not define the Central Standard Time zone.");
            }
            catch (InvalidTimeZoneException)
            {
                Console.WriteLine("Registry data on the Central Standard Time zone has been corrupted.");
            }

            if (indiaTime < new DateTime(2021, 6, 25,12,0,0))
            {
                message = message + " Draw results will be available on 25-Jun-2021 after 12 noon. Please check again on/after draw date.";
            }
            else
            {
                var application = db.GNAY_Application.Where(u => u.ApplicationNumber == drawresult.ApplicationNumber).SingleOrDefault();
                if (application == null)
                {
                    message = "Incorrect application number entered!";
                }
                else
                {
                    var result = ConfigurationManager.AppSettings["DrawSuccess"].Split(',');
                    if (result.Contains(drawresult.ApplicationNumber.ToString()))
                        message = $"Congratulations {application.ApplicantName}! Your application is selected by online lucky draw process.";
                    else
                        message = $"Sorry {application.ApplicantName}! Your application is not selected by Lucky draw. Better luck for next time.";
                }
            }

            ViewBag.DrawMessage = message;
            return View("DrawResult", drawresult);
        }

        // GET: GNAY_Application/Create
        public ActionResult Create(string type="")
        {
            if(type != "afterclosed")
                return View("BookingClosed");

            ViewBag.MessageStyle= "margin: 10px 0px 0px 0px; padding: 5px; clear:both; visibility:hidden";
            @ViewBag.ErrorMessage = "";
            ApplicationViewModel obj = new ApplicationViewModel
            {
                AddressProofCopy = "test",
                //DateOfSubmit = DateTime.Today,
                AmountPayable = 1000,
                AnnualIncome = 100000000,
                AnyPreviousLoan = false,
                ApplicantName = "test name",
                ApplicantPhoto = "test",
                ApplicationPaymentID = "12121",
                AppliedProject = "new project",
                CarpetAreaInFoot = 200,
                ClubbedIncomeFamilyMemberName = "test",
                ClubbedmemberAnyPreviousLoan = null,
                ClubbedmemberMonthlyNetIncome = 0,
                ClubbedmemberPreviousLoanBalance = 0,
                ClubbedmemberPreviousLoanEMI = 0,
                CoApplicantAnnualIncome = 0,
                CoApplicantApplicantName = "test",
                ApplicationNumber = 0,
                //ApplicationIPAddress = "1212",
                CoApplicantCommunicationAddress = "test",
                CoApplicantCommunicationPIN = "test",
                CoApplicantCommunicationState = "test",
                CoApplicantContactNumber = "test",
                CoApplicantDepartment = "test",
                CoApplicantDOB = DateTime.Today,
                CoApplicantEmailId = "test",
                CoApplicantFatherName = "test",
                CoApplicantIsNRI = false,
                CoApplicantNationality = "test",
                CoApplicantOccupation = "test",
                CoApplicantOfficeAddress = "test",
                CoApplicantOfficePIN = "12121",
                CoApplicantOfficeState = "test",
                CoApplicantPanNo = "test",
                CoApplicantPermanentAddress = "test",
                CoApplicantPermanentPIN = "test",
                CoApplicantPermanentState = "test",
                CoApplicantPhoto = "test",
                CommunicationAddress = "Chhalera, Sec 44, Noida",
                CommunicationPIN = "12121",
                CommunicationState = "Uttar Pradesh",
                ContactNumber = "1212121",
                Department = "Test Department",
                DOB = Convert.ToDateTime("5/5/1985"),
                EmailId = "luvkushch@gmail.com",
                EmployeeIDCopy = "test",
                FatherName = "Amit Singh",
                IsFirstProperty = true,
                IsNRI = false,
                LoanAmountRequired = 0,
                MonthlyGrossIncome = 100000,
                MonthlyNetIncome = 10000,
                Nationality = "Indian",
                Occupation = "Job",
                OfficeAddress = "Test Address",
                OfficePIN = "444444",
                OfficeState = "U.P.",
                PanCardCopy = "test",
                PanNo = "AWSSDS5656",
                PaymentPlan = "20-30",
                PaymentReceipt = "test",
                PermanentAddress = "Chhalera, Sec 44, Noida",
                PermanentPIN = "12121212",
                PermanentState = "Uttar Pradesh",
                PreviousLoanBalance = 0,
                PreviousLoanEMI = 0,
                RefundAccNo = "sasasa12121",
                RefundBankIFSC = "SDOC3434",
                RefundBankName = "Test bank",
                UnitType = "Plot 150mtr"

            };

            ApplicationViewModel obj1 = new ApplicationViewModel
            {
                AppliedProject = "GNAY",
                PaymentPlan="36 months"
            };

             return View(obj1); //prod
            //return View(obj); //debug
        }


        // POST: GNAY_Application/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationNumber,ApplicantName,FatherName,Nationality,DOB,IsNRI,PanNo,Occupation,Department,AnnualIncome,EmailId,ContactNumber,CommunicationAddress,CommunicationState,CommunicationPIN,PermanentAddress,PermanentState,PermanentPIN,OfficeAddress,OfficeState,OfficePIN,CoApplicantApplicantName,CoApplicantFatherName,CoApplicantNationality,CoApplicantDOB,CoApplicantIsNRI,CoApplicantPanNo,CoApplicantOccupation,CoApplicantDepartment,CoApplicantAnnualIncome,CoApplicantEmailId,CoApplicantContactNumber,CoApplicantCommunicationAddress," +
            "CoApplicantCommunicationState,CoApplicantCommunicationPIN,CoApplicantPermanentAddress,CoApplicantPermanentState,CoApplicantPermanentPIN,CoApplicantOfficeAddress,CoApplicantOfficeState,CoApplicantOfficePIN,AppliedProject,UnitType,CarpetAreaInFoot,PaymentPlan,AmountPayable,ApplicationPaymentID,PaymentReceipt,RefundAccNo,RefundBankName,RefundBankIFSC,IsFirstProperty,LoanAmountRequired,MonthlyGrossIncome,MonthlyNetIncome,AnyPreviousLoan,PreviousLoanEMI,PreviousLoanBalance,ApplicationIPAddress,ClubbedIncomeFamilyMemberName,ClubbedmemberMonthlyNetIncome,ClubbedmemberAnyPreviousLoan," +
            "ClubbedmemberPreviousLoanEMI,ClubbedmemberPreviousLoanBalance,EmployeeIDCopy," +
            "PanCardCopy,AddressProofCopy,ApplicantPhoto,CoApplicantPhoto,DateOfSubmit,EmployeeIDFile,AddressProofFile," +
            "PanCardFile,ApplicantPhotoFile,CoApplicantPhotoFile,PaymentReceiptFile,BookingAmount")] ApplicationViewModel gNAY_Application)
        {
            

            GNAY_Application obj = new GNAY_Application();

            // Upload documents
            if (gNAY_Application.EmployeeIDFile != null)
            {
                string filename = UploadFile(gNAY_Application.EmployeeIDFile);
                if(filename.Contains("Error:"))
                {
                    ViewBag.ErrorMessage = filename;
                    ViewBag.MessageStyle = "margin: 10px 0px 0px 0px; padding: 5px; clear:both;";
                    return View(gNAY_Application);
                }

                obj.EmployeeIDCopy = filename;
            }
                
            if (gNAY_Application.AddressProofFile != null)
            {
                string filename = UploadFile(gNAY_Application.AddressProofFile);
                if (filename.Contains("Error:"))
                {
                    ViewBag.ErrorMessage = filename;
                    ViewBag.MessageStyle = "margin: 10px 0px 0px 0px; padding: 5px; clear:both;";
                    return View(gNAY_Application);
                }

                obj.AddressProofCopy = filename;
            }
                
            if (gNAY_Application.PanCardFile != null)
            {
                string filename = UploadFile(gNAY_Application.PanCardFile);
                if (filename.Contains("Error:"))
                {
                    ViewBag.ErrorMessage = filename;
                    ViewBag.MessageStyle = "margin: 10px 0px 0px 0px; padding: 5px; clear:both;";
                    return View(gNAY_Application);
                }

                obj.PanCardCopy = filename;
            }
                
            if (gNAY_Application.ApplicantPhotoFile != null)
            {
                string filename = UploadFile(gNAY_Application.ApplicantPhotoFile);
                if (filename.Contains("Error:"))
                {
                    ViewBag.ErrorMessage = filename;
                    ViewBag.MessageStyle = "margin: 10px 0px 0px 0px; padding: 5px; clear:both;";
                    return View(gNAY_Application);
                }

                obj.ApplicantPhoto = filename; 
            }
                
            if (gNAY_Application.CoApplicantPhotoFile != null)
            {
                string filename = UploadFile(gNAY_Application.CoApplicantPhotoFile);
                if (filename.Contains("Error:"))
                {
                    ViewBag.ErrorMessage = filename;
                    ViewBag.MessageStyle = "margin: 10px 0px 0px 0px; padding: 5px; clear:both;";
                    return View(gNAY_Application);
                }

                obj.CoApplicantPhoto = filename;
            }

            if (gNAY_Application.PaymentReceiptFile != null)
            {
                string filename = UploadFile(gNAY_Application.PaymentReceiptFile);
                if (filename.Contains("Error:"))
                {
                    ViewBag.ErrorMessage = filename;
                    ViewBag.MessageStyle = "margin: 10px 0px 0px 0px; padding: 5px; clear:both;";
                    return View(gNAY_Application);
                }

                obj.PaymentReceipt = filename;
            }

            obj.AmountPayable = gNAY_Application.AmountPayable;
            obj.AnnualIncome = gNAY_Application.AnnualIncome;
            obj.AnyPreviousLoan = gNAY_Application.AnyPreviousLoan;
            obj.ApplicantName = gNAY_Application.ApplicantName;
            //obj.ApplicationIPAddress = //gNAY_Application.ApplicationIPAddress ;
            //obj.ApplicationNumber = //gNAY_Application.ApplicationNumber ;
            obj.ApplicationPaymentID = gNAY_Application.ApplicationPaymentID;
            obj.AppliedProject = gNAY_Application.AppliedProject;
            obj.CarpetAreaInFoot = gNAY_Application.CarpetAreaInFoot;
            obj.ClubbedIncomeFamilyMemberName = gNAY_Application.ClubbedIncomeFamilyMemberName;
            obj.ClubbedmemberAnyPreviousLoan = gNAY_Application.ClubbedmemberAnyPreviousLoan;
            obj.ClubbedmemberMonthlyNetIncome = gNAY_Application.ClubbedmemberMonthlyNetIncome;
            obj.ClubbedmemberPreviousLoanBalance = gNAY_Application.ClubbedmemberPreviousLoanBalance;
            obj.ClubbedmemberPreviousLoanEMI = gNAY_Application.ClubbedmemberPreviousLoanEMI;
            obj.CoApplicantAnnualIncome = gNAY_Application.CoApplicantAnnualIncome;
            obj.CoApplicantApplicantName = gNAY_Application.CoApplicantApplicantName;
            obj.CoApplicantCommunicationAddress = gNAY_Application.CoApplicantCommunicationAddress;
            obj.CoApplicantCommunicationPIN = gNAY_Application.CoApplicantCommunicationPIN;
            obj.CoApplicantCommunicationState = gNAY_Application.CoApplicantCommunicationState;
            obj.CoApplicantContactNumber = gNAY_Application.CoApplicantContactNumber;
            obj.CoApplicantDepartment = gNAY_Application.CoApplicantDepartment;
            obj.CoApplicantDOB = gNAY_Application.CoApplicantDOB;
            obj.CoApplicantEmailId = gNAY_Application.CoApplicantEmailId;
            obj.CoApplicantFatherName = gNAY_Application.CoApplicantFatherName;
            obj.CoApplicantIsNRI = gNAY_Application.CoApplicantIsNRI;
            obj.CoApplicantNationality = gNAY_Application.CoApplicantNationality;
            obj.CoApplicantOccupation = gNAY_Application.CoApplicantOccupation;
            obj.CoApplicantOfficeAddress = gNAY_Application.CoApplicantOfficeAddress;
            obj.CoApplicantOfficePIN = gNAY_Application.CoApplicantOfficePIN;
            obj.CoApplicantOfficeState = gNAY_Application.CoApplicantOfficeState;
            obj.CoApplicantPanNo = gNAY_Application.CoApplicantPanNo;
            obj.CoApplicantPermanentAddress = gNAY_Application.CoApplicantPermanentAddress;
            obj.CoApplicantPermanentPIN = gNAY_Application.CoApplicantPermanentPIN;
            obj.CoApplicantPermanentState = gNAY_Application.CoApplicantPermanentState;
            obj.CommunicationAddress = gNAY_Application.CommunicationAddress;
            obj.CommunicationPIN = gNAY_Application.CommunicationPIN;
            obj.CommunicationState = gNAY_Application.CommunicationState;
            obj.ContactNumber = gNAY_Application.ContactNumber;
            obj.Department = gNAY_Application.Department;
            obj.DOB = gNAY_Application.DOB;
            obj.EmailId = gNAY_Application.EmailId;
            obj.FatherName = gNAY_Application.FatherName;
            obj.IsFirstProperty = gNAY_Application.IsFirstProperty;
            obj.IsNRI = gNAY_Application.IsNRI;
            obj.LoanAmountRequired = gNAY_Application.LoanAmountRequired;
            obj.MonthlyGrossIncome = gNAY_Application.MonthlyGrossIncome;
            obj.MonthlyNetIncome = gNAY_Application.MonthlyNetIncome;
            obj.Nationality = gNAY_Application.Nationality;
            obj.Occupation = gNAY_Application.Occupation;
            obj.OfficeAddress = gNAY_Application.OfficeAddress;
            obj.OfficePIN = gNAY_Application.OfficePIN;
            obj.OfficeState = gNAY_Application.OfficeState;
            obj.PanNo = gNAY_Application.PanNo;
            obj.PaymentPlan = gNAY_Application.PaymentPlan;
            obj.PermanentAddress = gNAY_Application.PermanentAddress;
            obj.PermanentPIN = gNAY_Application.PermanentPIN;
            obj.PermanentState = gNAY_Application.PermanentState;
            obj.PreviousLoanBalance = gNAY_Application.PreviousLoanBalance;
            obj.PreviousLoanEMI = gNAY_Application.PreviousLoanEMI;
            obj.RefundAccNo = gNAY_Application.RefundAccNo;
            obj.RefundBankIFSC = gNAY_Application.RefundBankIFSC;
            obj.RefundBankName = gNAY_Application.RefundBankName;
            obj.UnitType = gNAY_Application.UnitType;
            obj.DateOfSubmit = DateTime.Now;
            obj.IsReceptVerified = false;
            obj.bookingamountpaid = false;
            obj.bookingamount = gNAY_Application.BookingAmount;

            //OrderModel order = CreateOrder(obj);
            //obj.ApplicationPaymentID = order.orderId;
            if (ModelState.IsValid)
            {
                db.GNAY_Application.Add(obj);
                db.SaveChanges();
                ViewBag.ApplicationNumber = obj.ApplicationNumber.ToString();

                // send email
                try
                {
                    string subject = string.Format("Application submitted at GNAY");
                    StringBuilder emailBody = new StringBuilder();
                    emailBody.AppendLine("<table style='font-family:Arial, Helvetica, sans-serif;border-collapse: collapse;'>");
                    emailBody.AppendLine(string.Format("<tr><td style='border: 1px solid #ddd; padding: 4px; text-align: left; background-color: #4CAF50; color: white;'>Applicant Name</td><td>: {0}</td></tr>", obj.ApplicantName));
                    emailBody.AppendLine(string.Format("<tr><td style='border: 1px solid #ddd; padding: 4px; text-align: left; background-color: #4CAF50; color: white;'>Applicant Phone no</td><td>: {0}</td></tr>", obj.ContactNumber));
                    emailBody.AppendLine(string.Format("<tr><td style='border: 1px solid #ddd; padding: 4px; text-align: left; background-color: #4CAF50; color: white;'>Payment Id</td><td>: {0}</td></tr>", obj.ApplicationPaymentID));
                    emailBody.AppendLine(string.Format("<tr><td style='border: 1px solid #ddd; padding: 4px; text-align: left; background-color: #4CAF50; color: white;'>Registration Number</td><td>: {0}</td></tr>", obj.ApplicationNumber));
                    emailBody.AppendLine(string.Format("<tr><td style='border: 1px solid #ddd; padding: 4px; text-align: left; background-color: #4CAF50; color: white;'>Submit Date</td><td>: {0}</td></tr>", DateTime.Now.ToString("dd-MMM-yyyy")));

                    emailBody.AppendLine("</table>");
                    Static.SendEmail(subject, emailBody.ToString(), obj.EmailId);
                }
                catch (Exception ex)
                {

                }

                string message = string.Format("Your application has been sumitted. " +
               "Your application id is {0}." +
               " Please save the registration number for future reference. " +
               "Check your email for more details!", obj.ApplicationNumber);
                ViewBag.message = message;
                return View("SubmittedMessage");

            }

            //return View("PaymentPage", order);


            return View(gNAY_Application);
        }

        private OrderModel CreateOrder(GNAY_Application obj)
        {
            //razor pay payment configuration
            string keyid = ConfigurationManager.AppSettings["keyid"];
            string keysecret = ConfigurationManager.AppSettings["keysecret"];

            // Generate random receipt number for order
            Random randomObj = new Random();
            string transactionId = randomObj.Next(10000000, 100000000).ToString();

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient(keyid,keysecret);
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", obj.bookingamount*100);  // Amount will in paise
            options.Add("receipt", transactionId);
            options.Add("currency", "INR");
            options.Add("payment_capture", "0"); // 1 - automatic  , 0 - manual
                                                 //options.Add("notes", "-- You can put any notes here --");
            Razorpay.Api.Order orderResponse = client.Order.Create(options);
            string orderId = orderResponse["id"].ToString();

            // Create order model for return on view
            OrderModel orderModel = new OrderModel
            {
                orderId = orderResponse.Attributes["id"],
                razorpayKey = keyid,
                amount = (int)obj.bookingamount * 100,
                currency = "INR",
                name = obj.ApplicantName,
                email = obj.EmailId,
                contactNumber = obj.ContactNumber,
                address = obj.PermanentAddress,
                description = "Booking Amount Payment"
            };

            // Return on PaymentPage with Order data
            return orderModel;
        }

        [HttpPost]
        public ActionResult Complete()
        {
            //razor pay payment configuration
            string keyid = ConfigurationManager.AppSettings["keyid"];
            string keysecret = ConfigurationManager.AppSettings["keysecret"];

            // Payment data comes in url so we have to get it from url

            // This id is razorpay unique payment id which can be use to get the payment details from razorpay server
            string paymentId = Request.Params["rzp_paymentid"];

            // This is orderId
            string orderId = Request.Params["rzp_orderid"];

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient(keyid, keysecret);

            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

            // This code is for capture the payment 
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
            string amt = paymentCaptured.Attributes["amount"];

            //// Check payment made successfully

            if (paymentCaptured.Attributes["status"] == "captured")
            {
                var obj = db.GNAY_Application.Where(u => u.ApplicationPaymentID == orderId).SingleOrDefault();
                obj.bookingamountpaid = true;
                db.SaveChanges();

                // send email
                try
                {
                    string subject = string.Format("Application submitted at GNAY");
                    StringBuilder emailBody = new StringBuilder();
                    emailBody.AppendLine("<table style='font-family:Arial, Helvetica, sans-serif;border-collapse: collapse;'>");
                    emailBody.AppendLine(string.Format("<tr><td style='border: 1px solid #ddd; padding: 4px; text-align: left; background-color: #4CAF50; color: white;'>Applicant Name</td><td>: {0}</td></tr>", obj.ApplicantName));
                    emailBody.AppendLine(string.Format("<tr><td style='border: 1px solid #ddd; padding: 4px; text-align: left; background-color: #4CAF50; color: white;'>Applicant Phone no</td><td>: {0}</td></tr>", obj.ContactNumber));
                    emailBody.AppendLine(string.Format("<tr><td style='border: 1px solid #ddd; padding: 4px; text-align: left; background-color: #4CAF50; color: white;'>Payment Id</td><td>: {0}</td></tr>", obj.ApplicationPaymentID));
                    emailBody.AppendLine(string.Format("<tr><td style='border: 1px solid #ddd; padding: 4px; text-align: left; background-color: #4CAF50; color: white;'>Registration Number</td><td>: {0}</td></tr>", obj.ApplicationNumber));
                    emailBody.AppendLine(string.Format("<tr><td style='border: 1px solid #ddd; padding: 4px; text-align: left; background-color: #4CAF50; color: white;'>Submit Date</td><td>: {0}</td></tr>", DateTime.Now.ToString("dd-MMM-yyyy")));

                    emailBody.AppendLine("</table>");
                    Static.SendEmail(subject, emailBody.ToString(), obj.EmailId);
                }
                catch(Exception ex)
                {

                }

                // Create these action method
                return RedirectToAction("Success", new { id = orderId });
            }
            else
            {
                return RedirectToAction("Failed");
            }
        }

        public ActionResult Success(string id)
        {
            var obj = db.GNAY_Application.Where(u => u.ApplicationPaymentID == id).SingleOrDefault();
            string message = string.Format("Your application has been sumitted. " +
                "Your application id is {0}." +
                " Please save the registration number for future reference. " +
                "Check your email for more details!", obj.ApplicationNumber);
            ViewBag.message = message;
            return View("SubmittedMessage");
        }

        public ActionResult Failed()
        {
            string message = "You application submission is failed. Please try again after some time or contact at +91-9818729828.";
            ViewBag.message = message;
            return View("SubmittedMessage");
        }


        public string UploadFile(HttpPostedFileBase postedfile)
        {
            try
            {
                if (postedfile.ContentLength > 1200000)
                    return "Error: Uploaded file size greater than 1 MB";
                string filename = postedfile.FileName;
                string FileName = Path.GetFileNameWithoutExtension(filename);

                //To Get File Extension  
                string FileExtension = Path.GetExtension(filename);

                //Add Current Date To Attached File Name  
                FileName = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + "-" + FileName.Trim() + FileExtension;

                //Get Upload path from Web.Config file AppSettings.  
                string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

                //Its Create complete path to store in server.  
                //gNAY_Application.EmployeeIDCopy = UploadPath + FileName;
                string fullpath = Server.MapPath("~") + UploadPath + FileName;

                //To copy and save file into server.  
                postedfile.SaveAs(fullpath);

                //return relative path
                return UploadPath + FileName;
            }
            catch(Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        // GET: GNAY_Application/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GNAY_Application gNAY_Application = db.GNAY_Application.Find(id);
            if (gNAY_Application == null)
            {
                return HttpNotFound();
            }
            return View(gNAY_Application);
        }

        // POST: GNAY_Application/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationNumber,ApplicantName,FatherName,Nationality,DOB,IsNRI,PanNo,Occupation,Department,AnnualIncome,EmailId,ContactNumber,CommunicationAddress,CommunicationState,CommunicationPIN,PermanentAddress,PermanentState,PermanentPIN,OfficeAddress,OfficeState,OfficePIN,CoApplicantApplicantName,CoApplicantFatherName,CoApplicantNationality,CoApplicantDOB,CoApplicantIsNRI,CoApplicantPanNo,CoApplicantOccupation,CoApplicantDepartment,CoApplicantAnnualIncome,CoApplicantEmailId,CoApplicantContactNumber,CoApplicantCommunicationAddress,CoApplicantCommunicationState,CoApplicantCommunicationPIN,CoApplicantPermanentAddress,CoApplicantPermanentState,CoApplicantPermanentPIN,CoApplicantOfficeAddress,CoApplicantOfficeState,CoApplicantOfficePIN,AppliedProject,UnitType,CarpetAreaInFoot,PaymentPlan,AmountPayable,ApplicationPaymentID,PaymentReceipt,RefundAccNo,RefundBankName,RefundBankIFSC,IsFirstProperty,LoanAmountRequired,MonthlyGrossIncome,MonthlyNetIncome,AnyPreviousLoan,PreviousLoanEMI,PreviousLoanBalance,ApplicationIPAddress,ClubbedIncomeFamilyMemberName,ClubbedmemberMonthlyNetIncome,ClubbedmemberAnyPreviousLoan,ClubbedmemberPreviousLoanEMI,ClubbedmemberPreviousLoanBalance,EmployeeIDCopy,PanCardCopy,AddressProofCopy,ApplicantPhoto,CoApplicantPhoto,DateOfSubmit,IsReceptVerified")] GNAY_Application gNAY_Application)
        {
            //if (ModelState.IsValid)
            //{
            GNAY_Application dbobj = db.GNAY_Application.Where(u => u.ApplicationNumber == gNAY_Application.ApplicationNumber).SingleOrDefault();
            if ((bool)gNAY_Application.IsReceptVerified)
            {
                dbobj.IsReceptVerified = true;
                dbobj.ReceptVerifiedBy = User.Identity.Name;
                dbobj.LastModifiedDate = DateTime.Today;
                dbobj.LastModifiedBy = User.Identity.Name;
                // db.Entry(gNAY_Application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //}
            return View(gNAY_Application);
        }

        public JsonResult GetPriceForPlot(string plottype)
        {
            double amount = 0;
            double bookingamount = 0;
            switch (plottype)
            {
                case "Small":
                    amount = 623750;
                    bookingamount = 4100;
                    break;
                case "Medium":
                    amount = 742753;
                    bookingamount = 5100;
                    break;
                case "Large":
                    amount = 989750;
                    bookingamount = 6100;
                    break;
            }
            return Json(new { price = amount, bookingamount = bookingamount });
        }

        // GET: GNAY_Application/Delete/5
        //[Authorize]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GNAY_Application gNAY_Application = db.GNAY_Application.Find(id);
        //    if (gNAY_Application == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(gNAY_Application);
        //}

        // POST: GNAY_Application/Delete/5
        //[Authorize]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    GNAY_Application gNAY_Application = db.GNAY_Application.Find(id);
        //    db.GNAY_Application.Remove(gNAY_Application);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public enum UnitType
    {
        Small = 50,
        Medium = 60,
        Large = 80
    }
}
