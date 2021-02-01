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
        private static ReplyKeyboardMarkup keyboardMarkup;

        public async override void Execute(Message message, TelegramBotClient client)
        {
            Quiz.IsPlaying = true;
            Quiz.Count = 0;
            Quiz.IsAnswerCorrect = false;


            Quiz.answers = Quiz.Questions[Quiz.Count]?.GetAnswers();

            //Bind buttons
            keyboardMarkup = Quiz.answers;
            keyboardMarkup.ResizeKeyboard = true;
            Quiz.question = Quiz.Questions[Quiz.Count];

            //Ask a question 
            await client.SendTextMessageAsync(
            chatId: message.Chat,
            text: HttpUtility.HtmlDecode(Quiz.question.Question),
            replyMarkup: keyboardMarkup
            ).ConfigureAwait(false);
        }
    }
}
