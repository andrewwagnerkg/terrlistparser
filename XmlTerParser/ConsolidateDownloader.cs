using System;
using System.IO;
using System.Net.Http;

namespace XmlTerParser
{
    internal class ConsolidateDownloader : IXmlDownloader
    {
        private string filename = "consolidated.xml";

        public void Download(string url)
        {
            using(HttpClient client=new HttpClient())
            {
               var resp=client.GetAsync(url).Result;
               string respstr=resp.Content.ReadAsStringAsync().Result;
                if (File.Exists(this.filename))
                    File.Move(this.filename, $"{DateTime.Now.ToString("yyyyMMddhhmmss")}-{this.filename}");
                File.AppendAllText(this.filename, respstr);
            }
        }
    }
}
