using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace AITest1
{
    class txAIApi
    {
  
        public string app_id = "请填入腾讯平台的app_id";
        public string app_key = "请填入腾讯平台的app_key";
        public string GetOCR(string type,string file)
        {
            string rtn = string.Empty;
            byte[] image = System.IO.File.ReadAllBytes(file);
            string imgBase = Convert.ToBase64String(image);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("app_id", app_id);
            dic.Add("time_stamp", GenerateTimeStamp());
            dic.Add("nonce_str", GetNonceStr());
            dic.Add("sign", "");
            dic.Add("image", imgBase);
            rtn = urlencode(dic);
            rtn += "&app_key=" + app_key;
            rtn = MD5Encrypt(rtn, new UTF8Encoding()).ToUpper();
            dic["sign"] = rtn;
            dic = dic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            string url = "";
            switch (type)
            {
                case "名片":
                    url = "https://api.ai.qq.com/fcgi-bin/ocr/ocr_bcocr";
                    break;
                case "车牌":
                    url = "https://api.ai.qq.com/fcgi-bin/ocr/ocr_plateocr";
                    break;
                default:
                    return "";
            }
            HttpWebResponse response = CreatePostHttpResponse1(url, dic, null);
            using (Stream s = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                rtn = reader.ReadToEnd();
            }
            return "腾讯"+type+"识别："+rtn;
        }
        private HttpWebResponse CreatePostHttpResponse1(string url, IDictionary<string, string> parameters, CookieCollection cookies)
        {
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            //发送POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, encode(parameters[key]));
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, encode(parameters[key]));
                        i++;
                    }
                }
                //必须使用utf8
                byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            string[] values = request.Headers.GetValues("Content-Type");
            return request.GetResponse() as HttpWebResponse;
        }
        public string urlencode(Dictionary<string, string> dic)
        {
            string rtn = string.Empty;
            dic = dic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            foreach (var item in dic)
            {
                if (string.IsNullOrEmpty(item.Value))
                {
                    continue;
                }
                rtn += item.Key + "=" + encode(item.Value) + "&";
            }
            return rtn.TrimEnd('&');
        }
        public string encode(string str)
        {

            string rtn = string.Empty;
            foreach (char item in str)
            {
                if (Microsoft.JScript.GlobalObject.encodeURIComponent(item.ToString()).Length > 1)
                {
                    rtn += Microsoft.JScript.GlobalObject.encodeURIComponent(item.ToString()).ToUpper();
                }
                else
                {
                    rtn += item;
                }
            }
            return rtn;
        }
        public string MD5Encrypt(string input, Encoding encode)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(encode.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        public string GetNonceStr()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
