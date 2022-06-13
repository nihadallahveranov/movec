using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movec
{
    class Constants
    {
        public readonly String kYellowCircleButtonImgPath = LogInPage.imagePath + "\\yellow_circle_button.png";
        public readonly String kMinimizeButtonImgPath = LogInPage.imagePath + "\\minimize_button.png";
        public readonly String kRedCircleButtonImgPath = LogInPage.imagePath + "\\circle_button.png";
        public readonly String kCloseButtonImgPath = LogInPage.imagePath + "\\close_button.png";
        public readonly String kMaximizeButtonImgPath = LogInPage.imagePath + "\\maximize_button.png";
        public readonly String kGreenCircleButtonImgPath = LogInPage.imagePath + "\\green_circle_button.png";
        public readonly String kBackgroundImgPath = LogInPage.imagePath + "\\movies.png";
        public readonly String kGreyHeart = LogInPage.imagePath + "\\grey-heart.png";
        public readonly String kRedHeart = LogInPage.imagePath + "\\red-heart.png";
        public readonly String kMoviePoster = LogInPage.imagePath + "\\movie_poster_image.png";
        public readonly String kDefaultUserImage = LogInPage.imagePath + "\\default_user_image.png";
        public readonly String kSettingsImage = LogInPage.imagePath + "\\settings.png";
        public readonly String kSettingsRedImage = LogInPage.imagePath + "\\settings_red.png";
        public readonly String kFireBaseJsonPath = LogInPage.imagePath.Replace("\\assets\\images", "") + "\\cloudfirestore.json";
        public readonly String kProjectId = "movec-9a7b4";
        public readonly String kEmailDetectorMessage = "Please enter a valid email.";
        public readonly String kPasswordDetectorMessage = "Your password must contain 8 and 32 characters.";
        public readonly String kFireBaseApiKey = "AAAAifEjsYY:APA91bH752qX79nxpMv7l0z4CTp0Yn3AC2iN97BXgpZEbjpyEQsmaw4DVmq_kgK-PWWB23mWXNP4bA99wBmnO-JvArxzbAAYJ6bMVp2U1YYcI6qo9qbpJYsmiIUrOdPnhW1LYqaCFrLp";
        public readonly String kSenderEmail = "movec.app@gmail.com";
        public readonly String kLowerCaseAlphabet = "qwertyuiopasdfghjklzxcvbnm";
        public readonly String kUpperCaseAlpabet = "QWERTYUIOPASDFGHJKLZXCVBNM";
        public readonly String kNumbers = "0123456789";
        public readonly String kSymbols = "-";
        public readonly String kMessageInternetInfo = "Your internet connection was interrupted. Please check your internet connection and try again.";
        public readonly String kSignUpMessageInfo = "Check your email for the verification code.";
        public readonly String kWrongVerificationCode = "Invalid verification code.";
        public readonly String kDifferentPasswords = "Different Passwords.";
        public readonly String kNotReceiveCode = "Didn't receive code ?";
        public readonly String kHasUserMessage = "Email already exists, you can try logging in with this email.";
        public readonly String kSuccessSignUpMessage = "You have signed up successfully.";
        public readonly String kUserNotFound = "User not found.";
        public readonly String kNotCorrectUser = "Password is not correct.";
        public readonly String kSuccessSignInMessage = "You have signed in successfully.";
        public readonly String kLoadingMessage = "Loading...";
        public readonly String kWelcomeMessage = "Welcome to Movec.";
        public readonly String kFavUseMessageInfo = "Double-click the movie you want to add to your favourite.";
        public readonly String kSuccessChangePassword = "Password changed successfully.";
        public static String userName;
        public readonly List<Dictionary<String, String>> kFavouriteMovies = new List<Dictionary<String, String>>{
            new Dictionary<String, String>
            {
                {"imdbID", "tt0068646" },
                {"Title", "The Godfather" },
                {"Year",  "1972"},
                {"Type", "Movie" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg" }
            },
            new Dictionary<String, String>
            {
                {"imdbID", "tt0232500" },
                {"Title", "The Fast and the Furious" },
                {"Year",  "2001"},
                {"Type", "Movie" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BNzlkNzVjMDMtOTdhZC00MGE1LTkxODctMzFmMjkwZmMxZjFhXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg" }
            },
            new Dictionary<String, String>
            {
                {"imdbID", "tt0133093" },
                {"Title", "The Matrix" },
                {"Year",  "1999"},
                {"Type", "Movie" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg" }
            },
            new Dictionary<String, String>
            {
                {"imdbID", "tt0421384" },
                {"Title", "The Valley of the Wolves" },
                {"Year",  "2003–2005"},
                {"Type", "Series" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BNTU4OWY5YjUtMjYyOC00NzcxLTlkZjgtY2U3YTJmYmVmYTU4XkEyXkFqcGdeQXVyODY0NDk4NDg@._V1_SX300.jpg" }
            },
            new Dictionary<String, String>
            {
                {"imdbID", "tt4574334" },
                {"Title", "Stranger Things" },
                {"Year",  "2016–"},
                {"Type", "Series" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BODZlYjQ4NzYtZTg1MC00NGY4LTg4NjQtNGE3ZjRkMjk3YjMyXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SX300.jpg" }
            },
            new Dictionary<String, String>
            {
                {"imdbID", "tt10431500" },
                {"Title", "Miracle in Cell No. 7" },
                {"Year",  "2019"},
                {"Type", "Movie" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BOGE3N2QxN2YtM2ZlNS00MWIyLWE1NDAtYWFlN2FiYjY1MjczXkEyXkFqcGdeQXVyOTUwNzc0ODc@._V1_SX300.jpg" }
            },
            new Dictionary<String, String>
            {
                {"imdbID", "tt10919420" },
                {"Title", "Squid Game" },
                {"Year",  "2021–"},
                {"Type", "Series" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BYWE3MDVkN2EtNjQ5MS00ZDQ4LTliNzYtMjc2YWMzMDEwMTA3XkEyXkFqcGdeQXVyMTEzMTI1Mjk3._V1_SX300.jpg" }
            },
            new Dictionary<String, String>
            {
                {"imdbID", "tt0470752" },
                {"Title", "Ex Machina" },
                {"Year",  "2014"},
                {"Type", "Movie" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BMTUxNzc0OTIxMV5BMl5BanBnXkFtZTgwNDI3NzU2NDE@._V1_SX300.jpg" }
            },
            new Dictionary<String, String>
            {
                {"imdbID", "tt7286456" },
                {"Title", "Joker" },
                {"Year",  "2019"},
                {"Type", "Movies" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BNGVjNWI4ZGUtNzE0MS00YTJmLWE0ZDctN2ZiYTk2YmI3NTYyXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SX300.jpg" }
            },
            new Dictionary<String, String>
            {
                {"imdbID", "tt1285016" },
                {"Title", "The Social Network" },
                {"Year",  "2010"},
                {"Type", "Movie" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BOGUyZDUxZjEtMmIzMC00MzlmLTg4MGItZWJmMzBhZjE0Mjc1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg" }
            },
            new Dictionary<String, String>
            {
                {"imdbID", "tt0211915" },
                {"Title", "Amélie" },
                {"Year",  "2001"},
                {"Type", "Movie" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BNDg4NjM1YjMtYmNhZC00MjM0LWFiZmYtNGY1YjA3MzZmODc5XkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg" }
            },
            new Dictionary<String, String>
            {
                {"imdbID", "tt0468569" },
                {"Title", "The Dark Knight" },
                {"Year",  "2008"},
                {"Type", "Movie" },
                {"Poster", "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg" }
            },
        };
    }
}
