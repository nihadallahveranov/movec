using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movec
{
    public partial class MovieInfoPage : Form
    {
        MouseMoveController mouseMoveController;

        public readonly String imdbID;
        public MovieInfoPage(String imdbID)
        {
            InitializeComponent();
            mouseMoveController = new MouseMoveController();
            FormControlImages formControlImages = new FormControlImages();
            formControlImages.defaultImages(minimize_img, close_img, maximize_img);
            this.main_menu.BackColor = Colors.darkModeColor;
            this.main_panel.BackColor = Colors.darkModePrimaryColor;
            this.title_panel.BackColor = Colors.darkModePrimaryColor;
            this.divider_left_panel.BackColor = Colors.darkModePrimaryColor;
            this.divider_right_panel.BackColor = Colors.darkModePrimaryColor;
            this.primary_panel.BackColor = Colors.darkModePrimaryColor;
            this.play_panel.BackColor = Colors.darkModePrimaryColor;
            this.year_runtime_lbl.ForeColor = Colors.greyColor;
            this.imdb_10_lbl.ForeColor = Colors.greyColor;
            this.imdb_votes_lbl.ForeColor = Colors.greyColor;
            this.imdb_title_lbl.ForeColor = Colors.greyColor;
            this.metascore_title_lbl.ForeColor = Colors.greyColor;
            this.genre_lbl.ForeColor = Colors.greyColor;
            this.director_lbl.ForeColor = Colors.greyColor;
            this.writers_lbl.ForeColor = Colors.greyColor;
            this.actors_lbl.ForeColor = Colors.greyColor;
            this.overview_lbl.ForeColor = Colors.greyColor;
            this.release_lbl.ForeColor = Colors.greyColor;
            this.country_lbl.ForeColor = Colors.greyColor;
            this.language_lbl.ForeColor = Colors.greyColor;
            this.awards_lbl.ForeColor = Colors.greyColor;
            this.box_office_lbl.ForeColor = Colors.greyColor;
            this.awards_lbl.UseMnemonic = false;
            this.imdbID = imdbID;
        }

        private void close_img_MouseHover(object sender, EventArgs e)
        {
            FormControlImages formControlImages = new FormControlImages();
            formControlImages.closeImageMouseHoverEvent(close_img);
        }

        private void close_img_MouseLeave(object sender, EventArgs e)
        {
            FormControlImages formControlImages = new FormControlImages();
            formControlImages.closeImageMouseLeaveEvent(close_img);
        }

        private void minimize_img_MouseHover(object sender, EventArgs e)
        {
            FormControlImages formControlImages = new FormControlImages();
            formControlImages.minimizeImageMouseHoverEvent(minimize_img);
        }

        private void minimize_img_MouseLeave(object sender, EventArgs e)
        {
            FormControlImages formControlImages = new FormControlImages();
            formControlImages.minimizeImageMouseLeaveEvent(minimize_img);
        }

        private void close_img_Click(object sender, EventArgs e)
        {
            // Application exit when click on the red close button.
            //Application.Exit();
            this.Hide();
            LoadFromScrolling.mainPage.Show();
        }

        private void minimize_img_Click(object sender, EventArgs e)
        {
            // Window state of Application minimized when click on the yellow minimize button
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximize_img_MouseHover(object sender, EventArgs e)
        {
            FormControlImages formControlImages = new FormControlImages();
            formControlImages.maximizeImageMouseHoverEvent(maximize_img);
        }

        private void maximize_img_MouseLeave(object sender, EventArgs e)
        {
            FormControlImages formControlImages = new FormControlImages();
            formControlImages.maximizeImageMouseLeaveEvent(maximize_img);
        }

        private void maximize_img_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            this.overview_title_lbl.Location = new Point(this.primary_panel.Width / 2 - this.overview_title_lbl.Width / 2, this.overview_title_lbl.Location.Y);
            this.overview_lbl.MaximumSize = new Size(this.primary_panel.Width - 50, 0);
            this.genre_lbl.MaximumSize = new Size(this.primary_panel.Width - 180, 0);
            this.director_lbl.MaximumSize = new Size(this.primary_panel.Width - 180, 0);
            this.writers_lbl.MaximumSize = new Size(this.primary_panel.Width - 180, 0);
            this.actors_lbl.MaximumSize = new Size(this.primary_panel.Width - 180, 0);
        }

        private void main_menu_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMoveController.mousedDown(sender, e, main_menu.Location.X, main_menu.Location.Y);
        }

        private void main_menu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMoveController.isMove)
                this.SetDesktopLocation(MousePosition.X - mouseMoveController.getMoveX, MousePosition.Y - mouseMoveController.getMoveY);
        }

        private void main_menu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseMoveController.isMove = false;
        }

        private async void play_picturebox_Click(object sender, EventArgs e)
        {
            try
            {
                MovieAPI movieAPI = new MovieAPI();
                RootObjectForTrailerData rootObjectForTrailerData = await movieAPI.getTrailerDataAsync(this.imdbID);

                if (rootObjectForTrailerData.errorMessage == "")
                {
                    System.Diagnostics.Process.Start(rootObjectForTrailerData.linkEmbed);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void poster_picturebox_MouseHover(object sender, EventArgs e)
        {
            play_panel.Visible = true;
        }

        private void title_panel_MouseHover(object sender, EventArgs e)
        {
            play_panel.Visible = false;
        }
    }
}
