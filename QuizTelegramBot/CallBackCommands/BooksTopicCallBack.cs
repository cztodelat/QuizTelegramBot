﻿using QuizTelegramBot.MessageFormatters;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    public class BooksTopicCallBack : CallBackCommand
    {
        public override string CallBackData => "10";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await DifficultyLevelMessageFormatter.ShowDifficultyLevelMessage(message, client);
        }
    }
}