using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.AddIn;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Security;

namespace MyUserPlugins
{
    [AddIn("MyFirstPlugSample")]
    public class MySample
    {
        //string theSecureString = null;
        //string theString = new NetworkCredential("", theSecureString).Password;

        //public static string Hello()
        //{
        //    return "Hai i am Your First sample";
        //}

        //public static int Manipulation(int a,int b,string operation)
        //{
        //    try
        //    {
        //        if (operation == "ADD")
        //            return a + b;
        //        else if (operation == "SUB")
        //            return a - b;
        //        else if (operation == "MUL")
        //            return a * b;
        //        return 0;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }          
        //}

        //public static Array DOTNETFramework()
        //{
        //    try
        //    {
        //        string filepath = null;
        //        string[] vs = new string[135];
        //        if (Environment.Is64BitOperatingSystem)
        //        {
        //            filepath = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.1";
        //        }
        //        else
        //        {
        //            filepath = @"C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5";
        //        }
        //        DirectoryInfo di = new DirectoryInfo(filepath);
        //        FileInfo[] files = di.GetFiles("*.dll");

        //        if (files != null && files.Length > 0)
        //            return files;
        //        else
        //            return null;

        //    }
        //    catch (Exception Ex)
        //    {
        //        throw new Exception(Ex.Message);
        //    }
           
        //}

        public static void LaunchRemoteDesktop(string Username, string IPAddress, string Password)
        {

            try
            {
                Process rdcProcess = new Process();
                rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
                //rdcProcess.StartInfo.Arguments = "/generic:TERMSRV/192.168.1.155 /user:" + Username + " /pass:" + Password;
                rdcProcess.StartInfo.Arguments = "/generic:TERMSRV/"+IPAddress+ "/user:" + Username + " /pass:" + Password;
                rdcProcess.Start();

                rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
                rdcProcess.StartInfo.Arguments = "/v " + IPAddress; 
                rdcProcess.Start();

            }
            catch (Exception)
            {
                throw;
            }
            #region
            //Process rdcProcess = new Process();
            //rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
            //rdcProcess.StartInfo.Arguments = "/generic:TERMSRV/192.168.1.127 /user:" + "karthik" + " /pass:" + "utl@123";
            //rdcProcess.Start();

            //rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            //rdcProcess.StartInfo.Arguments = "/v " + "192.168.1.125"; // ip or name of computer to connect
            //rdcProcess.Start();

            //try
            //{
            //    Process rdcProcess = new Process();
            //    string cmdexecutable = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
            //    string mstcexecutable = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            //    if (mstcexecutable != null)
            //    {
            //        rdcProcess.StartInfo.FileName = cmdexecutable;//Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
            //        //cmdkey / generic:DOMAIN / "computername or IP" / user:"username" / pass:"password"
            //        rdcProcess.StartInfo.Arguments = "/generic:"+ DomainName + "/user:" + Username + " /pass:" + Password;
            //        //rdcProcess.StartInfo.Arguments = "generic:DOMAIN /" + Username+ "/user:"+ Username + "/pass:" + Password;
            //        rdcProcess.Start();


            //        rdcProcess.StartInfo.FileName = mstcexecutable;//Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            //        rdcProcess.StartInfo.Arguments = "/v " + IPAddress; // ip or name of computer to connect
            //        rdcProcess.Start();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //String szCmd = "/c cmdkey.exe /generic:ip /user:Karthik /pass:utl@123 & mstsc.exe /v ip";
            //ProcessStartInfo info = new ProcessStartInfo("cmd.exe", szCmd);
            //Process proc = new Process();
            //proc.StartInfo = info;
            //proc.Start();
            //try
            //{
            //    Process rdcProcess = new Process();
            //    string executable = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            //    if (executable != null)
            //    {
            //        rdcProcess.StartInfo.UseShellExecute = false;
            //        rdcProcess.StartInfo.FileName = executable;
            //        rdcProcess.StartInfo.Arguments = "/v " + IPAddress; // ip or name of computer to connect
            //        //SecureString theSecureString = new NetworkCredential("", Password).SecurePassword;
            //        //rdcProcess.StartInfo.Password = theSecureString;
            //        rdcProcess.Start();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}         
            #endregion
        }

        public static void DisconnectRemoteDesktop()
        {
            try
            {
                Process[] my = Process.GetProcessesByName("mstsc");
                if(my !=null && my.Length > 0)
                {
                    int pid = my[0].Id;
                    Process pro = Process.GetProcessById(pid);
                    pro.Kill();
                }               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
