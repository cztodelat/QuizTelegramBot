using QuizTelegramBot.MessageFormatters;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    public class AnimeAndMangaTopicCallBack : CallBackCommand
    {
        public override string CallBackData => "31";

        public async override void Execute(CallbackQuery callback, TelegramBotClient client)
        {
            await DifficultyLevelMessageFormatter.ShowDifficultyLevelMessage(callback.Message, client);
            QuizProcessor.QuizAPIParams += $"{CallBackData}";
        }
    }
}
