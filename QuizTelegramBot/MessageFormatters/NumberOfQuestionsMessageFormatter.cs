using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizTelegramBot.MessageFormatters
{
    public static class NumberOfQuestionsMessageFormatter
    {
        //Dictionary collection with number of questions <Key - number of questions, Value - API number of questions>
        //Add new topics here
        private static Dictionary<string, string> numberOfQuestions = new Dictionary<string, string>()
        {
            { "10 questions 🤔",  "10_questions"},
            { "20 questions 🧐",  "20_question"},
            { "30 questions 😵‍💫",  "30_questions"},
        };

        //Set number of questions buttons in horisontal orientation
        private static InlineKeyboardButton[][] SetNumberOfQuestions()
        {
            int i = 0;
            InlineKeyboardButton[][] inlineKeyboardButtons = new InlineKeyboardButton[numberOfQuestions.Count][];

            foreach (var item in numberOfQuestions)
            {
                inlineKeyboardButtons[i] = new InlineKeyboardButton[]
                {
                    new InlineKeyboardButton() { Text = item.Key, CallbackData = item.Value}
                };
                i++;
            }

            return inlineKeyboardButtons;
        }

        public static async Task ShowNumberOfQuestionsMessage(Message message, TelegramBotClient client)
        {
            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(SetNumberOfQuestions());

            await client.SendTextMessageAsync(
                chatId: message.Chat,
                text: "Choose number of questions you want to answer ;)",
                replyMarkup: inlineKeyboardMarkup
            ).ConfigureAwait(false);
        }

    }
}
