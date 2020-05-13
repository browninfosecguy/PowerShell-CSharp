using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

//In order for this to work you need to install the following Package Install-Package Microsoft.PowerShell.SDK

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Time for PowerShell magic using C#!");

            PowerShell psPipeline = PowerShell.Create();

            psPipeline.AddCommand("Get-Process");

            psPipeline.AddParameter("Name", "chrome");

            var pipelineOutput = psPipeline.Invoke();

            Console.WriteLine("\r\nRaw pipeline output");

            Console.WriteLine(pipelineOutput);

            Console.WriteLine("\r\nList Each object seperately");

            if (pipelineOutput.Count > 0)
            {
                foreach (var objects in pipelineOutput)
                {
                    //If we want to Kill the Process, we invoke the Kill method.
                    //objects.Methods["kill"].Invoke(); 
                    
                    Console.WriteLine(objects.Members["name"].Value + " " + objects.Members["id"].Value);
                }

            }

        }
    }
}

