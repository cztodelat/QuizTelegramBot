using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizTelegramBot.Commands
{
    public class RemoveKeyboardButtonsCommand : Command
    {
        private ReplyKeyboardRemove keyboardRemove = new ReplyKeyboardRemove();
        public override string Name => "/remove";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(
               chatId: message.Chat,
               text: "Your buttons were removed",
               replyMarkup: keyboardRemove
               );
        }
    }
}
