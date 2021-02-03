using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using QuizTelegramBot.MessageFormatters;

namespace QuizTelegramBot.Commands
{
    public class StartCommand : Command
    {
        public override string Name => "/start";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            await TopicsMessageFormatter.ShowInlineTopicsMessage(message, client);
            QuizProcessor.QuizAPIParams = "";
        }
    }
}
