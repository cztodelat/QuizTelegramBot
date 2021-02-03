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

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await DifficultyLevelMessageFormatter.ShowDifficultyLevelMessage(message, client);
            QuizProcessor.QuizAPIParams += $"{CallBackData}";
        }
    }
}
