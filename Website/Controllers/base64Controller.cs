using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace Website.Controllers
{
    public class base64Controller : Controller
    {
        //
        // GET: /base64/

        public ActionResult Index()
        {
            return View("Default");
        }

        [HttpPost]
        public JsonResult Encode(string input)
        {
            string encodedString = null;
            bool result = true;
            string message = "OK";
            try
            {
                encodedString = Base64.Encode(input);
            }
            catch (Exception ex)
            {
                result = false;
                message = ex.Message;
                return (Json(new {
                    Result = result,
                    EncodedString = string.Empty,
                    Message = message
                }));
            }
            
            var output = new
            {
                Result = result,
                EncodedString = encodedString,
                Message = message
            };
            return Json(output, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult Decode(string input)
        {
            string decodedString = null;
            bool result = true;
            string message = "OK";
            try
            {
                decodedString = Base64.Decode(input);
            }
            catch (Exception ex)
            {
                result = false;
                message = ex.Message;
                return (Json(new
                {
                    Result = result,
                    DecodedString = string.Empty,
                    Message = message
                }));
            }

            var output = new
            {
                Result = result,
                DecodedString = decodedString,
                Message = message
            };
            return Json(output, JsonRequestBehavior.DenyGet);
        }

    }
}
