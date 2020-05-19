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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PowerShell psPipeline = PowerShell.Create();

            Runspace runSpace = RunspaceFactory.CreateRunspace();

            runSpace.Open();

            RunspaceInvoke runspaceInvoke = new RunspaceInvoke(runSpace);

            runspaceInvoke.Invoke("Set-ExecutionPolicy -Scope Process Unrestricted");

            psPipeline.Runspace = runSpace;


            string str = "";

            psPipeline.AddScript(@"C:\Users\browninfosecguy\Documents\GitHub\PowerShell-CSharp\ASPPowerShell\ASPPowerShell\myScript.ps1");

            var results = psPipeline.Invoke();

            //if(results.Count > 0)
            //{
            //    foreach(var obj in results)
            //    {
            //        str += obj.Members["name"].Value;
            //        str += "\r\n";
            //    }
            //}

            if(DropDownList1.SelectedValue == "1")
            {
                foreach (var obj in results)
                {
                    str += obj.ToString();
                    str += "\r\n";
                }
                TextBox1.Text = str;
            }
            else if(DropDownList1.SelectedValue == "2")
            {
                DataTable dt = new DataTable("Process Information");

                DataColumn processName = new DataColumn("Process Name");
                processName.DataType = System.Type.GetType("System.String");

                DataColumn processId = new DataColumn("Process Id");
                processId.DataType = System.Type.GetType("System.String");

                DataColumn processPath = new DataColumn("Process Path");
                processPath.DataType = System.Type.GetType("System.String");

                dt.Columns.Add(processName);
                dt.Columns.Add(processId);
                dt.Columns.Add(processPath);

                

                if (results.Count > 0)
                {
                    foreach (var obj in results)
                    {
                        DataRow newRow = dt.NewRow();

                        
                            newRow["Process Name"] = obj.Properties["name"].Value;
                            newRow["Process Id"] = obj.Properties["id"].Value;
                            newRow["Process Path"] = obj.Properties["Path"].Value;

                            dt.Rows.Add(newRow);
                        
                    }
                }

                GridView1.DataSource = dt;
                GridView1.DataBind();

                
            }

        }
    }
}