using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace movec
{
    class LoadMovieControlFromApi
    {
        public static int page = 1;

        public static int totalPages = 1;

        private static String movieName;

        public async Task<String> loadMovieControlFromApi(MainPage mainPage)
        {
            try
            {
                if (page <= totalPages)
                {
                    if (page == 1)
                    {
                        SpaceCleaner spaceCleaner = new SpaceCleaner();
                        movieName = spaceCleaner.getSpaceCleanedText(mainPage.search_text.Text);
                    }

                    if (movieName == "")
                    {
                        return "error";
                    }

                    mainPage.searching_lbl.Visible = true;
                    MovieAPI movieAPI = new MovieAPI();
                    var response = await movieAPI.getImdbIDAsync(movieName, page.ToString());

                    if (response.search == null)
                    {
                        mainPage.not_found_lbl.Visible = true;
                        mainPage.searching_lbl.Visible = false;
                        mainPage.total_results.Visible = false;
                        return "error";
                    }

                    totalPages = Convert.ToInt32(response.totalResults) / 10 + 1;

                    Constants constants = new Constants();

                    foreach (var item in response.search)
                    {
                        MovieControl movieControl = new MovieControl(item.imdbID, item.poster == "N/A" ? constants.kMoviePoster : item.poster);
                        movieControl.Visible = false;
                        if (item.poster != "N/A")
                        {
                            movieControl.movie_poster.Load(item.poster);
                        }
                        else
                        {
                            movieControl.movie_poster.Image = Image.FromFile(constants.kMoviePoster);
                        }

                        foreach (var itemAsFavouriteMovieFromList in MainPage.favouriteMovies)
                        {
                            if (item.imdbID == itemAsFavouriteMovieFromList.getImdbID)
                            {
                                movieControl.isFavourite = true;
                                break;
                            }
                        }

                        movieControl.movie_type_lbl.Text = char.ToUpper(item.type[0]) + item.type.Substring(1);
                        movieControl.movie_name_lbl.Text = item.title;
                        movieControl.movie_year_lbl.Text = item.year;
                        mainPage.total_results.Text = "Total Results: " + response.totalResults;
                        mainPage.total_results.Visible = true;
                        mainPage.flowLayoutPanel1.Controls.Add(movieControl);
                    }

                    Thread.Sleep(1);

                    mainPage.searching_lbl.Visible = false;

                    foreach (MovieControl item in mainPage.flowLayoutPanel1.Controls)
                    {
                        item.Visible = true;
                    }

                    page++;
                }

                return "success";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return "error";
            }
        }
    }
}
