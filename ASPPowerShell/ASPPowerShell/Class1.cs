using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.Ajax.Utilities;
using System.Data;

namespace ASPPowerShell
{
    public static class PS
    {
        public static object GetProcess()
        {

            PowerShell psPipeline = PowerShell.Create();

            psPipeline.AddCommand("get-process").AddScript("$input|select-object Name,Id,Path").Invoke(); ;

            var results = psPipeline.Invoke();

            return results;
        }
    }
}