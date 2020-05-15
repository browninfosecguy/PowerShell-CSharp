using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace ConsoleCSharpPS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

            PowerShell psPipe = PowerShell.Create();

            var objc = psPipe.AddCommand("get-process").Invoke();

            if(!psPipe.HadErrors)
            {
                foreach(var obj in objc)
                {
                    Console.WriteLine(obj.Members["name"].Value + " " + obj.Members["id"].Value);
                }

            }

            Console.ReadLine();

        }
    }
}
