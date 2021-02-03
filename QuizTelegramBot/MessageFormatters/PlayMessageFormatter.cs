using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizTelegramBot.MessageFormatters
{
    public static class PlayMessageFormatter
    {
        //List of Play 🎲 buttons
        private static List<InlineKeyboardButton> inlineButtons = new List<InlineKeyboardButton>()
        {
              new InlineKeyboardButton() { Text= "Play 🎲", CallbackData= "play_quiz" },
              new InlineKeyboardButton() { Text= "Play 🎲", CallbackData= "play_quiz" },
              new InlineKeyboardButton() { Text= "Play 🎲", CallbackData= "play_quiz" },
              new InlineKeyboardButton() { Text= "Play 🎲", CallbackData= "play_quiz" },
        };

        public static async Task ShowPlayMessage(Message message, TelegramBotClient client)
        {
            //KeyboardButtons
            InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(inlineButtons);

            await client.SendTextMessageAsync(
                chatId: message.Chat,
                text: "To play game press 👇",
                replyMarkup: inlineKeyboard
                ).ConfigureAwait(false);
        }
    
    }
}
