using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace unPacker
{
    class DataHandler
    {
        string path = "Settings.Cfg";
        string default7zLocation = "";
        string defaultUnpackDir = "";
        string defaultUnpackOutputDir = "";
        public DataHandler()
        {
            if (!File.Exists(path))
                using (StreamWriter sw = File.CreateText(path)) ;
            loadSettingsFromFile();
            
        }
        
        public string Path
        {
            get{ return path; }
            set{ path = value; }
        }
        public string Default7zLocation
        {
            get{ return default7zLocation; }
            set{ default7zLocation = value; }
        }
        public string DefaultUnpackDir
        {
            get{ return defaultUnpackDir; }
            set{ defaultUnpackDir = value; }
        }
        public string DefaultUnpackOutputDir
        {
            get { return defaultUnpackOutputDir; }
            set { defaultUnpackOutputDir = value; }
        }
        void loadSettingsFromFile()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while(sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    if (line.Contains("7z File Location="))
                        default7zLocation = line.Replace("7z File Location=", "");
                    else if (line.Contains("Default Unpack Dir="))
                        defaultUnpackDir = line.Replace("Default Unpack Dir=", "");
                    else if (line.Contains("Default Unpack Output Dir="))
                        defaultUnpackOutputDir = line.Replace("Default Unpack Output Dir=", "");
                }
            }
        }
        public void writeSettingsToFile(List<string> settingsList)
        {
            string path = "Settings.Cfg";
            
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach(string line in settingsList)
                {
                    sw.WriteLine(line);
                }
            }
                
        }
    }
}
