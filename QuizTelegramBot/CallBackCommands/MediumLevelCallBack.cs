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

        public async override void Execute(CallbackQuery callback, TelegramBotClient client)
        {
            await NumberOfQuestionsMessageFormatter.ShowNumberOfQuestionsMessage(callback.Message, client);
            QuizProcessor.QuizAPIParams += "_medium";
        }
    }
}
