using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizTelegramBot.MessageFormatters
{
    public static class DifficultyLevelMessageFormatter
    {
        //Dictionary collection with quiz difficulty level <Key - name of difficulty level, Value - API name of difficulty level>
        //Add new topics here
        private static Dictionary<string, string> difficultyLevel = new Dictionary<string, string>()
        {
            { "🤗 Easy 🤗",  "easy"},
            { "👍 Medium 👍",  "medium"},
            { "🔥 Hard 🔥",  "hard"},
        };

        //Set difficulty level buttons in horisontal orientation
        public static InlineKeyboardButton[][] SetInlineDifficultyLevel()
        {
            int i = 0;
            InlineKeyboardButton[][] inlineKeyboardButtons = new InlineKeyboardButton[difficultyLevel.Count][];

            foreach (var item in difficultyLevel)
            {
                inlineKeyboardButtons[i] = new InlineKeyboardButton[]
                {
                    new InlineKeyboardButton() { Text = item.Key, CallbackData = item.Value}
                };
                i++;
            }

            return inlineKeyboardButtons;
        }


        public static async Task ShowDifficultyLevelMessage(Message message, TelegramBotClient client)
        {
            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(SetInlineDifficultyLevel());

            await client.SendTextMessageAsync(
                chatId: message.Chat,
                text: "Choose this 🙃 👇",
                replyMarkup: inlineKeyboardMarkup
            ).ConfigureAwait(false);
        }
    }
}
