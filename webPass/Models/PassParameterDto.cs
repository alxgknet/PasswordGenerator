using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webPass.Models
{
    public class PassParameterDto
    {
        [Display(Name = "Web Site or App Name\n(example: www.sitename.com)")]
        public string webSiteName { get; set; }
        [Display(Name = "User Name or Email Address\n(example: user@mail.com)")]
        public string userName { get; set; }
        [Display(Name = "Key value\n(remember it!)")]
        public string keyValue { get; set; }
        [Display(Name = "Length of generated password\n(default 8)")]
        [Required(ErrorMessage = "Length of generated password is required")]
        public int lengthOfPassword { get; set; }
        [Display(Name = "Use Special Character")]
        public bool useSpecialCharacter { get; set; }
    }
}