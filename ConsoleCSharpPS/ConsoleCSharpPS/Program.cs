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

            var objc = psPipe.AddScript("Get-Process|select-object *").Invoke();

            if(!psPipe.HadErrors)
            {
                foreach(var obj in objc)
                {
                    Console.WriteLine(obj.Members["Name"].Value + " " + obj.Members["Id"].Value + " " + obj.Members["Path"].Value);
                }

            }

            Console.ReadLine();

        }
    }
}
