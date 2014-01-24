using System;
using System.Collections.Generic;
using System.Text;

namespace MyHttpWebServer
{
    public class HttpAdapter
    {
        public HttpRequest Httprequest { get; set; }
        private string _requestString;
        private string _firstLineOfRequest;
        private int _index;
        public HttpRequest ToHttoRequest(byte[] bytes)
        {
            _requestString = Encoding.UTF8.GetString(bytes);
            _index = _requestString.IndexOf("\r\n", StringComparison.Ordinal);
            if (_index != -1)
            {
                _firstLineOfRequest = _requestString.Substring(0, _index);    
            }

            try
            {
                Httprequest = new HttpRequest
                {
                    Method = _firstLineOfRequest.Split(' ')[0],
                    Url = _firstLineOfRequest.Split(' ')[1],
                    Version = _firstLineOfRequest.Split(' ')[2]
                };
            }
            catch (NullReferenceException)
            {
                
                
            }
           

            return Httprequest;
            //throw new NotImplementedException();
        }

        public List<byte[]> ToBytes(HttpResponse response)
        {
            string tempHeader = string.Format("HTTP/1.1 {0}\r\n"
                                              + "Server: {1}\r\n"
                                              + "Content-Length: {2}\r\n"
                                              + "Content-Type: {3}\r\n"
                                              + "Keep-Alive: {4}\r\n"
                                              + "\r\n",
                                              response.StatusCode, response.Server, response.Data.Length, response.ContentType, response.KeepAlive);

            byte[] headerbytes = Encoding.ASCII.GetBytes(tempHeader);
            byte[] responsebytes = Encoding.ASCII.GetBytes(response.Data);

            var listOfByteArray = new List<byte[]> {headerbytes, responsebytes};

            return listOfByteArray;
                        
        }
    }
}
