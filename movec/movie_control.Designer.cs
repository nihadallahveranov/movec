
namespace movec
{
    partial class MovieControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieControl));
            this.movie_name_lbl = new System.Windows.Forms.Label();
            this.movie_year_lbl = new System.Windows.Forms.Label();
            this.movie_type_lbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.heart_image = new System.Windows.Forms.PictureBox();
            this.movie_poster = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heart_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movie_poster)).BeginInit();
            this.SuspendLayout();
            // 
            // movie_name_lbl
            // 
            this.movie_name_lbl.AutoSize = true;
            this.movie_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.movie_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movie_name_lbl.ForeColor = System.Drawing.Color.White;
            this.movie_name_lbl.Location = new System.Drawing.Point(25, 340);
            this.movie_name_lbl.MaximumSize = new System.Drawing.Size(271, 70);
            this.movie_name_lbl.Name = "movie_name_lbl";
            this.movie_name_lbl.Size = new System.Drawing.Size(265, 58);
            this.movie_name_lbl.TabIndex = 1;
            this.movie_name_lbl.Text = "Movie name asdasdas  asdas dasdas dasd";
            this.movie_name_lbl.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // movie_year_lbl
            // 
            this.movie_year_lbl.AutoSize = true;
            this.movie_year_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movie_year_lbl.Location = new System.Drawing.Point(38, 406);
            this.movie_year_lbl.Name = "movie_year_lbl";
            this.movie_year_lbl.Size = new System.Drawing.Size(102, 24);
            this.movie_year_lbl.TabIndex = 2;
            this.movie_year_lbl.Text = "Movie year";
            this.movie_year_lbl.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // movie_type_lbl
            // 
            this.movie_type_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.movie_type_lbl.AutoSize = true;
            this.movie_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movie_type_lbl.Location = new System.Drawing.Point(221, 406);
            this.movie_type_lbl.Name = "movie_type_lbl";
            this.movie_type_lbl.Size = new System.Drawing.Size(109, 24);
            this.movie_type_lbl.TabIndex = 3;
            this.movie_type_lbl.Text = "Movie Type";
            this.movie_type_lbl.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.heart_image);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 330);
            this.panel1.TabIndex = 5;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // heart_image
            // 
            this.heart_image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.heart_image.BackColor = System.Drawing.Color.Transparent;
            this.heart_image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.heart_image.Image = ((System.Drawing.Image)(resources.GetObject("heart_image.Image")));
            this.heart_image.Location = new System.Drawing.Point(145, 145);
            this.heart_image.Name = "heart_image";
            this.heart_image.Size = new System.Drawing.Size(50, 50);
            this.heart_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.heart_image.TabIndex = 4;
            this.heart_image.TabStop = false;
            // 
            // movie_poster
            // 
            this.movie_poster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.movie_poster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.movie_poster.Location = new System.Drawing.Point(0, 0);
            this.movie_poster.Name = "movie_poster";
            this.movie_poster.Size = new System.Drawing.Size(330, 330);
            this.movie_poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.movie_poster.TabIndex = 0;
            this.movie_poster.TabStop = false;
            this.movie_poster.Click += new System.EventHandler(this.movie_poster_Click);
            this.movie_poster.DoubleClick += new System.EventHandler(this.movie_poster_DoubleClick);
            this.movie_poster.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // MovieControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.movie_poster);
            this.Controls.Add(this.movie_type_lbl);
            this.Controls.Add(this.movie_year_lbl);
            this.Controls.Add(this.movie_name_lbl);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "MovieControl";
            this.Size = new System.Drawing.Size(330, 440);
            this.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heart_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movie_poster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label movie_name_lbl;
        public System.Windows.Forms.Label movie_year_lbl;
        public System.Windows.Forms.Label movie_type_lbl;
        public System.Windows.Forms.PictureBox movie_poster;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox heart_image;
    }
}
