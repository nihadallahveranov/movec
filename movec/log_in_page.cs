using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Google.Cloud.Firestore;
using Google.Apis.Auth;
using System.Net.Mail;
using System.Net;
using System.Net.Http;

namespace movec
{
    public partial class LogInPage : Form
    {
        // The path of images folder
        public static readonly String imagePath = Application.StartupPath.Replace("\\bin\\Debug", "") + "\\assets\\images";

        int timerCounter = 0;

        Detector emailDetector;

        List<TextBox> verifyTextBoxes;

        String email;
        String emailHintText = "Email";
        String passwordHintText = "Password";
        char emailPasswordChar = '\0';

        MouseMoveController mouseMoveController;

        public static LogInPage logInPage;

        String verificationCode = "";

        // Constructor
        public LogInPage()
        {
            InitializeComponent();

            mouseMoveController = new MouseMoveController();

            logInPage = this;

            Constants constants = new Constants();

            // Initialize Log in Form component properties
            /*** Form ***/
            this.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.5);
            this.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.5);
            this.BackgroundImage = Image.FromFile(constants.kBackgroundImgPath);

            /*** login_panel ***/
            this.login_panel.BackColor = Color.FromArgb(212, 0, 0, 0);
            this.login_panel.Width = (int)(this.Width / 2.3);
            this.login_panel.Height = (this.Height / 10) * 9;
            this.login_panel.Left = (this.Size.Width - this.login_panel.Width) / 2;
            this.login_panel.Top = (this.Size.Height - this.login_panel.Height) / 2;

            // Method to make default images
            FormControlImages formControlImages = new FormControlImages();
            formControlImages.defaultImages(minimize_img, close_img, null);

            /*** label1 ***/
            this.label1.ForeColor = System.Drawing.Color.White;

            /*** email_text ***/
            this.email_text.BackColor = Colors.darkGreyColor;

            /*** email_panel ***/
            this.email_panel.BackColor = Colors.darkGreyColor;

            /*** password_text ***/
            this.password_text.BackColor = Colors.darkGreyColor;

            /*** password_panel ***/
            this.password_panel.BackColor = Colors.darkGreyColor;

            /*** password_detector_lbl ***/
            this.password_detector_lbl.Text = "";

            /*** password_detector_lbl ***/
            this.message_info_lbl.Text = "";

            /*** circularprogressbar ***/
            this.Select();

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", constants.kFireBaseJsonPath);

            /*** verify text boxes ***/
            #region Verify Text Boxes
            verifyTextBoxes = new List<TextBox>();

            foreach (Control item in this.login_panel.Controls)
            {
                if (item.TabIndex > 8 && item.TabIndex < 15)
                {
                    verifyTextBoxes.Add(item as TextBox);
                    TextBox textBox = item as TextBox;
                    textBox.BackColor = Colors.greyColor;
                    textBox.Visible = false;
                    textBox.Location = new Point(textBox.Location.X, email_panel.Location.Y);
                }
            }

            int lengthOfVerifyTextBoxes = verifyTextBoxes.Count;

            for (int i = 0; i < lengthOfVerifyTextBoxes; i++)
            {
                for (int j = 1; j < lengthOfVerifyTextBoxes - i; j++)
                {
                    if (verifyTextBoxes[j - 1].TabIndex > verifyTextBoxes[j].TabIndex)
                    {
                        var temp = verifyTextBoxes[j - 1];
                        verifyTextBoxes[j - 1] = verifyTextBoxes[j];
                        verifyTextBoxes[j] = temp;
                    }
                }
            }
            #endregion

            /*** not receive code lbl ***/
            this.not_receive_code_lbl.Text = "";
        }

        private void setColorOfTextFields(object textSender, object panelSender, Color color)
        {
            TextBox textbox = textSender as TextBox;
            textbox.BackColor = color;
            Panel panel = panelSender as Panel;
            panel.BackColor = color;
        }

        public void LogInPage_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMoveController.mousedDown(sender, e, login_panel.Location.X, login_panel.Location.Y);
        }

        public void LogInPage_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMoveController.isMove)
                this.SetDesktopLocation(MousePosition.X - mouseMoveController.getMoveX, MousePosition.Y - mouseMoveController.getMoveY);
        }

        public void LogInPage_MouseUp(object sender, MouseEventArgs e)
        {
            // isMove is false when the mouse is released.
            mouseMoveController.isMove = false;
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

        private void email_text_Enter(object sender, EventArgs e)
        {
            setColorOfTextFields(email_text, email_panel, Colors.greyColor);
            #region SetTextFields as email
            if (email_text.ForeColor == Colors.greyColor)
            {
                email_text.Text = "";
                email_text.PasswordChar = emailPasswordChar;
                email_text.ForeColor = Color.White;
            }
            #endregion

            #region Password Detector
            emailDetector = new Detector(email_text.Text);
            Constants constants = new Constants();
            if (!emailDetector.getIsCorrectPassword(password_text.Text) && password_text.PasswordChar == '*')
            {
                password_detector_lbl.Text = constants.kPasswordDetectorMessage;
            }
            #endregion
        }

        private void email_text_Leave(object sender, EventArgs e)
        {
            setColorOfTextFields(email_text, email_panel, Colors.darkGreyColor);
            #region SetTextFields
            setColorOfTextFields(email_text, email_panel, Colors.darkGreyColor);
            if (email_text.Text == "")
            {
                email_text.Text = emailHintText;
                email_text.PasswordChar = '\0';
                email_text.ForeColor = Colors.greyColor;
            }
            #endregion
        }

        private void password_text_Enter(object sender, EventArgs e)
        {
            #region SetColorOfTextFields
            setColorOfTextFields(password_text, password_panel, Colors.greyColor);
            if (password_text.ForeColor == Colors.greyColor)
            {
                password_text.Text = "";
                password_text.PasswordChar = '*';
                password_text.ForeColor = Color.White;
            }
            #endregion

            #region Email Detector
            emailDetector = new Detector(email_text.Text);
            Constants constants = new Constants();
            if (!emailDetector.getIsCorrectEmail() && email_text.Text != "Email")
            {
                email_detector_lbl.Text = constants.kEmailDetectorMessage;
            }
            #endregion

        }

        private void password_text_Leave(object sender, EventArgs e)
        {
            setColorOfTextFields(password_text, password_panel, Colors.darkGreyColor);
            if (password_text.Text == "")
            {
                password_text.Text = passwordHintText;
                password_text.PasswordChar = '\0';
                password_text.ForeColor = Colors.greyColor;
            }
        }

        private void sign_up_lbl_Click(object sender, EventArgs e)
        {
            this.login_panel.Visible = false;
            this.message_info_lbl.Text = "";
            emailHintText = "Email";
            passwordHintText = "Password";

            #region Sign Up
            if (this.label1.Text == "Sign In")
            {
                this.password_detector_lbl.Visible = false;
                this.password_panel.Visible = false;
                this.sign_up_button.Location = new Point(sign_up_button.Location.X, sign_up_button.Location.Y - 140);
                this.sign_up_info_lbl.Location = new Point(sign_up_info_lbl.Location.X, sign_up_info_lbl.Location.Y - 150);
                this.sign_up_lbl.Location = new Point(sign_up_lbl.Location.X + 20, sign_up_lbl.Location.Y - 150);
                this.label1.Text = "Sign Up";
                this.sign_up_button.Text = "Get Started";
                this.sign_up_info_lbl.Text = "Have a member of Movec ?";
                this.sign_up_lbl.Text = "Sign In";
            }
            #endregion

            #region Sign In
            else if (this.label1.Text == "Sign Up")
            {
                this.password_detector_lbl.Visible = true;
                this.password_panel.Visible = true;
                if (sign_up_button.Text != "Sign Up")
                {
                    this.sign_up_button.Location = new Point(sign_up_button.Location.X, sign_up_button.Location.Y + 140);
                    this.sign_up_info_lbl.Location = new Point(sign_up_info_lbl.Location.X, sign_up_info_lbl.Location.Y + 150);
                    this.sign_up_lbl.Location = new Point(sign_up_lbl.Location.X - 20, sign_up_lbl.Location.Y + 150);
                }
                else
                {
                    this.email_text.Text = emailHintText;
                    this.email_text.ForeColor = Colors.greyColor;
                    this.sign_up_lbl.Location = new Point(sign_up_lbl.Location.X - 20, sign_up_lbl.Location.Y);
                }
                this.label1.Text = "Sign In";
                this.sign_up_button.Text = "Sign In";
                this.sign_up_info_lbl.Text = "Not a member of Movec ?";
                this.sign_up_lbl.Text = "Sign Up Now";
                this.not_receive_code_lbl.Text = "";
                emailPasswordChar = '\0';
                this.email_text.PasswordChar = emailPasswordChar;
                this.password_text.Text = passwordHintText;
                this.password_text.ForeColor = Colors.greyColor;
                this.password_text.PasswordChar = '\0';
                this.email_panel.Visible = true;
                this.email_detector_lbl.Visible = true;
                foreach (var item in this.verifyTextBoxes)
                {
                    item.Visible = false;
                    item.Clear();
                }
            }
            #endregion

            Thread.Sleep(2);
            this.login_panel.Visible = true;
        }

        private async void sign_up_button_Click(object sender, EventArgs e)
        {
            Constants constants = new Constants();
            #region Email and Password Detector
            emailDetector = new Detector(email_text.Text);
            if (!emailDetector.getIsCorrectEmail() && sign_up_button.Text != "Sign Up")
            {
                email_detector_lbl.Text = constants.kEmailDetectorMessage;
                return;
            }
            if ((!emailDetector.getIsCorrectPassword(password_text.Text) || password_text.ForeColor == Colors.greyColor) && sign_up_button.Text == "Sign In")
            {
                password_detector_lbl.Text = constants.kPasswordDetectorMessage;
                return;
            }
            if (!emailDetector.getIsCorrectPassword(password_text.Text) && sign_up_button.Text == "Sign Up")
            {
                this.message_info_lbl.Text = constants.kPasswordDetectorMessage;
                password_detector_lbl.Text = constants.kPasswordDetectorMessage;
                return;
            }
            #endregion

            EmailSender emailSender = new EmailSender();

            #region Get Started
            if (sign_up_button.Text == "Get Started")
            {
                Firebase firebase = new Firebase();
                try
                {
                    this.sign_up_button.Enabled = false;
                    this.email_text.ReadOnly = true;
                    this.message_info_lbl.Text = "Checking...";
                    await firebase.isHasUserDetectorAsync(email_text.Text);
                    if (Firebase.getIsHasUser)
                    {
                        this.message_info_lbl.Text = constants.kHasUserMessage;
                        this.sign_up_button.Enabled = true;
                        this.email_text.ReadOnly = false;
                    }
                    else
                    {
                        this.message_info_lbl.Text = constants.kSignUpMessageInfo;
                        email = email_text.Text;
                        timer1.Start();
                        verificationCode = emailSender.sendEmailVerification(email_text.Text);
                    }
                }
                catch (Exception)
                {
                    this.email_text.ReadOnly = false;
                    this.sign_up_button.Enabled = true;
                    this.message_info_lbl.Text = constants.kMessageInternetInfo;
                    timer1.Stop();
                }
            }
            #endregion Get Started

            #region Verify
            else if (sign_up_button.Text == "Verify")
            {
                String inputCode = "";
                foreach (TextBox item in verifyTextBoxes)
                {
                    inputCode += item.Text;
                }
                if (inputCode != verificationCode)
                {
                    this.message_info_lbl.Text = constants.kWrongVerificationCode;
                }
                else
                {
                    this.message_info_lbl.Text = "";
                    emailHintText = "Password";
                    passwordHintText = "Confirm Password";
                    emailPasswordChar = '*';
                    this.login_panel.Visible = false;
                    this.email_panel.Visible = true;
                    this.password_panel.Visible = true;
                    this.email_detector_lbl.Visible = false;
                    this.sign_up_button.Text = "Sign Up";
                    this.sign_up_button.Location = new Point(sign_up_button.Location.X, sign_up_button.Location.Y + 140);
                    this.sign_up_info_lbl.Location = new Point(sign_up_info_lbl.Location.X, sign_up_info_lbl.Location.Y + 150);
                    this.sign_up_lbl.Location = new Point(sign_up_lbl.Location.X, sign_up_lbl.Location.Y + 150);
                    this.not_receive_code_lbl.Text = "";
                    this.Select();
                    this.email_text.Text = emailHintText;
                    this.email_text.ForeColor = Colors.greyColor;
                    this.password_text.Text = passwordHintText;
                    this.password_text.ForeColor = Colors.greyColor;
                    this.password_text.PasswordChar = '\0';
                    foreach (TextBox item in verifyTextBoxes)
                    {
                        item.Visible = false;
                    }
                    Thread.Sleep(2);
                    this.login_panel.Visible = true;
                }
            }
            #endregion Verify

            #region Sign Up
            else if (sign_up_button.Text == "Sign Up")
            {
                SignUpButtonClickEvent signUpButtonClickEvent = new SignUpButtonClickEvent();
                if (email_text.Text == password_text.Text)
                {
                    await signUpButtonClickEvent.signUpButtonAsSignUp(this, email, password_text.Text);
                }
                else
                {
                    this.message_info_lbl.Text = constants.kDifferentPasswords;
                }
            }
            #endregion Sign Up

            #region Sign In
            else if (sign_up_button.Text == "Sign In")
            {
                SignUpButtonClickEvent signUpButtonClickEvent = new SignUpButtonClickEvent();
                await signUpButtonClickEvent.signUpButtonAsSignIn(this, email_text.Text, password_text.Text);
            }
            #endregion
        }

        private void email_text_TextChanged(object sender, EventArgs e)
        {
            emailDetector = new Detector(email_text.Text);
            if (emailDetector.getIsCorrectEmail())
            {
                email_detector_lbl.Text = "";
            }
        }

        private void password_text_TextChanged(object sender, EventArgs e)
        {
            emailDetector = new Detector(email_text.Text);
            if (emailDetector.getIsCorrectPassword(password_text.Text))
            {
                password_detector_lbl.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Constants constants = new Constants();
            if (timerCounter > 2)
            {
                timerCounter = 0;
                this.login_panel.Visible = false;
                this.message_info_lbl.Text = "";
                this.sign_up_button.Text = "Verify";
                this.email_panel.Visible = false;
                foreach (TextBox item in verifyTextBoxes)
                {
                    item.Visible = true;
                }
                Thread.Sleep(2);
                this.login_panel.Visible = true;
                this.not_receive_code_lbl.Text = constants.kNotReceiveCode;
                this.sign_up_button.Enabled = true;
                this.email_text.ReadOnly = false;
                timer1.Stop();
            }
            timerCounter++;
        }

        private void not_receive_code_lbl_Click(object sender, EventArgs e)
        {
            not_receive_code_lbl.Text = "";
            sign_up_button.Text = "Get Started";
            foreach (TextBox item in verifyTextBoxes)
            {
                item.Clear();
            }
            this.sign_up_button_Click(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Constants constants = new Constants();
            TextBox textBox = sender as TextBox;
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                textBox.Clear();
                return;
            }
            else if (constants.kNumbers.Contains(textBox.Text))
            {
                foreach (TextBox item in verifyTextBoxes)
                {
                    if (textBox.TabIndex + 1 == item.TabIndex)
                    {
                        item.Select();
                        break;
                    }
                }
            }
        }

        private void email_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sign_up_button_Click(sender, e);
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sign_up_button_Click(sender, e);
            }
        }
    }
}