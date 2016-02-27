using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Text.RegularExpressions;



namespace unPacker
{
    
    class Controller
    {
        public UPMainWindow Main;
        DataHandler dataHandler = new DataHandler();
        private delegate void UpdateTextBox();
        List<String> getFileList(string path)
        {
            UpdateTextBox updateTextBox = () => Main.statusTxtBlock.Text = "Filtering Files";
            Main.Dispatcher.Invoke(updateTextBox, DispatcherPriority.Render);
            List<String> files = new List<String>();
            foreach (string f in Directory.GetFiles(path))
            {
                
                if (Path.GetExtension(f) == ".rar")
                {
                    if (f.ToLower().Contains("part") && f.ToLower().Contains("part001"))
                        files.Add(f);
                    else
                        files.Add(f);
                }
            }
            foreach (string d in Directory.GetDirectories(path))
                files.AddRange(getFileList(d));
            return files;
        }
        public Controller()
        {

        }

        

        public void StartUnpacking(string path, string destinationPath)
        {
            int count = getFileList(path).Count();
            int i = 0;
            foreach (string file in getFileList(path))
            {
                i++;
                Main.statusTxtBlock.Text = "unPacking File: " + i.ToString() + " Out of " + count.ToString();
                unPack(file, destinationPath);
                
            }
            Main.statusTxtBlock.Text = "Done! unpacked " + i.ToString() + " Out of " + count.ToString() + " Files";

        }
        public void unPack(string srcPath, string destPath)
        {
            string app = dataHandler.Default7zLocation;
            string parms = " e -y " + "\"" + srcPath + "\" -o\"" + destPath + "\"";
            ProcessStartInfo pProcess = new ProcessStartInfo(app, parms);
            pProcess.RedirectStandardOutput = true;
            pProcess.RedirectStandardError = true;
            pProcess.CreateNoWindow = true;
            pProcess.UseShellExecute = false;
            string strOutput = "";
            Process reg = Process.Start(pProcess);
            strOutput = reg.StandardOutput.ReadToEnd();
            strOutput = strOutput.Replace("Processing archive: "+ srcPath, "");
            strOutput = strOutput.Replace("Everything is Ok", "");
            strOutput = Regex.Replace(strOutput, @"^\s*$[\r\n]*", "", RegexOptions.Multiline);

            if (!String.IsNullOrEmpty(strOutput))
                OutputToTextBox(strOutput);
           
            reg.WaitForExit();

        }
        
        void OutputToTextBox(string msg)
        {
            Main.Dispatcher.Invoke(new Action(() => Main.unPackOutput.AppendText(msg + Environment.NewLine)), DispatcherPriority.Render);
            Main.unPackOutput.ScrollToEnd();
            
        }

    }
}
