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
    public partial class MovieControl : UserControl
    {
        bool clicked;

        private readonly String imdbID;

        private readonly String posterName;

        // setter from sign_up.cs
        // you can get easily email from everywhere
        public static String email { get; set; }

        public String getImdbID
        {
            get
            {
                return this.imdbID;
            }
        }

        public String getPosterName
        {
            get
            {
                return posterName;
            }
        }



        public MovieControl(String imdbID, String posterName)
        {
            InitializeComponent();
            this.BackColor = Colors.darkGreyColor;
            this.movie_year_lbl.ForeColor = Colors.greyColor;
            this.movie_type_lbl.ForeColor = Colors.greyColor;
            this.panel1.Visible = false;
            this.imdbID = imdbID;
            this.posterName = posterName;
        }

        public bool isFavourite = false;

        private async void movie_poster_DoubleClick(object sender, EventArgs e)
        {
            clicked = false;
            Constants constants = new Constants();
            Firebase firebase = new Firebase();
            LoadFromScrolling.mainPage.welcome_message.Text = "";
            LoadFromScrolling.mainPage.fav_use_message_info.Text = "";
            panel1.Visible = true;
            if (isFavourite)
            {
                heart_image.Image = Image.FromFile(constants.kGreyHeart);
                isFavourite = false;
                MainPage.favouriteMoviesCounter--;
                LoadFromScrolling.mainPage.label1.Text = MainPage.favouriteMoviesCounter.ToString();
                await firebase.deleteMovieFromFireBaseAsync(email, imdbID);
                if (LoadFromScrolling.mainPage.fav_lbl.ForeColor == Color.Red)
                {
                    LoadFromScrolling.mainPage.flowLayoutPanel1.Controls.Remove(this);
                }

                foreach (var item in MainPage.favouriteMovies)
                {
                    if (item.imdbID == this.imdbID)
                    {
                        MainPage.favouriteMovies.Remove(item);
                        break;
                    }
                }
                panel1.Visible = false;
            }
            else
            {
                heart_image.Image = Image.FromFile(constants.kRedHeart);
                isFavourite = true;
                MainPage.favouriteMoviesCounter++;
                LoadFromScrolling.mainPage.label1.Text = MainPage.favouriteMoviesCounter.ToString();
                MainPage.favouriteMovies.Insert(0, this);
                await firebase.setMovieToFireBaseAsync(email, imdbID, movie_name_lbl.Text,
                                    movie_year_lbl.Text, movie_type_lbl.Text, posterName);
                panel1.Visible = false;
            }
        }

        private async void panel1_MouseHover(object sender, EventArgs e)
        {
            LoadFromScrolling loadFromScrolling = new LoadFromScrolling();
            await loadFromScrolling.loadFromScroll(LoadFromScrolling.mainPage);
        }

        private async void movie_poster_Click(object sender, EventArgs e)
        {
            if (clicked) return;
            clicked = true;

            await Task.Delay(SystemInformation.DoubleClickTime);

            if (!clicked) return;
            clicked = false;

            MovieInfoPage movieInfoPage = new MovieInfoPage(this.imdbID);
            movieInfoPage.WindowState = LoadFromScrolling.mainPage.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            movieInfoPage.StartPosition = FormStartPosition.CenterScreen;

            try
            {
                MovieAPI movieAPI = new MovieAPI();
                var response = await movieAPI.getAllInfosAsync(imdbID);

                Constants constants = new Constants();


                movieInfoPage.title_lbl.Text = response.title;
                movieInfoPage.year_runtime_lbl.Text = response.year + "  :  " + response.rated + "  :  " + response.runTime;
                movieInfoPage.country_lbl.Text = response.country;
                movieInfoPage.metascore_lbl.Text = response.meteScore + "%";
                movieInfoPage.imdb_lbl.Text = response.imdbRating;
                movieInfoPage.imdb_votes_lbl.Text = response.imdbVotes;
                movieInfoPage.poster_picturebox.Load(response.poster == "N/A" ? constants.kMoviePoster : response.poster);
                movieInfoPage.genre_lbl.Text = response.genre;
                movieInfoPage.director_lbl.Text = response.director;
                movieInfoPage.writers_lbl.Text = response.writer;
                movieInfoPage.actors_lbl.Text = response.actors;
                movieInfoPage.overview_lbl.Text = response.plot;
                movieInfoPage.release_lbl.Text = response.released;
                movieInfoPage.country_lbl.Text = response.country;
                movieInfoPage.language_lbl.Text = response.language;
                movieInfoPage.awards_lbl.Text = response.awards;
                movieInfoPage.box_office_lbl.Text = response.boxOffice;

                movieInfoPage.director_title_lbl.Location = new Point(movieInfoPage.director_title_lbl.Location.X, movieInfoPage.genre_lbl.Location.Y + movieInfoPage.genre_lbl.Height + 23);
                movieInfoPage.director_lbl.Location = new Point(movieInfoPage.director_lbl.Location.X, movieInfoPage.genre_lbl.Location.Y + movieInfoPage.genre_lbl.Height + 23);
                movieInfoPage.writers_title_lbl.Location = new Point(movieInfoPage.writers_title_lbl.Location.X, movieInfoPage.director_lbl.Location.Y + movieInfoPage.director_lbl.Height + 23);
                movieInfoPage.writers_lbl.Location = new Point(movieInfoPage.writers_lbl.Location.X, movieInfoPage.director_lbl.Location.Y + movieInfoPage.director_lbl.Height + 23);
                movieInfoPage.actors_lbl.Location = new Point(movieInfoPage.actors_lbl.Location.X, movieInfoPage.writers_lbl.Location.Y + movieInfoPage.writers_lbl.Height + 23);
                movieInfoPage.actors_title_lbl.Location = new Point(movieInfoPage.actors_title_lbl.Location.X, movieInfoPage.writers_lbl.Location.Y + movieInfoPage.writers_lbl.Height + 23);
                movieInfoPage.panel1.Height -= movieInfoPage.actors_lbl.Location.Y + movieInfoPage.actors_lbl.Height + 23 - movieInfoPage.overview_title_lbl.Location.Y;
                movieInfoPage.overview_title_lbl.Location = new Point(movieInfoPage.overview_title_lbl.Location.X, movieInfoPage.actors_lbl.Location.Y + movieInfoPage.actors_lbl.Height + 23);

                LoadFromScrolling.mainPage.Hide();

                movieInfoPage.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
