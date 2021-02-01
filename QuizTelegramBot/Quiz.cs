using System;
using System.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizTelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizTelegramBot
{
    public static class Quiz
    {
        private static ReplyKeyboardRemove keyboardRemove = new ReplyKeyboardRemove();
        static ReplyKeyboardMarkup keyboardMarkup;

        public static bool IsPlaying { get; set; } = false;
        public static bool IsAnswerCorrect { get; set; } = false;
        public static int Count { get; set; } = 0;

        public static string[][] answers;
        public static List<QuestionModel> Questions { get; set; }
        public static QuestionModel question;


        //Quize logic
        public static async Task Playing(Message message, TelegramBotClient client)
        {
            string result = "";

            if (IsPlaying && IsAnswer(answers, message.Text))
            {
                if (message.Text == question.CorrectAnswer.Trim())
                {
                    result = "Good job!";
                    IsAnswerCorrect = true;
                    Count++;
                }
                else
                {
                    result = "Sorry, but you are wrong :(";
                    IsAnswerCorrect = false;
                }

                await client.SendTextMessageAsync(
                      chatId: message.Chat,
                      text: result).ConfigureAwait(false);
            }

            if (Count == Questions?.Count)
            {
                result = $"You are a big brain 🧠, you have answered all questions 🎉\n" +
                         $"Your score: {Count}\n" +
                         $"Do you want to check your knowledge again?\n" +
                         $"Type: 👇\n\n" +
                         $"/start";

                await client.SendTextMessageAsync(
                     chatId: message.Chat,
                     replyMarkup: keyboardRemove,
                     text: result).ConfigureAwait(false);

                IsPlaying = false;
                return;
            }

            if (IsPlaying && IsAnswerCorrect)
            {
                answers = Questions[Count].GetAnswers();
                keyboardMarkup = answers;
                keyboardMarkup.ResizeKeyboard = true;
                question = Questions[Count];

                await client.SendTextMessageAsync(
                chatId: message.Chat,
                text: HttpUtility.HtmlDecode(question.Question),
                replyMarkup: keyboardMarkup
                ).ConfigureAwait(false);
            }
        }


        static bool IsAnswer(string[][] answers, string answer)
        {
            bool result = false;
            for (int i = 0; i < answers.GetLength(0); i++)
            {
                if (Array.IndexOf(answers[i], answer) >= 0)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

    }
}
