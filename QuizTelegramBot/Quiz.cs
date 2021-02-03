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

        static bool IsPlaying { get; set; } = false;
        static bool IsAnswerCorrect { get; set; } = false;
        static int Count { get; set; } = 0;
        private static int Score { get; set; } = 0;
        private static int RightAnswers { get; set; } = 0;

        static string[][] answers;
        public static List<QuestionModel> Questions { get; set; }
        static QuestionModel question;

        //Quize logic
        public static async Task Playing(Message message, TelegramBotClient client)
        {
            string result = "";
            if (!IsPlaying)
            {
                await client.SendTextMessageAsync(
                    chatId: message.Chat,
                    text: "You are not playing!\n" +
                    "If you want to check your knowledge 🧠. Just type 👇\n\n" +
                    "/start"
                    );
                return;
            }

            if (IsAnswer(answers, message.Text))
            {
                if (message.Text == question.CorrectAnswer.Trim())
                {
                    result = "Good job!";
                    IsAnswerCorrect = true;
                    Score++;
                    RightAnswers++;
                }
                else
                {
                    result = "Sorry, but you are wrong :(";
                    IsAnswerCorrect = false;
                }

                Count++;
                await client.SendTextMessageAsync(
                      chatId: message.Chat,
                      text: result).ConfigureAwait(false);

                if (Count == Questions?.Count)
                {
                    SendResult(message, client);
                    return;
                }

                await AskNewQuestion(message, client);

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

        public static void StopQuiz()
        {
            IsPlaying = false;
            IsAnswerCorrect = false;
            Count = 0;
            Score = 0;
            RightAnswers = 0;
        }

        public async static Task StartQuiz(Message message, TelegramBotClient client)
        {
            IsPlaying = true;
            await AskNewQuestion(message, client);
        }

        private static async Task AskNewQuestion(Message message, TelegramBotClient client)
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

        private static async void SendResult(Message message, TelegramBotClient client)
        {
            string newGameMessage = $"Do you want to check your knowledge again?\n" +
                         $"Type: 👇\n\n" +
                         $"/start";


            string result = $"You are a big brain 🧠!\n\n" +
                          $"Your results  🎉\n\n" +
                          $"✅ Correct answers {RightAnswers}\n" +
                          $"❌ Wrong answers {Questions.Count - RightAnswers}\n" +
                          $"🏆 Your score: {Score}\n";

            await client.SendTextMessageAsync(
                 chatId: message.Chat,
                 replyMarkup: keyboardRemove,
                 text: result).ConfigureAwait(false);

            await client.SendTextMessageAsync(
                 chatId: message.Chat,
                 replyMarkup: keyboardRemove,
                 text: newGameMessage).ConfigureAwait(false);

            StopQuiz();
        } 
    }
}
