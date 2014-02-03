using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace MyHttpWebServer
{
    public class HttpRequest
    {
        public string Method { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }
        public HttpResponse Httpresponse { get; set; }

        public HttpRequest()
        {
            Method = "";
            Url = "";
            Version = "";
        }

        internal HttpResponse Execute()
         {
            Httpresponse = new HttpResponse();
            if (Method == "GET")
            {
                var requestFilePath = GetPath();
                try
                {
                    if (File.Exists(requestFilePath))
                    {                        
                        Httpresponse.Data = File.ReadAllText(requestFilePath);
                        var extension = Path.GetExtension(requestFilePath);
                        if (extension != null)
                            Httpresponse.ContentType = GetContentType(extension.TrimStart(".".ToCharArray()));
                        Httpresponse.StatusCode = "200 OK";
                    }
                    else
                    {
                        FileNotFound();   
                    }
                }
                catch (Exception exception)
                {
                    Httpresponse.Data = "<html><body><h1>500 Internal server error</h1><pre>" +
                                                            exception + "</pre></body></html>";
                    Httpresponse.StatusCode = "500 Internal server error";
                }

                SetOtherResponseFields();
            }            
            return Httpresponse;
            //throw new NotImplementedException();
        }

        private string GetPath()
        {
            string rootdirectory = WebServer.RootDirectory.Replace("\\", "/");
            var requestFile = Path.Combine(rootdirectory, Url.TrimStart('/'));
            requestFile = requestFile.Replace("\\", "/");
            if (String.CompareOrdinal(requestFile, rootdirectory) == 0)
            requestFile = requestFile + "/index.html";
            return requestFile;
        }

        private void FileNotFound()
        {
            Httpresponse.Data = "<html><body><h1>404 File Not Found</h1></body></html>";
            Httpresponse.ContentType = GetContentType("html");
            Httpresponse.StatusCode = "404 Not found";
        }

        private void SetOtherResponseFields()
        {
            Httpresponse.KeepAlive = "Close";
            Httpresponse.Server = "";
            Httpresponse.ContentLength = Httpresponse.Data.Length;
            Httpresponse.Version = Version;
        }

        private string GetContentType(string extension)
        {
            if (Regex.IsMatch(extension, "^[a-z0-9]+$", RegexOptions.IgnoreCase | RegexOptions.Compiled))
                return (Registry.GetValue(@"HKEY_CLASSES_ROOT\." + extension, "Content Type", null) as string) ?? "application/octet-stream";
            return "application/octet-stream";
        }
    }
}
