using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webPass.Models
{
    public class PassParameterDto
    {
        [Display(Name = "Web Site or App Name")]
        public string webSiteName { get; set; }
        [Display(Name = "User Name or Email Address")]
        public string userName { get; set; }
        [Display(Name = "Key value (remember it!)")]
        public string keyValue { get; set; }
        [Display(Name = "Length of generated password")]
        public int lengthOfPassword { get; set; }
        [Display(Name = "Use Special Character")]
        public bool useSpecialCharacter { get; set; }
    }
}