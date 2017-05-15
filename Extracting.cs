using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Flatout3_MusicTool
{
    public partial class Extracting : Form
    {
        private Paths paths;
        int game = 0;
        private OSTDictionary.OSTs ost;
        private bool cleanUp;
        int value = 0;

        public Extracting(Paths paths, int game, OSTDictionary.OSTs ost, bool cleanUp)
        {
            InitializeComponent();
            this.paths = paths;
            this.game = game;
            this.ost = ost;
            this.cleanUp = cleanUp;
            this.TopMost = true;

            if (game == 0)
                extractFlatout1();
            else
                extractFlatout2();
        }

        private void invokeSetProgressBar(int value)
        {
            if (progressBar1.InvokeRequired)
                progressBar1.Invoke(new Action<int>(invokeSetProgressBar), value);
            else
                progressBar1.Value = value;
        }

        private void invokeFromClose()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(invokeFromClose));
            else
                this.Close();
        }

        #region Flatout1
        private void extractFlatout1()
        {
            if (paths.Flatout1Found && paths.Flatout3Found)
            {
                Process extractionProcess = new Process();
                extractionProcess.StartInfo.WorkingDirectory = Path.Combine(paths.SelfLocation, "Extractors");
                extractionProcess.StartInfo.FileName = Path.Combine(paths.SelfLocation, "Extractors", "bfsunpack.exe");
                extractionProcess.StartInfo.Arguments = "\"" + Path.Combine(paths.Flatout1Location, "common1.bfs") + "\"";
                extractionProcess.Exited += ExtractionProcessFlatout1_Exited;
                extractionProcess.EnableRaisingEvents = true;
                extractionProcess.Start();
            }
        }

        private void ExtractionProcessFlatout1_Exited(object sender, EventArgs e)
        {
            value = 70;
            invokeSetProgressBar(value);
            if (!Directory.Exists(Path.Combine(paths.Flatout3Location, "data", "music", "flatout1")))
                Directory.CreateDirectory(Path.Combine(paths.Flatout3Location, "data", "music", "flatout1"));

            foreach(string file in ost.Flatout1.Keys)
            {
                string filePath = Path.Combine(paths.SelfLocation, "Extractors", "data", "music", file);
                if (File.Exists(filePath))
                {
                    File.Copy(filePath, Path.Combine(paths.Flatout3Location, "data", "music", "flatout1", file), true);
                    value++;
                    invokeSetProgressBar(value);
                }
            }

            if (cleanUp)
                DoCleanUp();

            this.invokeFromClose();
        }
        #endregion

        private void DoCleanUp()
        {
            string[] files = Directory.GetFiles(Path.Combine(paths.SelfLocation, "Extractors", "data"), "*.*", SearchOption.AllDirectories);
            foreach(string file in files)
            {
                File.Delete(file);
            }

            Directory.Delete(Path.Combine(paths.SelfLocation, "Extractors", "data"), true);
        }

        private void extractFlatout2()
        {
            if(paths.Flatout2Found && paths.Flatout3Found)
            {
                Process extractionProcess = new Process();
                extractionProcess.StartInfo.WorkingDirectory = Path.Combine(paths.SelfLocation, "Extractors");
                extractionProcess.StartInfo.FileName = Path.Combine(paths.SelfLocation, "Extractors", "BFS3pack_smart_con.exe");
                extractionProcess.StartInfo.Arguments = "x -v -2 " + "\"" +Path.Combine(paths.Flatout2Location, "fo2a.bfs") + "\"";
                extractionProcess.Exited += ExtractionProcessFlatout2_Exited;
                extractionProcess.EnableRaisingEvents = true;
                extractionProcess.Start();
            }

        }

        private void ExtractionProcessFlatout2_Exited(object sender, EventArgs e)
        {
            value = 75;
            invokeSetProgressBar(value);
            if (!Directory.Exists(Path.Combine(paths.Flatout3Location, "data", "music", "flatout2")))
                Directory.CreateDirectory(Path.Combine(paths.Flatout3Location, "data", "music", "flatout2"));

            copySongsToOneDirectory();
            foreach (string file in ost.Flatout2.Keys)
            {
                string filePath = Path.Combine(paths.SelfLocation, "Extractors", "data", "songs1", file);
                if (File.Exists(filePath))
                {
                    File.Copy(filePath, Path.Combine(paths.Flatout3Location, "data", "music", "flatout2", file), true);
                }
            }
            value = 95;
            invokeSetProgressBar(value);

            if (cleanUp)
                DoCleanUp();

            this.invokeFromClose();
        }

        private void copySongsToOneDirectory()
        {
            if (Directory.Exists(Path.Combine(paths.SelfLocation, "Extractors", "data", "songs2")))
            {
                string[] files = Directory.GetFiles(Path.Combine(paths.SelfLocation, "Extractors", "data", "songs2"));
                foreach (string file in files)
                {
                    string[] parts = file.Split(new char[] { '\\', '/' });
                    string fileName = parts.Last();
                    File.Move(file, Path.Combine(Path.Combine(paths.SelfLocation, "Extractors", "data", "songs1", fileName)));
                }
            }

        }
    }
}
