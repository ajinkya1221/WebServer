using System;

namespace MyHttpWebServer
{
    class ServerRunner
    {
        static void Main(string[] args)
        {
            int port = int.Parse(args[0]);
            string fullDirectoryPath = "";

            for (int i = 1; i<args.Length; i++)
            {
                fullDirectoryPath = fullDirectoryPath + " " + args[i];
            }

            fullDirectoryPath = fullDirectoryPath.TrimStart();

            var myServer = new WebServer(new PortListener());
            Console.WriteLine("Server running on :" + port + " port");
            Console.WriteLine("Press any key to exit.");
            myServer.Start(port,fullDirectoryPath);
            Console.ReadKey();
            
        }
    }
}
