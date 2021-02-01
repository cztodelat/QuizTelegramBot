using QuizTelegramBot.MessageFormatters;
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

        public override string Name => "/start";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            inlineKeyboardMarkup = new InlineKeyboardMarkup(TopicsMessageFormatter.SetInlineTopics());

            await client.SendTextMessageAsync(
                chatId: message.Chat,
                text: "Hi there\nChoose category 👇",
                replyMarkup: inlineKeyboardMarkup
            ).ConfigureAwait(false);
        }
    }
}
