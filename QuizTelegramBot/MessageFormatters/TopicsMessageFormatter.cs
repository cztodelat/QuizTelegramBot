using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizTelegramBot.MessageFormatters
{
    public static class TopicsMessageFormatter
    {
        //Dictionary collection with quiz categories <Key - name of category, Value - API number of this category>
        private static Dictionary<string, string> topics = new Dictionary<string, string>()
        {
            { "History",  "23"},
            { "Science: Computers",  "18"},
            { "Japanice Anime & Manga",  "31"},
            { "Books",  "10"},
            { "Film",  "11"},
            { "Video Games",  "15"},
        };

        //Set category buttons in horisontal orientation
        public static InlineKeyboardButton[][] SetInlineTopics()
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



    }
}
