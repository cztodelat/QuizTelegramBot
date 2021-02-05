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

        public async override void Execute(CallbackQuery callback, TelegramBotClient client)
        {
            await NumberOfQuestionsMessageFormatter.ShowNumberOfQuestionsMessage(callback.Message, client);
            QuizProcessor.QuizAPIParams += "_easy";
        }
    }
}
