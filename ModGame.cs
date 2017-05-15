using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Flatout3_MusicTool
{
    class ModGame
    {
        private Paths paths;
        private OSTDictionary.OSTs ost;
        public string ModError = "";

        public ModGame(Paths paths, OSTDictionary.OSTs ostRef)
        {
            this.paths = paths;
            this.ost = ostRef;
        }

        internal bool doWork()
        {
            if (!paths.Flatout3Found)
            {
                ModError = "Flatout Ultimate Carnage was not found!";
                return false;
            }

            //Menu
            try
            {
                List<string> output = new List<string>();

                output.Add("Loop = {");
                output.Add("\tCount = 1,");
                int i = 0;
                foreach (var element in ost.UserPicksMenu)
                {
                    string relativePath = ost.getRelativeFilePath(element.song, element.artist);
                    if (relativePath.EndsWith(".ogg"))
                    {
                        i++;
                        output.Add("\t[" + i.ToString() + "] = {");
                        output.Add("\t\tFile = \"" + relativePath + "\",");
                        output.Add("\t\tArtist = \"" + element.artist + "\",");
                        output.Add("\t\tSong = \"" + element.song + "\",");
                        output.Add("\t\tStartPos = 0,");
                        output.Add("\t},");
                    }
                }
                output.Add("}");
                output[1] = "\tCount = " + i.ToString() + ",";

                if (!Directory.Exists(Path.Combine("tmp", "data", "music", "playlist_title.bed")))
                    Directory.CreateDirectory(Path.Combine("tmp", "data", "music"));

                File.WriteAllLines(Path.Combine("tmp", "data", "music", "playlist_title.bed"), output.ToArray());
            }
            catch(Exception e)
            {
                ModError = "Exception error: " + e;
                return false;
            }

            //Race
            try
            {
                List<string> output = new List<string>();

                output.Add("Loop = {");
                output.Add("\tCount = 1,");
                int i = 0;
                foreach (var element in ost.UserPicksRace)
                {
                    string relativePath = ost.getRelativeFilePath(element.song, element.artist);
                    if (relativePath.EndsWith(".ogg"))
                    {
                        i++;
                        output.Add("\t[" + i.ToString() + "] = {");
                        output.Add("\t\tFile = \"" + relativePath + "\",");
                        output.Add("\t\tArtist = \"" + element.artist + "\",");
                        output.Add("\t\tSong = \"" + element.song + "\",");
                        output.Add("\t\tStartPos = 0,");
                        output.Add("\t},");
                    }
                }
                output.Add("}");
                output[1] = "\tCount = " + i.ToString() + ",";

                File.WriteAllLines(Path.Combine("tmp", "data", "music", "playlist_ingame.bed"), output.ToArray());
            }
            catch (Exception e)
            {
                ModError = "Exception error: " + e;
                return false;
            }

            //Stunt
            try
            {
                List<string> output = new List<string>();

                output.Add("Loop = {");
                output.Add("\tCount = 1,");
                int i = 0;
                foreach (var element in ost.UserPicksStunt)
                {
                    string relativePath = ost.getRelativeFilePath(element.song, element.artist);
                    if (relativePath.EndsWith(".ogg"))
                    {
                        i++;
                        output.Add("\t[" + i.ToString() + "] = {");
                        output.Add("\t\tFile = \"" + relativePath + "\",");
                        output.Add("\t\tArtist = \"" + element.artist + "\",");
                        output.Add("\t\tSong = \"" + element.song + "\",");
                        output.Add("\t\tStartPos = 0,");
                        output.Add("\t},");
                    }
                }
                output.Add("}");
                output[1] = "\tCount = " + i.ToString() + ",";                

                File.WriteAllLines(Path.Combine("tmp", "data", "music", "playlist_stunt.bed"), output.ToArray());
            }
            catch (Exception e)
            {
                ModError = "Exception error: " + e;
                return false;
            }

            Process packer = new Process();
            packer.StartInfo.WorkingDirectory = Path.Combine(paths.SelfLocation, "tmp");
            packer.StartInfo.FileName = Path.Combine(paths.SelfLocation, "Extractors", "BFS3pack_smart_con.exe");
            packer.StartInfo.Arguments = "a -v -U ost_mod.bfs data";
            packer.Start();
            packer.WaitForExit();

            if (!File.Exists(Path.Combine(paths.SelfLocation, "tmp", "ost_mod.bfs")))
            {
                ModError = "Failed to create bfs file";
                return false;
            }

            File.Copy(Path.Combine(paths.SelfLocation, "tmp", "ost_mod.bfs"), Path.Combine(paths.Flatout3Location, "ost_mod.bfs"), true);

            string[] readLines = File.ReadAllLines(Path.Combine(paths.Flatout3Location, "filesystem"));
            if(!readLines.Contains("ost_mod.bfs"))
            {
                string output = string.Join("\n", readLines);
                output += "\nost_mod.bfs";
                //This has to be saved via WriteAllText or StreamWritter, because WriteAllLines adds additional line to the end of a file
                File.WriteAllText(Path.Combine(paths.Flatout3Location, "filesystem"), output);
            }

            return true;
        }
    }
}
