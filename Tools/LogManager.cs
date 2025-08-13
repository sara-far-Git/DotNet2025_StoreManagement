using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Tools
{
    public static class LogManager
    {
        private readonly static string start = "Log";
        public static DirectoryInfo directory = new DirectoryInfo(start);
        public static DateTime creationTime = directory.CreationTime;

        public static string DirCurrent()///////////////////////לבדיקה
        {
            string fullName = directory.FullName;
            return fullName;
        }
        public static string DirCurrentFile()/////////////////////לבדיקה
        {
            FileInfo file = new FileInfo("LogManager");
            string fullPath = file.FullName;
            return fullPath;
        }
        public static string GetPathDir()
        {
            return start + "/" + DateTime.Now.Month.ToString();
        }
        public static string GetPathFile()
        {
            return GetPathDir() + "/" + DateTime.Now.Day.ToString() + "txt";
        }

        public static void WriteToLog(string nameOfProject, string nameOfFunc, string message)
        {
            if (creationTime.Month < DateTime.Now.Month)
            {
                string str = GetPathDir();
                DirectoryInfo Dir = Directory.CreateDirectory(str);
                File.Create(GetPathFile());
            }
            else if (creationTime.Day > DateTime.Now.Day)
            {
                File.Create(GetPathFile());
            }
            using (StreamWriter writeText = new StreamWriter(DirCurrentFile(), true))
            {
                writeText.WriteLine($"{DateTime.Now}\t{nameOfProject}.{nameOfFunc}:\t{message}");
            }
        }
        public static void DeleteFile()
        {
            DirectoryInfo parent = Directory.GetParent("Log");
            DirectoryInfo[] subDirectories = parent.GetDirectories();
            string getPathDir = GetPathDir();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                DateTime creationTImee = subDirectory.CreationTime;
                if (DateTime.Now.Month==1)
                {
                    if(subDirectory.CreationTime.Month<10)
                        subDirectory.Delete(true);
                }
                else if(subDirectory.CreationTime.Month < DateTime.Now.Month-2)
                    subDirectory.Delete(true);
            }
        }
    }
}
