using DWord.Model;
using DWord.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DWord
{
    public class Helper
    {
        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = ""; 
            logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("yyyy-MM-dd") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            strLog += "\r\n";
            log.WriteLine(strLog);
            log.Close();
        }
        public static char[] CharFromString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return new char[1];
            return ASCIIEncoding.ASCII.GetChars(ASCIIEncoding.ASCII.GetBytes(str));
        }
        public static DateTime StringToDate(string str)
        {
            int year = int.Parse(str.Substring(0, 4));
            int month = int.Parse(str.Substring(4, 2));
            int day = int.Parse(str.Substring(6, 2));
            int hour = int.Parse(str.Substring(8, 2));
            int min = int.Parse(str.Substring(10, 2));
            return new DateTime(year, month, day, hour, min, 0);
        }
        public static string CharToString(char[] arr)
        {
            string str = new string(arr);
            int pos = str.IndexOf('\0');
            if (pos >= 0)
                str = str.Substring(0, pos);
            return str;
        }
    }
}
