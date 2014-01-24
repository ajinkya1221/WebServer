using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHttpWebServer
{
    public class WebServer
    {

        public PortListener Listener { get; set; }
        public static string RootDirectory { get; set; }

        public WebServer(PortListener listener)
        {
            this.Listener = listener;
        }

        public void Start(int port, string rootDirectory)
        {
            RootDirectory = rootDirectory;
            Listener.Port = port;            
            Listener.Start();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
