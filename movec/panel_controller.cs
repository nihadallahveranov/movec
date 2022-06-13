using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movec
{
    class PanelController
    {
        public void settingsPanelOn(Label label, Panel panel, PictureBox pictureBox)
        {
            Constants constants = new Constants();
            panel.BackColor = Color.FromArgb(150, 0, 0, 0);
            label.ForeColor = Color.Red;
            pictureBox.Image = Image.FromFile(constants.kSettingsRedImage);
            LoadFromScrolling.mainPage.about_panel.Visible = true;
            LoadFromScrolling.mainPage.flowLayoutPanel1.Visible = false;
        }

        public void settingsPanelOff(Label label, Panel panel, PictureBox pictureBox)
        {
            Constants constants = new Constants();
            panel.BackColor = Color.FromArgb(0, 0, 0, 0);
            label.ForeColor = Colors.greyColor;
            pictureBox.Image = Image.FromFile(constants.kSettingsImage);
            LoadFromScrolling.mainPage.about_panel.Visible = false;
            LoadFromScrolling.mainPage.flowLayoutPanel1.Visible = true;
            LoadFromScrolling.mainPage.info_lbl.Text = "";
        }

        public void favPanelOn(Label label, Panel panel, PictureBox pictureBox)
        {
            Constants constants = new Constants();
            panel.BackColor = Color.FromArgb(150, 0, 0, 0);
            label.ForeColor = Color.Red;
            pictureBox.Image = Image.FromFile(constants.kRedHeart);
            LoadFromScrolling.mainPage.flowLayoutPanel1.Controls.Clear();
            LoadFromScrolling.mainPage.search_text.ForeColor = Colors.greyColor;
            LoadFromScrolling.mainPage.search_text.Text = "Search...";
            LoadFromScrolling.mainPage.fav_lbl.Select();
            LoadFromScrolling.mainPage.total_results.Text = "";
            foreach (var item in MainPage.favouriteMovies)
            {
                LoadFromScrolling.mainPage.flowLayoutPanel1.Controls.Add(item);
            }
        }

        public void favPanelOff(Label label, Panel panel, PictureBox pictureBox)
        {
            Constants constants = new Constants();
            panel.BackColor = Color.FromArgb(0, 0, 0, 0);
            label.ForeColor = Colors.greyColor;
            pictureBox.Image = Image.FromFile(constants.kGreyHeart);
        }
    }
}
