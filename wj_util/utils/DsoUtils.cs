//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using Microsoft.Win32;
//using System.Management;  

//namespace wj_util.utils
//{
//    class DsoUtils
//    {
//        static void Main(string[] args)
//        {
//            string fileFullPath = string.Format("{0}\\dsoframer.ocx", System.Environment.CurrentDirectory);
//            string systemDrive = System.Environment.GetEnvironmentVariable("systemdrive");//获取系统所在的盘符  
//            if (!File.Exists(fileFullPath) || String.IsNullOrEmpty(systemDrive))
//                return;

//            bool isRegisted = IsRegistered("00460182-9E5E-11D5-B7C8-B8269041DD57");
//            if (isRegisted)
//                return;


//            string windowsPath = string.Empty;

//            if (GetOSBitCount() == "64")
//                windowsPath = string.Format("{0}\\Windows\\SysWOW64", systemDrive);
//            else
//                windowsPath = string.Format("{0}\\Windows\\System32", systemDrive);

//            if (!Directory.Exists(windowsPath))
//                return;


//            File.Copy(fileFullPath, string.Format("{0}\\dsoframer.ocx", windowsPath), true);

//            Registe(string.Format("{0}\\dsoframer.ocx", windowsPath));

//        }

//        //注册dsoframer.ocx  
//        private static bool Registe(string fileFullName)
//        {
//            bool result = false;
//            System.Diagnostics.Process p = System.Diagnostics.Process.Start("regsvr32", fileFullName + " /s");//注册完毕不显示是否成功的提示  
//            //System.Diagnostics.Process p = System.Diagnostics.Process.Start("regsvr32", fileFullName);//注册完毕显示是否成功的提示  
//            if (p != null && p.HasExited)
//            {
//                Int32 exitCode = p.ExitCode;
//                if (exitCode == 0)
//                    result = true;
//            }
//            return result;
//        }

//        //获取当前操作系统的位数  
//        private static string GetOSBitCount()
//        {
//            ConnectionOptions oConn = new ConnectionOptions();
//            System.Management.ManagementScope oMs = new System.Management.ManagementScope("\\\\localhost", oConn);
//            System.Management.ObjectQuery oQuery = new System.Management.ObjectQuery("select AddressWidth from Win32_Processor");
//            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
//            ManagementObjectCollection oReturnCollection = oSearcher.Get();
//            string addressWidth = null;

//            foreach (ManagementObject oReturn in oReturnCollection)
//                addressWidth = oReturn["AddressWidth"].ToString();

//            return addressWidth;
//        }

//        //判断控件是否已经注册  
//        private static bool IsRegistered(String CLSID)
//        {
//            if (String.IsNullOrEmpty(CLSID))
//                return false;

//            String key = String.Format(@"CLSID\{{{0}}}", CLSID);
//            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(key);
//            if (regKey != null)
//                return true;
//            else
//                return false;
//        }  
//    }
//}
