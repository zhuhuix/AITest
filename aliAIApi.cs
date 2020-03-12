using System.IO;
using System.Text;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Web;

namespace AITest1
{
    class aliAIApi
    {

        private const string method = "POST";
        private const string appcode = "请填入阿里平台的appcode";
        public string GetOcr(string type, string fileName)
        {
            string querys = "";

           // string bodys = "{\"image\":\"图片二进制数据的base64编码或者图片url\"#图片以base64编码的string}";

            string base64 = getFileBase64(fileName);

            string bodys = "{\"image\":\"" + base64 + "\"" + "}";

            string  url = "";

            switch (type)
            {
                case "名片":
                    url = "https://dm-57.data.aliyun.com/rest/160601/ocr/ocr_business_card.json";
                    break;
                case "车牌":
                    url = "https://ocrcp.market.alicloudapi.com/rest/160601/ocr/ocr_vehicle_plate.json";
                    break;
                default:
                    return "";
            }

            HttpWebRequest httpRequest = null;
            HttpWebResponse httpResponse = null;

            if (0 < querys.Length)
            {
                url = url + "?" + querys;
            }

            if (url.Contains("https://"))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                httpRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            }
            else
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            httpRequest.Method = method;
            httpRequest.Headers.Add("Authorization", "APPCODE " + appcode);
            //根据API的要求，定义相对应的Content-Type
            httpRequest.ContentType = "application/json; charset=UTF-8";
            if (0 < bodys.Length)
            {
                byte[] data = Encoding.UTF8.GetBytes(bodys);
                using (Stream stream = httpRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            try
            {
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
            }

            Console.WriteLine(httpResponse.StatusCode);
            Console.WriteLine(httpResponse.Method);
            Console.WriteLine(httpResponse.Headers);
            Stream st = httpResponse.GetResponseStream();
            StreamReader reader = new StreamReader(st, Encoding.GetEncoding("utf-8"));
            return ("阿里" + type + "识别:\r\n"+reader.ReadToEnd());
        }


        private static string getFileBase64(string fileName)
        {
            FileStream filestream = new FileStream(fileName, FileMode.Open);
            byte[] arr = new byte[filestream.Length];
            filestream.Read(arr, 0, (int)filestream.Length);
            string baser64 = Convert.ToBase64String(arr);
            filestream.Close();
            return baser64;
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}
