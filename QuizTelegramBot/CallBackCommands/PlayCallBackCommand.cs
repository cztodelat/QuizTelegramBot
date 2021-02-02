using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizTelegramBot.CallBackCommands
{
    public class PlayCallBackCommand : CallBackCommand
    {
        public override string CallBackData => "play_quiz";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await Quiz.StartQuiz(message, client);
        }
    }
}
