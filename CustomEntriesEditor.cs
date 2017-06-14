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
    public partial class CustomEntriesEditor : Form
    {
        private const string saveFile = "custom_playlist.txt";
        private OSTs ost;
        private Paths paths;


        public CustomEntriesEditor(Paths paths, OSTs ost)
        {
            InitializeComponent();
            this.paths = paths;
            this.ost = ost;

            fillWithSongs();
        }

        private void fillWithSongs()
        {
            var menuCollection = MenuTable.Controls;
            menuCollection.Container.RowCount = 1;

            foreach (var element in ost.CustomSoundtrack)
            {
                menuCollection.Add(new Label() { Text = element.Key, Dock = DockStyle.Fill });
                menuCollection.Add(new TextBox() { Text = element.Value.artist, Dock = DockStyle.Fill });
                menuCollection.Add(new TextBox() { Text = element.Value.song, Dock = DockStyle.Fill });
                menuCollection.Container.RowCount++;
            }
        }

        private void B_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            saveCustomInfo();
            this.Close();
        }

        private void saveCustomInfo()
        {
            var menuCollection = MenuTable.Controls;

            ost.CustomSoundtrack.Clear();

            for (int i = 1; i < menuCollection.Container.RowCount; i++)
            {
                string oggFileName = ((Label)menuCollection.Container.GetControlFromPosition(0, i)).Text;
                string artist = ((TextBox)menuCollection.Container.GetControlFromPosition(1, i)).Text;
                string song = ((TextBox)menuCollection.Container.GetControlFromPosition(2, i)).Text;

                if (song.Contains('\t'))
                    song = song.Replace('\t', ' ');

                if (artist.Contains('\t'))
                    artist = artist.Replace('\t', ' ');

                ost.CustomSoundtrack.Add(oggFileName, new OSTDictionary.FileInfo(artist, song));
            }

            paths.saveCustomInfo(ost);
        }
    }
}
