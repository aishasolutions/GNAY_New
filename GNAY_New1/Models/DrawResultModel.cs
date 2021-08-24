using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GNAY_New1.Models
{
    public class DrawResultModel
    {

        public int ApplicationNumber { get; set; }
        [Display(Name = "*Name")]
        public string ApplicantName { get; set; }
    }
}