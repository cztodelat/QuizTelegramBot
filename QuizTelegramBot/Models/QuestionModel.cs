using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;

namespace QuizTelegramBot.Models
{
    public class QuestionModel
    {
        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonProperty("incorrect_answers")]
        private List<string> Answers { get; set; }


        //Formats list of answers into correspond 2D array to bind to keyboardMarkup
        public string[][] GetAnswers()
        {
            CorrectAnswer = HttpUtility.HtmlDecode(CorrectAnswer.Trim());
            if (!Answers.Contains(CorrectAnswer))
            {
                Answers.Add(CorrectAnswer);
            }

            //Shuffle answers sequence
            Answers.Shuffle();

            string[][] answers = new string[Answers.Count][];
            for (int i = 0; i < Answers.Count; i++)
            {
                answers[i] = new string[] { HttpUtility.HtmlDecode(Answers[i].Trim()) };
            }
            return answers;
        }
    }

    //List Extension methods 
    public static class ListExtension
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
