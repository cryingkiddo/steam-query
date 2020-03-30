using System;
using System.IO;
using System.Net;
using System.Text;

namespace steamquery.web {
    public class GET : IDisposable {
        private string _response = null;
        private HttpWebRequest request;

        public string response => _response;

        public GET(string url, Encoding encoding) {
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse()) {
                using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream(), encoding)) {
                    _response = reader.ReadToEnd();
                }
            }
        }

        public void Dispose() {
            request.Abort();
            request = null;
            _response = null;
            GC.Collect();
        }
    }
}
