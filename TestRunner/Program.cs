using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHttpWebserver.Test;

namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCases testcase1 = new TestCases();
            testcase1.TestWebServer();
            Console.ReadKey(true);
        }
    }
}
