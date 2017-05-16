using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace Flatout3_MusicTool
{
    public enum GameEnum
    {
        Flatout1,
        Flatout2,
        FlatoutUC
    }

    public class Paths
    {
        public bool Flatout1Found = false;
        public bool Flatout2Found = false;
        public bool Flatout3Found = false;
        public bool Flatout1OSTExtracted = false;
        public bool Flatout2OSTExtracted = false;
        public bool Flatout3OSTExtracted = false;

        public string SelfLocation { get; set; }
        public string Flatout1Location { get; set; }
        public string Flatout2Location { get; set; }
        public string Flatout3Location { get; set; }

        private string SteamLocation = "";

        public Paths(OSTDictionary.OSTs ost)
        {
            SelfLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            SteamLocation = getSteamLocation();
            if(SteamLocation != "")
            {
                Flatout1Found = checkFlatout1Location();
                Flatout2Found = checkFlatout2Location();
                Flatout3Found = checkFlatout3Location();
            }

            checkExtractedFiles(ost);
        }

        private void checkExtractedFiles(OSTDictionary.OSTs ost)
        {
            if (Flatout3Found)
            {
                Flatout1OSTExtracted = checkIfExists(ost.Flatout1List);
                Flatout2OSTExtracted = checkIfExists(ost.Flatout2List);
                Flatout3OSTExtracted = checkIfExists(ost.Flatout3List);
            }
            else
            {
                Flatout1OSTExtracted = false;
                Flatout2OSTExtracted = false;
                Flatout3OSTExtracted = false;
            }
        }

        public void setFlatoutLocation(GameEnum game, OSTDictionary.OSTs ost)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            DialogResult result = fbd.ShowDialog();

            if(result == DialogResult.OK)
            {
                string directory = fbd.SelectedPath;

                if(game == GameEnum.Flatout1)
                    Flatout1Found = checkFlatout1Location(directory);
                else if (game == GameEnum.Flatout2)
                    Flatout2Found = checkFlatout2Location(directory);
                else if (game == GameEnum.FlatoutUC)
                    Flatout3Found = checkFlatout3Location(directory);

                checkExtractedFiles(ost);
            }
        }

        #region LocationChecks
        private bool checkFlatout1Location(string setPath = "")
        {
            string tempLocation = "";
            if (setPath == "")
                tempLocation = Path.Combine(SteamLocation, "FlatOut");
            else
                tempLocation = setPath;

            if (File.Exists(Path.Combine(tempLocation, "flatout.exe"))
                && File.Exists(Path.Combine(tempLocation, "common1.bfs")))
            {
                Flatout1Location = tempLocation;
                return true;
            }
            else
            {
                Flatout1Location = "";
                return false;
            }
        }


        private bool checkFlatout2Location(string setPath = "")
        {
            string tempLocation = "";
            if (setPath == "")
                tempLocation = Path.Combine(SteamLocation, "FlatOut2");
            else
                tempLocation = setPath;

            if (File.Exists(Path.Combine(tempLocation, "FlatOut2.exe"))
                && File.Exists(Path.Combine(tempLocation, "fo2a.bfs")))
            {
                Flatout2Location = tempLocation;
                return true;
            }
            else
            {
                Flatout2Location = "";
                return false;
            }

        }

        private bool checkFlatout3Location(string setPath = "")
        {
            string tempLocation = "";

            if (setPath == "")
                tempLocation = Path.Combine(SteamLocation, "FlatOut Ultimate Carnage");
            else
                tempLocation = setPath;

            if (File.Exists(Path.Combine(tempLocation, "Fouc.exe"))
                && File.Exists(Path.Combine(tempLocation, "data.bfs")))
            {
                Flatout3Location = tempLocation;
                return true;
            }
            else
            {
                Flatout3Location = "";
                return false;
            }
        }
        #endregion

        private bool checkIfExists(List<string> paths)
        {
            foreach(string path in paths)
            {
                if (!File.Exists(Path.Combine(Flatout3Location, path)))
                {
                    Debug.WriteLine(path + " doesn't exist!");
                    return false;
                }
            }
            return true;
        }

        private string getSteamLocation()
        {
            try
            {
                RegistryKey whatever = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam");
                string wat = Path.GetDirectoryName(whatever.GetValue("UninstallString").ToString());
                return Path.Combine(wat, "steamapps", "common");
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return "";
            }
        }
    }
}
