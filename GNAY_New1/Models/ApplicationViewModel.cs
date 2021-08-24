using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GNAY_New1.Models
{
    public class ApplicationViewModel
    {
        public int ApplicationNumber { get; set; }
        [Display(Name = "*Name")]
        public string ApplicantName { get; set; }
        [Display(Name = "*Father's name")]
        public string FatherName { get; set; }
        [Display(Name = "*Nationality")]
        public string Nationality { get; set; }
        [Display(Name = "*Date Of Birth")]
        public System.DateTime DOB { get; set; }
        public bool IsNRI { get; set; }
        [Display(Name = "*PAN No")]
        public string PanNo { get; set; }
        [Display(Name = "*Occupation")]
        public string Occupation { get; set; }
        [Display(Name = "*Department")]
        public string Department { get; set; }
        [Display(Name = "*Annual Income")]
        public int AnnualIncome { get; set; }
        [Display(Name = "*Email ID")]
        [EmailAddress]
        public string EmailId { get; set; }
        [Display(Name = "*Contact No.")]
        public string ContactNumber { get; set; }
        [Display(Name = "*Communication Address")]
        public string CommunicationAddress { get; set; }
        [Display(Name = "*Communication State")]
        public string CommunicationState { get; set; }
        [Display(Name = "*Communication PIN")]
        public string CommunicationPIN { get; set; }
        [Display(Name = "*Permanent Address")]
        public string PermanentAddress { get; set; }
        [Display(Name = "*Permanent State")]
        public string PermanentState { get; set; }
        [Display(Name = "*Permanent PIN")]
        public string PermanentPIN { get; set; }
        [Display(Name = "*Office Address")]
        public string OfficeAddress { get; set; }
        [Display(Name = "*Office State")]
        public string OfficeState { get; set; }
        [Display(Name = "*Office PIN")]
        public string OfficePIN { get; set; }
        public string CoApplicantApplicantName { get; set; }
        public string CoApplicantFatherName { get; set; }
        public string CoApplicantNationality { get; set; }
        public Nullable<System.DateTime> CoApplicantDOB { get; set; }
        public Nullable<bool> CoApplicantIsNRI { get; set; }
        public string CoApplicantPanNo { get; set; }
        public string CoApplicantOccupation { get; set; }
        public string CoApplicantDepartment { get; set; }
        public Nullable<int> CoApplicantAnnualIncome { get; set; }
        public string CoApplicantEmailId { get; set; }
        public string CoApplicantContactNumber { get; set; }
        public string CoApplicantCommunicationAddress { get; set; }
        public string CoApplicantCommunicationState { get; set; }
        public string CoApplicantCommunicationPIN { get; set; }
        public string CoApplicantPermanentAddress { get; set; }
        public string CoApplicantPermanentState { get; set; }
        public string CoApplicantPermanentPIN { get; set; }
        public string CoApplicantOfficeAddress { get; set; }
        public string CoApplicantOfficeState { get; set; }
        public string CoApplicantOfficePIN { get; set; }
        [Display(Name = "*Applied Project")]
        public string AppliedProject { get; set; }
        [Display(Name = "*Unit Type")]
        public string UnitType { get; set; }
        [Display(Name = "*Carpet Area(ft)")]
        public decimal CarpetAreaInFoot { get; set; }
        [Display(Name = "*Payment Plan")]
        public string PaymentPlan { get; set; }
        [Display(Name = "*Total Payable Amt")]
        public Nullable<int> AmountPayable { get; set; }
        [Display(Name = "*Payment ID")]
        public string ApplicationPaymentID { get; set; }
        [Display(Name = "*Upload Receipt")]
        public string PaymentReceipt { get; set; }
        [Display(Name = "*Refund Acc No")]
        public string RefundAccNo { get; set; }
        [Display(Name = "*Refund Bank Name")]
        public string RefundBankName { get; set; }
        [Display(Name = "*Refund Bank IFSC")]
        public string RefundBankIFSC { get; set; }
        public bool IsFirstProperty { get; set; }
        [Display(Name = "*Loan Amount Required?")]
        public Nullable<int> LoanAmountRequired { get; set; }
        public Nullable<int> MonthlyGrossIncome { get; set; }
        public Nullable<int> MonthlyNetIncome { get; set; }
        public Nullable<bool> AnyPreviousLoan { get; set; }
        public Nullable<int> PreviousLoanEMI { get; set; }
        public Nullable<int> PreviousLoanBalance { get; set; }
        public string ClubbedIncomeFamilyMemberName { get; set; }
        public Nullable<int> ClubbedmemberMonthlyNetIncome { get; set; }
        public Nullable<bool> ClubbedmemberAnyPreviousLoan { get; set; }
        public Nullable<int> ClubbedmemberPreviousLoanEMI { get; set; }
        public Nullable<int> ClubbedmemberPreviousLoanBalance { get; set; }
        [Display(Name = "Upload EmployeeID")]
        public string EmployeeIDCopy { get; set; }
        [Display(Name = "*Upload PAN")]
        public string PanCardCopy { get; set; }
        [Display(Name = "*Upload Address Proof")]
        public string AddressProofCopy { get; set; }
        [Display(Name = "*Upload Photo")]
        public string ApplicantPhoto { get; set; }
        [Display(Name = "*Co Applicant Photo")]
        public string CoApplicantPhoto { get; set; }

        public HttpPostedFileBase EmployeeIDFile { get; set; }
        public HttpPostedFileBase AddressProofFile { get; set; }
        public HttpPostedFileBase ApplicantPhotoFile { get; set; }
        public HttpPostedFileBase CoApplicantPhotoFile { get; set; }
        public HttpPostedFileBase PaymentReceiptFile { get; set; }
        public HttpPostedFileBase PanCardFile { get; set; }
        public Nullable<int> BookingAmount { get; set; }
        public Nullable<bool> BookingAmountPaid { get; set; }

    }
}