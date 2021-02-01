using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizTelegramBot.Commands
{
    public class StartCommand : Command
    {
        private InlineKeyboardMarkup inlineKeyboardMarkup;
        //Dictionary collection with quiz categories <Key - name of category, Value - API number of this category>
        private Dictionary<string, string> categories = new Dictionary<string, string>()
        {
            { "History",  "23"},
            { "Science: Computers",  "18"},
            { "Japanice Anime & Manga",  "31"},
            { "Books",  "10"},
            { "Film",  "11"},
            { "Video Games",  "15"},
        };

        public override string Name => "/start";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            inlineKeyboardMarkup = new InlineKeyboardMarkup(SetInlineCategories());

            await client.SendTextMessageAsync(
                chatId: message.Chat,
                text: "Hi there\nChoose category 👇",
                replyMarkup: inlineKeyboardMarkup
            ).ConfigureAwait(false);
        }

        //Set category buttons in horisontal orientation
        private InlineKeyboardButton[][] SetInlineCategories()
        {
            int i = 0;
            InlineKeyboardButton[][] inlineKeyboardButtons = new InlineKeyboardButton[categories.Count][];

            foreach (var item in categories)
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
