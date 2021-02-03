using QuizTelegramBot.MessageFormatters;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    public class EasyLevelCallBack : CallBackCommand
    {
        public override string CallBackData => "easy";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await NumberOfQuestionsMessageFormatter.ShowNumberOfQuestionsMessage(message, client);
            QuizProcessor.QuizAPIParams += "_easy";
        }
    }
}
