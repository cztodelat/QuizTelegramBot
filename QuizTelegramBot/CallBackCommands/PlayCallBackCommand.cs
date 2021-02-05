using QuizTelegramBot.Exceptions;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace QuizTelegramBot.CallBackCommands
{
    public class PlayCallBackCommand : CallBackCommand
    {
        public override string CallBackData => "play_quiz";

        public async override void Execute(CallbackQuery callback, TelegramBotClient client)
        {
            try
            {
                await Quiz.StartQuiz(callback.Message, client);
            }
            catch (APIDataNotFoundException apiEx)
            {
                await client.AnswerCallbackQueryAsync(callback.Id, apiEx.Message, true);
            }
            catch (Exception ex)
            {
                await client.AnswerCallbackQueryAsync(callback.Id, "Something went wrong\nType /start and try again", true);
            }
        }
    }
}
