using QuizTelegramBot.MessageFormatters;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    public class HardLevelCallBack : CallBackCommand
    {
        public override string CallBackData => "hard";

        public async override void Execute(CallbackQuery callback, TelegramBotClient client)
        {
            await NumberOfQuestionsMessageFormatter.ShowNumberOfQuestionsMessage(callback.Message, client);
            QuizProcessor.QuizAPIParams += "_hard";
        }
    }
}
