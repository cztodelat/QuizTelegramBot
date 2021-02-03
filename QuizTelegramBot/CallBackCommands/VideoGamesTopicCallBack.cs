using QuizTelegramBot.MessageFormatters;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    public class VideoGamesTopicCallBack : CallBackCommand
    {
        public override string CallBackData => "15";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await DifficultyLevelMessageFormatter.ShowDifficultyLevelMessage(message, client);
            QuizProcessor.QuizAPIParams += $"{CallBackData}";
        }
    }
}
