using QuizTelegramBot.MessageFormatters;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    class ThirtyQuestionsCallBack : CallBackCommand
    {
        public override string CallBackData => "30_questions";

        public async override void Execute(CallbackQuery callback, TelegramBotClient client)
        {
            await PlayMessageFormatter.ShowPlayMessage(callback.Message, client);
            QuizProcessor.QuizAPIParams += "_" + CallBackData.Split("_")[0];

            //Gets questions from API
            Quiz.Questions = (await QuizProcessor.LoadQuiz()).Questions;
        }
    }
}
