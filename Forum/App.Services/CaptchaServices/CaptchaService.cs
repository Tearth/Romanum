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
        private const string VerifyUrl = "https://www.google.com/recaptcha/api/siteverify";

        public bool Verify(string secretCode, string responseCode)
        {
            var googleResponse = GetResponseFromGoogle(secretCode, responseCode);
            var status = CheckResult(googleResponse);

            return status;
        }

        private string GetResponseFromGoogle(string secretCode, string responseCode)
        {
            var postData = new NameValueCollection
            {
                ["secret"] = secretCode,
                ["response"] = responseCode
            };

            var webClient = new WebClient();
            var bytes = webClient.UploadValues(VerifyUrl, "POST", postData);

            return Encoding.UTF8.GetString(bytes);
        }

        private bool CheckResult(string googleResponse)
        {
            var deserializedResponse = JsonConvert.DeserializeObject<GoogleResponse>(googleResponse);
            return deserializedResponse.Success;
        }
    }
}
