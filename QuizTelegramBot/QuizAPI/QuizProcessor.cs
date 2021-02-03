using System;
using QuizTelegramBot.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizTelegramBot
{
    public class QuizProcessor
    {
        public static string QuizAPIParams { get; set; } = "";

        public static async Task<QuizModel> LoadQuiz()
        {
            var apiData = APIDataFormat();

            string url = $"https://opentdb.com/api.php?amount={apiData.numberOfQuestion}&category={apiData.category}&difficulty={apiData.dyfficultyLevel}&type=multiple";

            //Get JSON Data
            using (HttpResponseMessage responce = await APIHelper.ApiClient.GetAsync(url))
            {
                if (responce.IsSuccessStatusCode)
                {
                    //Deserialize JSON
                    QuizModel quiz = await responce.Content.ReadAsAsync<QuizModel>();

                    return quiz;
                }
                else
                {
                    throw new Exception(responce.ReasonPhrase);
                }
            }
        }

        private static (string category, string dyfficultyLevel, string numberOfQuestion) APIDataFormat ()
        {
            var apiData = QuizAPIParams.Split("_");
            return (apiData[0], apiData[1], apiData[2]);
        }
    }
}
