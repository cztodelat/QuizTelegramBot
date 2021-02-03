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

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await DifficultyLevelMessageFormatter.ShowDifficultyLevelMessage(message, client);
        }
    }
}
