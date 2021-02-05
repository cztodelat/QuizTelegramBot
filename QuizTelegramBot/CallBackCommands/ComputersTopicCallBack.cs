using QuizTelegramBot.MessageFormatters;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    public class ComputersTopicCallBack : CallBackCommand
    {
        public override string CallBackData => "18";

        public async override void Execute(CallbackQuery callback, TelegramBotClient client)
        {
            await DifficultyLevelMessageFormatter.ShowDifficultyLevelMessage(callback.Message, client);
            QuizProcessor.QuizAPIParams += $"{CallBackData}";
        }
    }
}
