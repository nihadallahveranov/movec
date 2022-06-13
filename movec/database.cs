using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movec
{
    class Firebase
    {
        private static bool isHasUser = false;
        private static bool isCorrectUser = false;

        private String myEncoder(String email, String password)
        {
            var encodedEmailBytes = Encoding.UTF8.GetBytes(email);
            var encodedPasswordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(encodedPasswordBytes) + Convert.ToBase64String(encodedEmailBytes);
        }

        #region Sign Up
        public async Task<String> setDataToFireBaseAsync(String email, String password)
        {
            /* Task - Represents an asynchronous operation.
	     * The await keyword is used because the data is set remotely.
	     * The method must be async to use the await keyword.
             * The data in the FireStore is in the form of a map, we need to set it in the form of a map.
             */

            try
            {
                String encodedPasswordText = myEncoder(email, password);

                Constants constants = new Constants();

                DocumentReference documentReference = FirestoreDb.Create(constants.kProjectId)
                                                      .Collection("users").Document(email);

                CollectionReference collectionReference = documentReference.Collection("fav_movies");

                Dictionary<string, object> user = new Dictionary<string, object>
                {
                    { "email", email },
                    { "password", encodedPasswordText },
                    { "userName", email.Split('@')[0] },
                };

                Constants.userName = user["userName"] as String;

                await documentReference.SetAsync(user);

                foreach (var item in constants.kFavouriteMovies)
                {
                    await collectionReference.Document(item["imdbID"]).SetAsync(item);
                }
                
                return "success";
            }
            catch (Exception)
            {
                return "error";
            }
        }
        #endregion Sign Up

        public async Task<String> isHasUserDetectorAsync(String email)
        {
            isHasUser = false;
            Constants constants = new Constants();

            try
            {
                CollectionReference usersRef = FirestoreDb.Create(constants.kProjectId).Collection("users");

                QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Id == email)
                    {
                        isHasUser = true;
                        break;
                    }
                }
                return "success";
            }

            catch (Exception)
            {
                LogInPage.logInPage.sign_up_button.Enabled = true;
                LogInPage.logInPage.email_text.ReadOnly = false;
                LogInPage.logInPage.password_text.ReadOnly = false;
                LogInPage.logInPage.sign_up_lbl.Enabled = true;
                LogInPage.logInPage.message_info_lbl.Text = constants.kMessageInternetInfo;
                return "error";
            }
        }

        #region Sign In
        public async Task<List<Dictionary<String, object>>> getDataFromFireBaseAsync(String email, String password)
        {
            isCorrectUser = false;

            String encodedPasswordText = myEncoder(email, password);

            Constants constants = new Constants();

            List<Dictionary<String, object>> favouriteMovies = new List<Dictionary<string, object>>();

            try
            {
                CollectionReference usersRef = FirestoreDb.Create(constants.kProjectId).Collection("users");

                QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    Dictionary<string, object> documentDictionary = document.ToDictionary();

                    if (documentDictionary["email"] as String == email && documentDictionary["password"] as String == encodedPasswordText) 
                    {
                        isCorrectUser = true;
                        Constants.userName = documentDictionary["userName"] as String;
                        DocumentReference documentReference = usersRef.Document(email);

                        CollectionReference favMoviesRef = documentReference.Collection("fav_movies");

                        QuerySnapshot snapshotAsMovies = await favMoviesRef.GetSnapshotAsync();

                        foreach (DocumentSnapshot documentAsMovie in snapshotAsMovies.Documents)
                        {
                            Dictionary<String, object> documentDictionaryAsMovie = documentAsMovie.ToDictionary();
                            favouriteMovies.Add(documentDictionaryAsMovie);
                        }
                        break;
                    }
                }
                return favouriteMovies;
            }

            catch (Exception)
            {
                return null;
            }
        }
        #endregion Sign In

        public async Task<String> setMovieToFireBaseAsync(String email, String imdbID, String title,
                                                                 String year, String type, String poster)
        {
            Constants constants = new Constants();

            try
            {
                DocumentReference documentReference = FirestoreDb.Create(constants.kProjectId).
                                                  Collection("users").Document(email).
                                                  Collection("fav_movies").Document(imdbID);

                Dictionary<String, object> movie = new Dictionary<String, object>
                {
                    { "imdbID" , imdbID },
                    { "Title", title },
                    { "Year", year },
                    { "Type", type },
                    { "Poster", poster == "N/A" ? constants.kMoviePoster : poster },
                };

                await documentReference.SetAsync(movie); 
                return "success";   
            }

            catch (System.Exception)
            {
                return "error";   
            }
        }

        public async Task<String> deleteMovieFromFireBaseAsync(String email, String imdbID)
        {
            Constants constants = new Constants();
            try
            {
                DocumentReference documentReference = FirestoreDb.Create(constants.kProjectId).
                                                      Collection("users").Document(email).
                                                      Collection("fav_movies").Document(imdbID);

                await documentReference.DeleteAsync();
                return "success";
            }

            catch (Exception)
            {
                return "error";
            }
        }

        public async Task<String> setUserNameAsync(String email, String userName)
        {
            Constants constants = new Constants();
            try
            {
                DocumentReference documentReference = FirestoreDb.Create(constants.kProjectId).Collection("users").Document(email);

                DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> user = documentSnapshot.ToDictionary();

                    Dictionary<String, object> newUserWithUserName = new Dictionary<string, object>
                    {
                        { "email", email },
                        { "password", user["password"] },
                        { "userName", userName },
                    };

                    await documentReference.SetAsync(newUserWithUserName);
                }

                return "success";
            }

            catch (Exception)
            {
                return "error";
            }
        }

        public async Task<String> setPasswordAsync(String email, String password, String newPassword)
        {
            isCorrectUser = false;

            Constants constants = new Constants();

            String encodedPassword = myEncoder(email, password);

            String encodedNewPassword = myEncoder(email, newPassword);

            try
            {
                DocumentReference documentReference = FirestoreDb.Create(constants.kProjectId).Collection("users").Document(email);

                DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> user = documentSnapshot.ToDictionary();

                    if (user["password"] as String == encodedPassword)
                    {
                        isCorrectUser = true;

                        Dictionary<String, object> newUser = new Dictionary<string, object>
                        {
                            { "email", email },
                            { "password", encodedNewPassword },
                            { "userName", Constants.userName },
                        };

                        await documentReference.SetAsync(newUser);
                    }
                }

                return "success";
            }

            catch (Exception)
            {

                return "error";
            }
        }

        public static bool getIsHasUser 
        { 
            get 
            {
                return isHasUser;
            } 
        }

        public static bool getIsCorrectUser
        {
            get
            {
                return isCorrectUser;
            }
        }

        public static String getUserName
        {
            get
            {
                return Constants.userName;
            }
        }
    }
}
