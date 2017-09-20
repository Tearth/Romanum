using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.CaptchaServices
{
    public class CaptchaService : ServiceBase, ICaptchaService
    {
        const string VerifyUrl = "https://www.google.com/recaptcha/api/siteverify";

        public bool Verify(string secretCode, string responseCode)
        {
            var googleResponse = GetResponseFromGoogle(secretCode, responseCode);
            var status = CheckResult(googleResponse);

            return status;
        }

        string GetResponseFromGoogle(string secretCode, string responseCode)
        {
            var postData = new NameValueCollection();
            postData["secret"] = secretCode;
            postData["response"] = responseCode;

            var webClient = new WebClient();
            var bytes = webClient.UploadValues(VerifyUrl, "POST", postData);

            return ASCIIEncoding.UTF8.GetString(bytes);
        }

        bool CheckResult(string googleResponse)
        {
            var deserializedResponse = JsonConvert.DeserializeObject<GoogleResponse>(googleResponse);
            return deserializedResponse.Success;
        }
    }
}
