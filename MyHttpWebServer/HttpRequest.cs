using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MyHttpWebServer
{
    public class HttpRequest
    {
        public string Method { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }
        public HttpResponse Httpresponse { get; set; }

        internal HttpResponse Execute()
        {
            Httpresponse = new HttpResponse();
            if (Method == "GET")
            {
                string rootdirectory = WebServer.RootDirectory.Replace("\\", "/");
                var requestFile = Path.Combine(rootdirectory, Url.TrimStart('/'));
                if (String.CompareOrdinal(requestFile, rootdirectory) == 0)
                    requestFile = requestFile + "/index.html";
                
                try
                {
                    if (File.Exists(requestFile))
                    {
                        Httpresponse.Data = File.ReadAllText(requestFile);
                        var extension = Path.GetExtension(requestFile);
                        Httpresponse.ContentType = GetContentType(extension.TrimStart(".".ToCharArray()));
                        Httpresponse.StatusCode = "200 OK";
                    }
                    else
                    {
                        Httpresponse.Data = "<html><body><h1>404 File Not Found</h1></body></html>";
                        Httpresponse.ContentType = GetContentType("html");
                        Httpresponse.StatusCode = "404 Not found";
                    }
                }
                catch (Exception exception)
                {
                    Httpresponse.Data = "<html><body><h1>500 Internal server error</h1><pre>" +
                                                            exception + "</pre></body></html>";
                    Httpresponse.StatusCode = "500 Internal server error";
                }

                Httpresponse.KeepAlive = "Close";
                Httpresponse.Server = "";
                Httpresponse.ContentLength = Httpresponse.Data.Length;
                Httpresponse.Version = Version;
            }            
            return Httpresponse;
            //throw new NotImplementedException();
        }

        private string GetContentType(string extension)
        {
            if (Regex.IsMatch(extension, "^[a-z0-9]+$", RegexOptions.IgnoreCase | RegexOptions.Compiled))
                return (Registry.GetValue(@"HKEY_CLASSES_ROOT\." + extension, "Content Type", null) as string) ?? "application/octet-stream";
            return "application/octet-stream";
        }
    }
}
