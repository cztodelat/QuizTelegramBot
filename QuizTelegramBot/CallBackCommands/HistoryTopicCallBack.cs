using QuizTelegramBot.MessageFormatters;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizTelegramBot.CallBackCommands
{
    public class HistoryTopicCallBack : CallBackCommand
    {
        public override string CallBackData => "23";

        public async override void Execute(CallbackQuery callback, TelegramBotClient client)
        {
            await DifficultyLevelMessageFormatter.ShowDifficultyLevelMessage(callback.Message, client);
            QuizProcessor.QuizAPIParams += $"{CallBackData}";
        }
    }
}
