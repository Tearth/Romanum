using System.Web.Mvc;
using App.Services.CaptchaServices;
using Business.Services.ConfigServices;

namespace App.MVC.Filters
{
    public class UseCaptchaAttribute : ActionFilterAttribute
    {
        public IConfigService ConfigService { get; set; }
        public ICaptchaService CaptchaService { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var requestHttpMethod = filterContext.HttpContext.Request.HttpMethod;

            switch(requestHttpMethod)
            {
                case "GET": ProcessGetRequest(filterContext); break;
                case "POST": ProcessPostRequest(filterContext); break;
            }

            base.OnActionExecuting(filterContext);
        }

        private void ProcessGetRequest(ActionExecutingContext filterContext)
        {
            var captchaPublicKey = ConfigService.GetValue<string>("CaptchaPublicKey");
            filterContext.Controller.ViewData["CaptchaPublicKey"] = captchaPublicKey;
        }

        private void ProcessPostRequest(ActionExecutingContext filterContext)
        {
            var captchaSecretKey = ConfigService.GetValue<string>("CaptchaSecretKey");
            var responseCode = filterContext.HttpContext.Request.Form["g-recaptcha-response"];

            if (!CaptchaService.Verify(captchaSecretKey, responseCode))
            {
                filterContext.Result = new ViewResult
                {
                    ViewData = filterContext.Controller.ViewData,
                    TempData = filterContext.Controller.TempData
                };
            }
        }
    }
}