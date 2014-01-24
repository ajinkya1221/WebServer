using System;

namespace MyHttpWebServer
{
    class ServerRunner
    {
        static void Main(string[] args)
        {
            int port = int.Parse(args[0]);
            
            var myServer = new WebServer(new PortListener());
            Console.WriteLine("Server running on :" + port + " port");
            Console.WriteLine("Press any key to exit.");
            myServer.Start(port,args[1]);
            Console.ReadKey();
            
        }
    }
}
