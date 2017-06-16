using CroweHorwath.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroweHorwath.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new WritingService();
            service.RequestToWrite("Hello World");
            System.Console.ReadLine();
        }
    }
}
