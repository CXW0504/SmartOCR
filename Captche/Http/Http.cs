using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;

namespace Http
{
    public class Http
    {
        public Image PostImg(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.Trim());
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Image image = Image.FromStream(response.GetResponseStream());
            response.Close();
            return image;
        }
    }
}
