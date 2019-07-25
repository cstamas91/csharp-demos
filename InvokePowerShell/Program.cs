using System;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace InvokePowerShell
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var runSpace = RunspaceFactory.CreateRunspace())
            {
                runSpace.Open();
                runSpace.SessionStateProxy.Path.SetLocation(@"C:\Temp");
                using (var powerShell = PowerShell.Create())
                {
                    powerShell.Runspace = runSpace;
                    powerShell.AddScript("Get-ChildItem;Get-ChildItem");

                    try
                    {
                        var powerShellExecutionResult = powerShell.Invoke();
                        foreach (var psObject in powerShellExecutionResult)
                        {
                            Console.WriteLine(psObject.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
