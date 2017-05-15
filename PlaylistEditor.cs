using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSTDictionary;
using System.Diagnostics;
using System.IO;

namespace Flatout3_MusicTool
{
    public partial class PlaylistEditor : Form
    {
        private const string saveFile = "last_selection.txt";
        private OSTs ost;
        private Paths paths;


        public PlaylistEditor(Paths paths, OSTs ost)
        {
            InitializeComponent();
            this.paths = paths;
            this.ost = ost;

            fillWithSongs();
            if(File.Exists(saveFile))
            {
                loadSelectionFromFile();
            }
        }

        private void loadSelectionFromFile()
        {
            readTypeEnum typeReading = readTypeEnum.MenuMusic;
            string[] lines = File.ReadAllLines(saveFile);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line == "==MENU==") typeReading = readTypeEnum.MenuMusic;
                else if (line == "==RACE==") typeReading = readTypeEnum.RaceMusic;
                else if (line == "==STUNT==") typeReading = readTypeEnum.StuntMusic;
                else
                {
                    string artist = line.Split('|')[0];
                    string song = line.Split('|')[1];

                    if (typeReading == readTypeEnum.MenuMusic)
                        setTableCBByArtistTitle(MenuTable.Controls, artist, song);
                    else if (typeReading == readTypeEnum.RaceMusic)
                        setTableCBByArtistTitle(RaceTable.Controls, artist, song);
                    else if(typeReading == readTypeEnum.StuntMusic)
                        setTableCBByArtistTitle(StuntTable.Controls, artist, song);
                }
            }
        }

        private void setTableCBByArtistTitle(TableLayoutControlCollection TableControls, string artist, string song)
        {
            for(int i=1; i<TableControls.Container.RowCount; i++)
            {
                string tArtist = ((Label)TableControls.Container.GetControlFromPosition(2, i)).Text;
                string tSong = ((Label)TableControls.Container.GetControlFromPosition(3, i)).Text;
                if(tArtist == artist && tSong == song)
                {
                    ((CheckBox)TableControls.Container.GetControlFromPosition(0, i)).Checked = true;
                    return;
                }
            }
        }

        private void fillWithSongs()
        {
            var menuCollection = MenuTable.Controls;
            var raceCollection = RaceTable.Controls;
            var stuntCollection = StuntTable.Controls;
            menuCollection.Container.RowCount = 1;
            raceCollection.Container.RowCount = 1;
            stuntCollection.Container.RowCount = 1;

            if (paths.Flatout1OSTExtracted)
            {
                foreach (var element in ost.Flatout1)
                {
                    menuCollection.Add(new CheckBox() { Text = "" });
                    menuCollection.Add(new Label() { Text = "1" });
                    menuCollection.Add(new Label() { Text = element.Value.artist });
                    menuCollection.Add(new Label() { Text = element.Value.song });
                    menuCollection.Container.RowCount++;

                    raceCollection.Add(new CheckBox() { Text = "" });
                    raceCollection.Add(new Label() { Text = "1" });
                    raceCollection.Add(new Label() { Text = element.Value.artist });
                    raceCollection.Add(new Label() { Text = element.Value.song });
                    raceCollection.Container.RowCount++;

                    stuntCollection.Add(new CheckBox() { Text = "" });
                    stuntCollection.Add(new Label() { Text = "1" });
                    stuntCollection.Add(new Label() { Text = element.Value.artist });
                    stuntCollection.Add(new Label() { Text = element.Value.song });
                    stuntCollection.Container.RowCount++;
                }
            }

            if(paths.Flatout2OSTExtracted)
            {
                foreach (var element in ost.Flatout2)
                {
                    menuCollection.Add(new CheckBox() { Text = "" });
                    menuCollection.Add(new Label() { Text = "2" });
                    menuCollection.Add(new Label() { Text = element.Value.artist });
                    menuCollection.Add(new Label() { Text = element.Value.song });
                    menuCollection.Container.RowCount++;

                    raceCollection.Add(new CheckBox() { Text = "" });
                    raceCollection.Add(new Label() { Text = "2" });
                    raceCollection.Add(new Label() { Text = element.Value.artist });
                    raceCollection.Add(new Label() { Text = element.Value.song });
                    raceCollection.Container.RowCount++;

                    stuntCollection.Add(new CheckBox() { Text = "" });
                    stuntCollection.Add(new Label() { Text = "2" });
                    stuntCollection.Add(new Label() { Text = element.Value.artist });
                    stuntCollection.Add(new Label() { Text = element.Value.song });
                    stuntCollection.Container.RowCount++;
                }
            }

            foreach (var element in ost.Flatout3)
            {
                menuCollection.Add(new CheckBox() { Text = "" });
                menuCollection.Add(new Label() { Text = "UC" });
                menuCollection.Add(new Label() { Text = element.Value.artist });
                menuCollection.Add(new Label() { Text = element.Value.song });
                menuCollection.Container.RowCount++;

                raceCollection.Add(new CheckBox() { Text = "" });
                raceCollection.Add(new Label() { Text = "UC" });
                raceCollection.Add(new Label() { Text = element.Value.artist });
                raceCollection.Add(new Label() { Text = element.Value.song });
                raceCollection.Container.RowCount++;

                stuntCollection.Add(new CheckBox() { Text = "" });
                stuntCollection.Add(new Label() { Text = "UC" });
                stuntCollection.Add(new Label() { Text = element.Value.artist });
                stuntCollection.Add(new Label() { Text = element.Value.song });
                stuntCollection.Container.RowCount++;
            }
        }

        private void B_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            savePlaylists();
            this.Close();
        }

        private void savePlaylists()
        {
            ost.UserPicksMenu.Clear();
            ost.UserPicksRace.Clear();
            ost.UserPicksStunt.Clear();

            var menuCollection = MenuTable.Controls;
            var raceCollection = RaceTable.Controls;
            var stuntCollection = StuntTable.Controls;

            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.AppendLine("==MENU==");
            for(int i=1; i<menuCollection.Container.RowCount; i++)
            {
                bool elementChecked = ((CheckBox)menuCollection.Container.GetControlFromPosition(0, i)).Checked;
                if(elementChecked)
                {
                    string artist = ((Label)menuCollection.Container.GetControlFromPosition(2, i)).Text;
                    string song = ((Label)menuCollection.Container.GetControlFromPosition(3, i)).Text;

                    if (song.Contains('|'))
                        song = song.Replace('|', '-');

                    if (artist.Contains('|'))
                        artist = artist.Replace('|', '-');

                    ost.UserPicksMenu.Add(new OSTDictionary.FileInfo(artist, song));
                    sb.AppendLine(artist + "|" + song);
                }
            }

            sb.AppendLine("==RACE==");
            for (int i = 1; i < raceCollection.Container.RowCount; i++)
            {
                bool elementChecked = ((CheckBox)raceCollection.Container.GetControlFromPosition(0, i)).Checked;
                if (elementChecked)
                {
                    string artist = ((Label)raceCollection.Container.GetControlFromPosition(2, i)).Text;
                    string song = ((Label)raceCollection.Container.GetControlFromPosition(3, i)).Text;

                    if (song.Contains('|'))
                        song = song.Replace('|', '-');

                    if (artist.Contains('|'))
                        artist = artist.Replace('|', '-');

                    ost.UserPicksRace.Add(new OSTDictionary.FileInfo(artist, song));
                    sb.AppendLine(artist + "|" + song);
                }
            }
            sb.AppendLine("==STUNT==");
            for (int i = 1; i < stuntCollection.Container.RowCount; i++)
            {
                bool elementChecked = ((CheckBox)stuntCollection.Container.GetControlFromPosition(0, i)).Checked;
                if (elementChecked)
                {
                    string artist = ((Label)stuntCollection.Container.GetControlFromPosition(2, i)).Text;
                    string song = ((Label)stuntCollection.Container.GetControlFromPosition(3, i)).Text;

                    if (song.Contains('|'))
                        song = song.Replace('|', '-');

                    if (artist.Contains('|'))
                        artist = artist.Replace('|', '-');

                    ost.UserPicksStunt.Add(new OSTDictionary.FileInfo(artist, song));
                    sb.AppendLine(artist + "|" + song);
                }
            }
            File.WriteAllText(saveFile, sb.ToString());
        }

        private void B_Preset_Click(object sender, EventArgs e)
        {
            PresetDialogResults result = ShowPresetDialog();
            if (result == PresetDialogResults.Categorized)
                selectTracks(ost.MenuMusic, ost.InGameMusic, ost.InGameMusic);
            else if (result == PresetDialogResults.Sui)
                selectTracks(ost.SuiMenuMusic, ost.SuiInGameMusic, ost.SuiInGameMusic);
            else if (result == PresetDialogResults.All)
                selectTracks(null, null, null);
        }

        private void selectTracks(List<string> MenuSongs, List<string> RaceSongs, List<string> StuntSongs)
        {
            var menuCollection = MenuTable.Controls;
            var raceCollection = RaceTable.Controls;
            var stuntCollection = StuntTable.Controls;

            if (MenuSongs == null || RaceSongs == null || StuntSongs == null)
            {
                for(int i=1; i<menuCollection.Container.RowCount; i++)
                {
                    var game = menuCollection.Container.GetControlFromPosition(1, i);
                    if(game.Text == "UC" || game.Text == "2" || game.Text == "1")
                    {
                        var element = menuCollection.Container.GetControlFromPosition(0, i);
                        ((CheckBox)element).Checked = true;
                    }
                }

                for (int i = 1; i < raceCollection.Container.RowCount; i++)
                {
                    var game = raceCollection.Container.GetControlFromPosition(1, i);
                    if (game.Text == "UC" || game.Text == "2" || game.Text == "1")
                    {
                        var element = raceCollection.Container.GetControlFromPosition(0, i);
                        ((CheckBox)element).Checked = true;
                    }
                }

                for (int i = 1; i < stuntCollection.Container.RowCount; i++)
                {
                    var game = stuntCollection.Container.GetControlFromPosition(1, i);
                    if (game.Text == "UC" || game.Text == "2" || game.Text == "1")
                    {
                        var element = stuntCollection.Container.GetControlFromPosition(0, i);
                        ((CheckBox)element).Checked = true;
                    }
                }
            }
            else
            {
                for (int i = 1; i < menuCollection.Container.RowCount; i++)
                {
                    var game = ((Label)menuCollection.Container.GetControlFromPosition(1, i)).Text;
                    if (game == "UC" || game == "2" || game == "1")
                    {
                        var song = ((Label)menuCollection.Container.GetControlFromPosition(3, i)).Text;
                        var artist = ((Label)menuCollection.Container.GetControlFromPosition(2, i)).Text;
                        var enabled = menuCollection.Container.GetControlFromPosition(0, i);
                        if (game == "UC")
                            ((CheckBox)enabled).Checked = ost.checkIfContains(ost.MenuMusic, ost.Flatout3, "", song, artist);
                        else if(game == "2")
                            ((CheckBox)enabled).Checked = ost.checkIfContains(ost.MenuMusic, ost.Flatout2, "flatout2", song, artist);
                        else if (game == "1")
                            ((CheckBox)enabled).Checked = ost.checkIfContains(ost.MenuMusic, ost.Flatout1, "flatout1", song, artist);
                    }
                }

                for (int i = 1; i < raceCollection.Container.RowCount; i++)
                {
                    var game = ((Label)raceCollection.Container.GetControlFromPosition(1, i)).Text;
                    if (game == "UC" || game == "2" || game == "1")
                    {
                        var song = ((Label)raceCollection.Container.GetControlFromPosition(3, i)).Text;
                        var artist = ((Label)raceCollection.Container.GetControlFromPosition(2, i)).Text;
                        var enabled = raceCollection.Container.GetControlFromPosition(0, i);
                        if (game == "UC")
                            ((CheckBox)enabled).Checked = ost.checkIfContains(ost.InGameMusic, ost.Flatout3, "", song, artist);
                        else if (game == "2")
                            ((CheckBox)enabled).Checked = ost.checkIfContains(ost.InGameMusic, ost.Flatout2, "flatout2", song, artist);
                        else if (game == "1")
                            ((CheckBox)enabled).Checked = ost.checkIfContains(ost.InGameMusic, ost.Flatout1, "flatout1", song, artist);
                    }
                }

                for (int i = 1; i < stuntCollection.Container.RowCount; i++)
                {
                    var game = ((Label)stuntCollection.Container.GetControlFromPosition(1, i)).Text;
                    if (game == "UC" || game == "2" || game == "1")
                    {
                        var song = ((Label)stuntCollection.Container.GetControlFromPosition(3, i)).Text;
                        var artist = ((Label)stuntCollection.Container.GetControlFromPosition(2, i)).Text;
                        var enabled = stuntCollection.Container.GetControlFromPosition(0, i);
                        if (game == "UC")
                            ((CheckBox)enabled).Checked = ost.checkIfContains(ost.InGameMusic, ost.Flatout3, "", song, artist);
                        else if (game == "2")
                            ((CheckBox)enabled).Checked = ost.checkIfContains(ost.InGameMusic, ost.Flatout2, "flatout2", song, artist);
                        else if (game == "1")
                            ((CheckBox)enabled).Checked = ost.checkIfContains(ost.InGameMusic, ost.Flatout1, "flatout1", song, artist);
                    }
                }


            }
        }

        private static PresetDialogResults ShowPresetDialog()
        {
            PresetDialogResults result = PresetDialogResults.None;
            Form prompt = new Form() { Text = "Choose a preset", Width = 234, Height = 170, FormBorderStyle = FormBorderStyle.FixedSingle };
            Label textLabel = new Label() { Left = 5, Top = 2, Width = 200, Text = "Choose a preset:", Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold) };
            RadioButton buttonAll = new RadioButton() { Left = 5, Top = 22, Width = 200, Text = "All songs" };
            RadioButton buttonAllFixed = new RadioButton() { Left = 5, Top = 42, Width = 200, Text = "All songs (categorized)" };
            RadioButton buttonSui = new RadioButton() { Left = 5, Top = 62, Width = 200, Text = "Sui\'s Picks (no annoying sh**)" };
            Button confirmation = new Button() { Text = "Ok", Left = 5, Width = 100, Top = 92 };
            Button cancel = new Button() { Text = "Cancel", Left = 110, Width = 100, Top = 92 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { result = PresetDialogResults.None; prompt.Close(); };
            buttonAll.CheckedChanged += (sender, e) => { if (((RadioButton)sender).Checked) result = PresetDialogResults.All; };
            buttonAllFixed.CheckedChanged += (sender, e) => { if (((RadioButton)sender).Checked) result = PresetDialogResults.Categorized; };
            buttonSui.CheckedChanged += (sender, e) => { if (((RadioButton)sender).Checked) result = PresetDialogResults.Sui; };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(buttonAll);
            prompt.Controls.Add(buttonAllFixed);
            prompt.Controls.Add(buttonSui);
            prompt.ShowDialog();
            return result;
        }

        private enum PresetDialogResults
        {
            None,
            All,
            Categorized,
            Sui
        }

        private enum readTypeEnum
        {
            MenuMusic,
            RaceMusic,
            StuntMusic
        }
    }
}
