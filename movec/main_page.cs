using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;

namespace movec
{
    public partial class MainPage : Form
    {
        MouseMoveController mouseMoveController;

        public static int favouriteMoviesCounter = 0;

        public static List<MovieControl> favouriteMovies = new List<MovieControl>();

        public MainPage()
        {
            InitializeComponent();
            mouseMoveController = new MouseMoveController();
            FormControlImages formControlImages = new FormControlImages();
            Constants constants = new Constants();
            formControlImages.defaultImages(minimize_img, close_img, maximize_img);
            panel1.BackColor = Colors.darkModeColor;
            panel3.BackColor = Colors.darkModeColor;
            panel2.BackColor = Colors.darkModePrimaryColor;
            flowLayoutPanel1.BackColor = Colors.darkModePrimaryColor;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            about_panel.Visible = false;
            this.total_results.ForeColor = Colors.greyColor;
            this.search_panel.BackColor = Colors.darkGreyColor;
            this.search_text.BackColor = Colors.darkGreyColor;
            this.search_text.ForeColor = Colors.greyColor;
            this.total_results.Text = "";
            this.searching_lbl.Visible = false;
            this.not_found_lbl.Visible = false;
            LoadFromScrolling.mainPage = this;
            this.fav_lbl.ForeColor = Colors.greyColor;
            this.settings_lbl_as_button.ForeColor = Colors.greyColor;
            this.exit_lbl.ForeColor = Colors.greyColor;
            this.label1.Text = favouriteMoviesCounter.ToString();
            this.fav_panel.Select();
            this.welcome_message.ForeColor = Colors.greyColor;
            fav_panel_Click(null, null);
            this.password_panel.BackColor = Colors.darkGreyColor;
            this.password_txt.BackColor = Colors.darkGreyColor;
            username_lbl.ForeColor = Colors.greyColor;
            password_lbl.ForeColor = Colors.greyColor;
            about_lbl.ForeColor = Colors.greyColor;
            this.new_password_panel.BackColor = Colors.darkGreyColor;
            this.new_password_txt.BackColor = Colors.darkGreyColor;
            this.confirm_password_txt.BackColor = Colors.darkGreyColor;
            this.confirm_password_panel.BackColor = Colors.darkGreyColor;
            this.about_panel.BackColor = Colors.darkGreyColor;
            this.fullname_lbl.Text = Firebase.getUserName;
            this.fullname_lbl.ForeColor = Colors.greyColor;
            this.fullname_lbl.Location = new Point(this.panel1.Width / 2 - this.fullname_lbl.Width / 2, this.fullname_lbl.Location.Y);
            this.circularPictureBox1.Image = Image.FromFile(Properties.Settings.Default.imageLocation);
        }

        private async void search_button_Click(object sender, EventArgs e)
        {
            if (search_text.Text == "" || search_text.ForeColor == Colors.greyColor)
            {
                return;
            }

            PanelController panelController = new PanelController();

            panelController.favPanelOff(fav_lbl, fav_panel, fav_picturebox);

            this.flowLayoutPanel1.Controls.Clear();

            this.searching_lbl.Visible = true;

            this.not_found_lbl.Visible = false;

            LoadMovieControlFromApi.page = 1;

            LoadMovieControlFromApi loadMovieControlFromApi = new LoadMovieControlFromApi();
            for (int i = 0; i < 3; i++)
            {
                await loadMovieControlFromApi.loadMovieControlFromApi(this);
            }
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
            Application.Exit();
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
                panel3.Cursor = Cursors.SizeAll;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                panel3.Cursor = Cursors.Default;
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMoveController.mousedDown(sender, e, panel3.Location.X, panel3.Location.Y);
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMoveController.isMove)
                this.SetDesktopLocation(MousePosition.X - mouseMoveController.getMoveX, MousePosition.Y - mouseMoveController.getMoveY);
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            // isMove is false when the mouse is released.
            mouseMoveController.isMove = false;
        }

        private void search_text_Enter(object sender, EventArgs e)
        {
            if (search_text.Text == "Search...")
            {
                PanelController panelController = new PanelController();
                search_text.Clear();
                search_text.ForeColor = Color.White;
                panelController.settingsPanelOff(settings_lbl_as_button, settings_panel, settings_picturebox);
            }
        }

        private void search_text_Leave(object sender, EventArgs e)
        {
            if (search_text.Text == "")
            {
                PanelController panelController = new PanelController();
                panelController.favPanelOn(fav_lbl, fav_panel, fav_picturebox);
            }
        }

        private void search_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search_button_Click(sender, e);
            }
        }

        private async void flowLayoutPanel1_MouseHover(object sender, EventArgs e)
        {
            LoadFromScrolling loadFromScrolling = new LoadFromScrolling();
            await loadFromScrolling.loadFromScroll(this);
        }

        private void circularPictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images|*.png;*.jpg;*.jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                circularPictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                Properties.Settings.Default.imageLocation = openFileDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void fav_panel_Click(object sender, EventArgs e)
        {
            PanelController panelController = new PanelController();
            panelController.favPanelOn(fav_lbl, fav_panel, fav_picturebox);
            panelController.settingsPanelOff(settings_lbl_as_button, settings_panel, settings_picturebox);
        }

        private void settings_panel_Click(object sender, EventArgs e)
        {
            PanelController panelController = new PanelController();
            if (settings_lbl_as_button.ForeColor == Color.Red)
            {
                panelController.favPanelOn(fav_lbl, fav_panel, fav_picturebox);
                panelController.settingsPanelOff(settings_lbl_as_button, settings_panel, settings_picturebox);
            }
            else
            {
                panelController.favPanelOff(fav_lbl, fav_panel, fav_picturebox);
                panelController.settingsPanelOn(settings_lbl_as_button, settings_panel, settings_picturebox);
            }
        }

        private void exit_panel_Click(object sender, EventArgs e)
        {
            favouriteMovies.Clear();
            LogInPage logInPage = new LogInPage();
            this.Hide();
            logInPage.ShowDialog();
            this.Close();
        }

        private void username_lbl_Click(object sender, EventArgs e)
        {
            username_lbl.ForeColor = Color.Red;
            password_lbl.ForeColor = Colors.greyColor;
            password_panel.Visible = true;
            new_password_panel.Visible = false;
            confirm_password_panel.Visible = false;
            change_button.Visible = true;
            change_button.Text = "Change Username";
            change_button.Location = new Point(change_button.Location.X, password_panel.Location.Y + 100);
            password_txt.Text = "Username";
            password_txt.ForeColor = Colors.greyColor;
            password_txt.PasswordChar = '\0';
            info_lbl.Text = "";
            settings_lbl_as_button.Select();
        }

        private void password_lbl_Click(object sender, EventArgs e)
        {
            info_lbl.Text = "";
            username_lbl.ForeColor = Colors.greyColor;
            password_lbl.ForeColor = Color.Red;
            password_panel.Visible = true;
            new_password_panel.Visible = true;
            confirm_password_panel.Visible = true;
            change_button.Visible = true;
            change_button.Text = "Change Password";
            change_button.Location = new Point(change_button.Location.X, confirm_password_panel.Location.Y + 100);
            password_txt.Text = "Password";
            password_txt.ForeColor = Colors.greyColor;
            password_txt.PasswordChar = '\0';
            new_password_txt.Text = "New Password";
            new_password_txt.ForeColor = Colors.greyColor;
            new_password_txt.PasswordChar = '\0';
            confirm_password_txt.Text = "Confirm Password";
            confirm_password_txt.ForeColor = Colors.greyColor;
            confirm_password_txt.PasswordChar = '\0';
            settings_lbl_as_button.Select();
        }

        private void password_txt_Enter(object sender, EventArgs e)
        {
            if (password_txt.Text == "Username" || password_txt.Text == "Password")
            {
                password_txt.Text = "";
                password_txt.ForeColor = Color.White;
            }
            else
            {
                return;
            }
            if (username_lbl.ForeColor == Color.Red)
            {
                password_txt.PasswordChar = '\0';
            }
            else
            {
                password_txt.PasswordChar = '*';
            }
        }

        private void password_txt_Leave(object sender, EventArgs e)
        {
            if (password_txt.Text == "")
            {
                password_txt.Text = "Password";
                password_txt.ForeColor = Colors.greyColor;
                password_txt.PasswordChar = '\0';
            }
        }

        private void new_password_txt_Enter(object sender, EventArgs e)
        {
            if (new_password_txt.Text == "New Password")
            {
                new_password_txt.Clear();
                new_password_txt.ForeColor = Color.White;
                new_password_txt.PasswordChar = '*';
            }
        }

        private void new_password_txt_Leave(object sender, EventArgs e)
        {
            if (new_password_txt.Text == "")
            {
                new_password_txt.Text = "New Password";
                new_password_txt.ForeColor = Colors.greyColor;
                new_password_txt.PasswordChar = '\0';
            }
        }

        private void confirm_password_txt_Enter(object sender, EventArgs e)
        {
            if (confirm_password_txt.Text == "Confirm Password")
            {
                confirm_password_txt.Clear();
                confirm_password_txt.ForeColor = Color.White;
                confirm_password_txt.PasswordChar = '*';
            }
        }

        private void confirm_password_txt_Leave(object sender, EventArgs e)
        {
            if (confirm_password_txt.Text == "")
            {
                confirm_password_txt.Text = "Confirm Password";
                confirm_password_txt.ForeColor = Colors.greyColor;
                confirm_password_txt.PasswordChar = '\0';
            }
        }

        private void github_img_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/nihadallahveranov/movec");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void linkedin_img_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://linkedin.com/in/nihadallahveranov");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void mail_img_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:nihad.allahveranov@gmail.com");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void change_button_Click(object sender, EventArgs e)
        {
            Constants constants = new Constants();
            Firebase firebase = new Firebase();
            if (password_txt.Text != "" && password_txt.ForeColor == Color.White)
            {
                visibleOnUsernameAndPassword();
                if (change_button.Text == "Change Username")
                {
                    if (await firebase.setUserNameAsync(MovieControl.email, password_txt.Text) == "error")
                    {
                        this.info_lbl.Text = constants.kMessageInternetInfo;
                        visibleOfUsernameAndPassword();
                        return;
                    }
                    fullname_lbl.Text = password_txt.Text;
                    this.fullname_lbl.Location = new Point(this.panel1.Width / 2 - this.fullname_lbl.Width / 2, this.fullname_lbl.Location.Y);
                    visibleOfUsernameAndPassword();
                }
                else if (change_button.Text == "Change Password")
                {
                    if (new_password_txt.Text != confirm_password_txt.Text)
                    {
                        info_lbl.Text = constants.kDifferentPasswords;
                        visibleOfUsernameAndPassword();
                        return;
                    }

                    Detector detector = new Detector(MovieControl.email);

                    if (!detector.getIsCorrectPassword(new_password_txt.Text))
                    {
                        info_lbl.Text = constants.kPasswordDetectorMessage;
                        visibleOfUsernameAndPassword();
                        return;
                    }
                    
                    await firebase.setPasswordAsync(MovieControl.email, password_txt.Text, new_password_txt.Text);

                    if (!Firebase.getIsCorrectUser)
                    {
                        info_lbl.Text = constants.kNotCorrectUser;
                        visibleOfUsernameAndPassword();
                        return;
                    }

                    info_lbl.Text = constants.kSuccessChangePassword;
                    visibleOfUsernameAndPassword();
                }
            }
        }

        private void password_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                change_button_Click(sender, e);
            }
        }

        private void visibleOnUsernameAndPassword()
        {
            password_txt.ReadOnly = true;
            new_password_txt.ReadOnly = true;
            confirm_password_txt.ReadOnly = true;
        }

        private void visibleOfUsernameAndPassword()
        {
            password_txt.ReadOnly = false;
            new_password_txt.ReadOnly = false;
            confirm_password_txt.ReadOnly = false;
        }
    }
}
