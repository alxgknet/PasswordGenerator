using CaptchaMvc.HtmlHelpers;
using PasswordGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webPass.Models;

namespace webPass.Controllers
{
    public class PassGenController : Controller
    {

        // GET: PassGen/Create
        public ActionResult Create()
        {
            PassParameterDto model = new PassParameterDto()
            {
                lengthOfPassword = 8,
                useSpecialCharacter = true
            };
            return View(model);
        }

        // POST: PassGen/Create
        [HttpPost]
        public ActionResult Create(PassParameterDto model)
        {
            try
            {
                if (!this.IsCaptchaValid("Validate your captcha"))
                {
                    throw new Exception( "Invalid Captcha");
                }
                if (model == null || !ModelState.IsValid)
                {
                    throw new HttpException(System.Net.HttpStatusCode.BadRequest.ToString());
                }

                Parameters parameter = new Parameters()
                {
                    keyValue = model.keyValue == null ? "" : model.keyValue.Trim().ToLower(),
                    lengthOfPassword = model.lengthOfPassword,
                    userName = model.userName == null ? "": model.userName.Trim().ToLower(),
                    useSpecialCharacter = model.useSpecialCharacter,
                    webSiteName = model.webSiteName==null?"":model.webSiteName.Trim().ToLower()
                };

                string password = PassMaker.GetPassword(parameter);


                ViewBag.Password = password;

                return View();
            }
            catch (Exception x)
            {
                string error = "";
                while (x != null)
                {
                    error += x.Message;
                    x = x.InnerException;
                }
                ViewBag.Error = error;
                return View(model);
            }
        }
    }
}
