using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movec
{
    class SpaceCleaner
    {
        public String getSpaceCleanedText(String text)
        {
            String movieName = "";
            int lengthOfTextBox = text.Length - 1;
            text = text.Trim();
            bool hasSpace = false;
            foreach (char letter in text)
            {
                if (letter == ' ' && !hasSpace)
                {
                    movieName += "%20";
                    hasSpace = true;
                }
                else
                {
                    movieName += letter;
                }
                if (letter != ' ')
                {
                    hasSpace = false;
                }
            }
            movieName = movieName.Replace(" ", "");
            LoadFromScrolling.mainPage.search_text.Text = movieName.Replace("%20", " ");
            return movieName;
        }
    }
}
