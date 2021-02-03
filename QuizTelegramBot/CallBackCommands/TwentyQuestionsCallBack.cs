using QuizTelegramBot.MessageFormatters;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    class TwentyQuestionsCallBack : CallBackCommand
    {
        public override string CallBackData => "20_questions";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            await PlayMessageFormatter.ShowPlayMessage(message, client);
            QuizProcessor.QuizAPIParams += "_" + CallBackData.Split("_")[0];

            //Gets questions from API
            Quiz.Questions = (await QuizProcessor.LoadQuiz()).Questions;
        }
    }
}
