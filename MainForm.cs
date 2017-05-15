using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flatout3_MusicTool
{
    public partial class MainForm : Form
    {
        OSTDictionary.OSTs ost = new OSTDictionary.OSTs();
        Paths paths;

        public MainForm()
        {
            InitializeComponent();
            updateDisplayedOptions();
        }

        private void updateDisplayedOptions()
        {
            paths = new Paths(ost);
            setFoundLabel(L_Flatout1Found, paths.Flatout1Found);
            setFoundLabel(L_Flatout2Found, paths.Flatout2Found);
            setFoundLabel(L_Flatout3Found, paths.Flatout3Found);
            setFoundLabel(L_Flatout1MusicFound, paths.Flatout1OSTExtracted);
            setFoundLabel(L_Flatout2MusicFound, paths.Flatout2OSTExtracted);
            setFoundLabel(L_Flatout3MusicFound, paths.Flatout3OSTExtracted);
            B_ExtractFlatout1.Enabled = paths.Flatout1Found && !paths.Flatout1OSTExtracted;
            B_ExtractFlatout2.Enabled = paths.Flatout2Found && !paths.Flatout2OSTExtracted;
            B_PackIt.Enabled = (ost.UserPicksMenu.Count != 0 && ost.UserPicksRace.Count != 0 && ost.UserPicksStunt.Count != 0);
        }

        private void setFoundLabel(Label lb, bool found)
        {
            if (found)
            {
                lb.Text = "Yes";
                lb.ForeColor = Color.Green;
            }
            else
            {
                lb.Text = "No";
                lb.ForeColor = Color.Red;
            }
        }

        private void B_ExtractFlatout1_Click(object sender, EventArgs e)
        {
            Extracting extr = new Extracting(paths, 0, ost, CB_CleanFiles.Checked);
            extr.ShowDialog();
            extr.Dispose();
            updateDisplayedOptions();
        }

        private void B_ExtractFlatout2_Click(object sender, EventArgs e)
        {
            Extracting extr = new Extracting(paths, 1, ost, CB_CleanFiles.Checked);
            extr.ShowDialog();
            extr.Dispose();
            updateDisplayedOptions();
        }

        private void B_EditMenu_Click(object sender, EventArgs e)
        {
            PlaylistEditor playlistEditor = new PlaylistEditor(paths, ost);
            playlistEditor.ShowDialog();
            playlistEditor.Dispose();
            updateDisplayedOptions();
        }

        private void B_PackIt_Click(object sender, EventArgs e)
        {
            ModGame modding = new ModGame(paths, ost);
            bool result = modding.doWork();
            if (result)
                MessageBox.Show("Everything completed without an issue.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(modding.ModError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void B_CustomSountrack_Click(object sender, EventArgs e)
        {

        }
    }
}
