﻿namespace MyHttpWebServer
{
    public class HttpResponse
    {
        //TODO - implement structure for header and body
        public string StatusCode { get; set; }
        public string ContentType { get; set; }
        public string Data { get; set; }
        public string Version { get; set; }
        public int ContentLength { get; set; }
        public string Server { get; set; }
        public string KeepAlive { get; set; }

        public HttpResponse()
        {
            StatusCode = "";
            ContentType = "";
            Data = "";
            Version = "";
            ContentLength = 0;
            Server = "";
            KeepAlive = "";
        }
    }
}
