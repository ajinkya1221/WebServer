using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyHttpWebServer;

namespace MyHttpWebserver.Test
{
    public class TestCases
    {
        public void TestWebServer()
        {
            
            WebServer webServer = new WebServer(new PortListener());
            webServer.Start(8080, "rootDirectory");
        }

        public void TestPortListener()
        {
            PortListener portListener = new PortListener() {Port = 8080};
            portListener.Start();
        }
    }
}
