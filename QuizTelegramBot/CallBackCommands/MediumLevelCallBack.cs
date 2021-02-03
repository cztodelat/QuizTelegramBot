using QuizTelegramBot.MessageFormatters;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    public class MediumLevelCallBack : CallBackCommand
    {
        public override string CallBackData => "medium";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await NumberOfQuestionsMessageFormatter.ShowNumberOfQuestionsMessage(message, client);
            QuizProcessor.QuizAPIParams += "_medium";
        }
    }
}
