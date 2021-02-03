using QuizTelegramBot.MessageFormatters;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    public class HardLevelCallBack : CallBackCommand
    {
        public override string CallBackData => "hard";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await NumberOfQuestionsMessageFormatter.ShowNumberOfQuestionsMessage(message, client);
            QuizProcessor.QuizAPIParams += "_hard";
        }
    }
}
