using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace AITest1
{
    class bdAIApi
    {

        public  string GetOcr(string type,string fileName)
        {
            string token = AccessToken.getAccessToken();
            string url = "";
            switch (type)
            {
                case "名片":
                    url = "https://aip.baidubce.com/rest/2.0/ocr/v1/business_card";
                    break;
                case "车牌":
                    url = "https://aip.baidubce.com/rest/2.0/ocr/v1/license_plate";
                    break;
                default:
                    return "";
            }
            string host = url+"?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            // 图片的base64编码
            string base64 = getFileBase64(fileName);
            string str = "image=" + HttpUtility.UrlEncode(base64);
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();
            Console.WriteLine(result);
            return "百度"+ type + "识别:\r\n"+result;
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

       

        private static class AccessToken
        {
            public class Token
            {
                public String refresh_token { get; set; }
                public Int32 expires_in { get; set; }
                public String scope { get; set; }
                public String session_key { get; set; }
                public String access_token { get; set; }
                public String session_secret { get; set; }
            }


            // 调用getAccessToken()获取的 access_token建议根据expires_in 时间 设置缓存
            // 返回token示例
            //public static String TOKEN = "24.adda70c11b9786206253ddb70affdc46.2592000.1493524354.282335-1234567";

            // 百度云中开通对应服务应用的 API Key 建议开通应用的时候多选服务
            private static String clientId = "请填入百度平台的API_key";
            // 百度云中开通对应服务应用的 Secret Key
            private static String clientSecret = "请填入百度平台的Secret Key";

            public static string getAccessToken()
            {

                String authHost = "https://aip.baidubce.com/oauth/2.0/token";
                HttpClient client = new HttpClient();
                List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
                paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                paraList.Add(new KeyValuePair<string, string>("client_id", clientId));
                paraList.Add(new KeyValuePair<string, string>("client_secret", clientSecret));

                HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
                String result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                Token token = JsonConvert.DeserializeObject<Token>(result);
                return token.access_token;

            }
        }

    }
}
