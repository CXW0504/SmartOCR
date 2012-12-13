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
        public string PostImg(string url)
        {
            Random r = new Random();
            string file = "source/" + r.Next(9999).ToString() + ".bmp";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.Trim());
            request.Method = "GET";
            request.ContentType = "image/bmp";
            request.Referer = url;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
            Stream strm = response.GetResponseStream();
            long length = response.ContentLength;
            long i = 0;
            while (i < length)
            {
                byte[] bit = new byte[1024];
                i += strm.Read(bit, 0, bit.Length);
                fs.Write(bit, 0, bit.Length);
            }
            strm.Close();
            fs.Close();
            response.Close();
            return file;
        }
    }
}
