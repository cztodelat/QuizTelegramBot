using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    public abstract class CallBackCommand
    {
        public abstract string CallBackData { get; }

        public abstract void Execute(CallbackQuery callback, TelegramBotClient client);

        public bool Contains(string data)
        {
            return this.CallBackData == data;
        }
    }
}
