using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace movec
{
    class LoadFromScrolling
    {
        public static MainPage mainPage;

        public async Task<String> loadFromScroll(MainPage mainPage)
        {
            if (mainPage.search_text.ForeColor != Color.White || mainPage.fav_lbl.ForeColor == Color.Red)
            {
                return "not selected";
            }

            try
            {
                if (mainPage.flowLayoutPanel1.VerticalScroll.Value + mainPage.flowLayoutPanel1.Size.Height - 1 == mainPage.flowLayoutPanel1.VerticalScroll.Maximum)
                {
                    LoadMovieControlFromApi loadMovieControlFromApi = new LoadMovieControlFromApi();
                    await loadMovieControlFromApi.loadMovieControlFromApi(mainPage);
                    Thread.Sleep(4);
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
