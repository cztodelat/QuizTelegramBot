using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizTelegramBot.Commands
{
    public class StopQuizCommand : Command
    {
        private ReplyKeyboardRemove keyboardRemove = new ReplyKeyboardRemove();

        public override string Name => "/stop_quiz";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(
                chatId: message.Chat,
                text: "🛑Your quiz was stoped🛑\n" +
                "👇To play new one type👇\n\n" +
                "/start",
                replyMarkup: keyboardRemove           
            ).ConfigureAwait(false);
            Quiz.StopQuiz();
        }
    }
}
