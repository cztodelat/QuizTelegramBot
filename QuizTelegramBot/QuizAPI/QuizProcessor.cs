using System;
using QuizTelegramBot.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizTelegramBot
{
    public class QuizProcessor
    {
        public static async Task<QuizModel> LoadQuiz(string category)
        {
            string url = $"https://opentdb.com/api.php?amount=10&category={category}&difficulty=easy&type=multiple";

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
    }
}
