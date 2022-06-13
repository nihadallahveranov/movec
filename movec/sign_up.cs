using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movec
{
    class SignUpButtonClickEvent
    {
        public async Task<String> signUpButtonAsSignUp(LogInPage logInPage, String email, String password)
        {
            Constants constants = new Constants();
            Firebase firebase = new Firebase();
            try
            {
                try
                {
                    Properties.Settings.Default.imageLocation = constants.kDefaultUserImage;
                    Properties.Settings.Default.Save();
                }
                catch (Exception)
                {
                }
                logInPage.message_info_lbl.Text = constants.kSuccessSignUpMessage;
                logInPage.email_text.ReadOnly = true;
                logInPage.password_text.ReadOnly = true;
                logInPage.sign_up_button.Enabled = false;
                logInPage.sign_up_lbl.Enabled = false;
                await firebase.setDataToFireBaseAsync(email, password);
                logInPage.message_info_lbl.Text = constants.kLoadingMessage;
                MovieControl.email = email;
                MainPage mainPage = new MainPage();
                MainPage.favouriteMoviesCounter = 12;
                mainPage.label1.Text = MainPage.favouriteMoviesCounter.ToString();
                mainPage.welcome_message.Text = constants.kWelcomeMessage;
                mainPage.fav_use_message_info.Text = constants.kFavUseMessageInfo;
                foreach (var item in constants.kFavouriteMovies)
                {
                    MovieControl movieControl = new MovieControl(item["imdbID"] as String, item["Poster"] as String);
                    MainPage.favouriteMovies.Add(movieControl);
                    movieControl.isFavourite = true;
                    movieControl.movie_name_lbl.Text = item["Title"];
                    movieControl.movie_type_lbl.Text = item["Type"];
                    movieControl.movie_year_lbl.Text = item["Year"];
                    movieControl.heart_image.Image = Image.FromFile(constants.kRedHeart);
                    try
                    {
                        movieControl.movie_poster.Load(item["Poster"] as String);
                    }
                    catch (Exception)
                    {
                        movieControl.movie_poster.Load(constants.kMoviePoster);
                    }
                    mainPage.flowLayoutPanel1.Controls.Add(movieControl);
                }
                logInPage.Hide();
                mainPage.ShowDialog();
                logInPage.Close();
                return "success";
            }
            catch (Exception)
            {
                logInPage.message_info_lbl.Text = constants.kMessageInternetInfo;
                logInPage.email_text.ReadOnly = false;
                logInPage.password_text.ReadOnly = false;
                logInPage.sign_up_button.Enabled = true;
                logInPage.sign_up_lbl.Enabled = true;
                return "error";
            }
        }

        public async Task<String> signUpButtonAsSignIn(LogInPage logInPage, String email, String password)
        {
            Constants constants = new Constants();
            Firebase firebase = new Firebase();
            try
            {
                logInPage.sign_up_button.Enabled = false;
                logInPage.email_text.ReadOnly = true;
                logInPage.password_text.ReadOnly = true;
                logInPage.sign_up_lbl.Enabled = false;
                logInPage.message_info_lbl.Text = "Checking...";

                if (await firebase.isHasUserDetectorAsync(email) == "error")
                {
                    logInPage.sign_up_button.Enabled = true;
                    logInPage.email_text.ReadOnly = false;
                    logInPage.password_text.ReadOnly = false;
                    logInPage.sign_up_lbl.Enabled = true;
                    logInPage.message_info_lbl.Text = constants.kMessageInternetInfo;
                    return "error";
                }

                if (!Firebase.getIsHasUser)
                {
                    logInPage.message_info_lbl.Text = constants.kUserNotFound;
                    logInPage.sign_up_button.Enabled = true;
                    logInPage.email_text.ReadOnly = false;
                    logInPage.password_text.ReadOnly = false;
                    logInPage.sign_up_lbl.Enabled = true;
                }
                else
                {
                    List<Dictionary<String, object>> favouriteMovies = await firebase.getDataFromFireBaseAsync(email, password);
                    MainPage.favouriteMoviesCounter = favouriteMovies is null ? 0 : favouriteMovies.Count;

                    if (Firebase.getIsCorrectUser)
                    {
                        MovieControl.email = email;
                        logInPage.message_info_lbl.Text = constants.kLoadingMessage;
                        MainPage mainPage = new MainPage();
                        foreach (var item in favouriteMovies)
                        {
                            MovieControl movieControl = new MovieControl(item["imdbID"] as String, item["Poster"] as String);
                            MainPage.favouriteMovies.Add(movieControl);
                            movieControl.isFavourite = true;
                            movieControl.movie_name_lbl.Text = item["Title"] as String;
                            movieControl.movie_year_lbl.Text = item["Year"] as String;
                            movieControl.movie_type_lbl.Text = item["Type"] as String;
                            movieControl.heart_image.Image = Image.FromFile(constants.kRedHeart);
                            try
                            {
                                movieControl.movie_poster.Load(item["Poster"] as String);
                            }
                            catch (Exception)
                            {
                                movieControl.movie_poster.Load(constants.kMoviePoster);
                            }
                            mainPage.flowLayoutPanel1.Controls.Add(movieControl);
                        }
                        logInPage.Hide();
                        mainPage.ShowDialog();
                        logInPage.Close();
                    }
                    else
                    {
                        logInPage.message_info_lbl.Text = constants.kNotCorrectUser;
                        logInPage.sign_up_button.Enabled = true;
                        logInPage.email_text.ReadOnly = false;
                        logInPage.password_text.ReadOnly = false;
                        logInPage.sign_up_lbl.Enabled = true;
                    }
                }
                return "success";
            }
            catch (Exception)
            {
                return "error";
            }
        }
    }
}
