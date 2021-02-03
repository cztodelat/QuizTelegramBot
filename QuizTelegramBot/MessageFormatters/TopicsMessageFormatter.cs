using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizTelegramBot.MessageFormatters
{
    public static class TopicsMessageFormatter
    {
        //Dictionary collection with quiz categories <Key - name of category, Value - API number of this category>
        //Add new topics here
        private static Dictionary<string, string> topics = new Dictionary<string, string>()
        {
            { "🏺 History 🏺",  "23"},
            { "🖥️ Science: Computers 🖥️",  "18"},
            { "🥭 Japanice Anime & Manga 🥭",  "31"},
            { "📚 Books 📚",  "10"},
            { "🎬 Film 🎬",  "11"},
            { "🎮 Video Games 🎮",  "15"},
        };

        //Set category buttons in horisontal orientation
        private static InlineKeyboardButton[][] SetInlineTopics()
        {
            int i = 0;
            InlineKeyboardButton[][] inlineKeyboardButtons = new InlineKeyboardButton[topics.Count][];

            foreach (var item in topics)
            {
                inlineKeyboardButtons[i] = new InlineKeyboardButton[]
                {
                    new InlineKeyboardButton() { Text = item.Key, CallbackData = item.Value}
                };
                i++;
            }

            return inlineKeyboardButtons;
        }

        public static async Task ShowInlineTopicsMessage(Message message, TelegramBotClient client)
        {
            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(SetInlineTopics());

            await client.SendTextMessageAsync(
                chatId: message.Chat,
                text: "Choose category 👇",
                replyMarkup: inlineKeyboardMarkup
            ).ConfigureAwait(false);
        }


    }
}
