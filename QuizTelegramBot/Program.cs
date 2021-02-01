﻿using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using QuizTelegramBot.Models;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Generic;


namespace QuizTelegramBot
{
    class Program
    {
        private static InlineKeyboardMarkup InlineKeyboard { get; set; }
        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            //Initialize API client 
            APIHelper.InitializeClient();
            //Gets client
            client = Bot.GetClient();

            //Gets bot name
            var me = client.GetMeAsync().Result;
            Console.WriteLine($"Bot name: {me.FirstName}");

            //Bind events 
            client.OnMessage += BotOnMessageReceived;
            client.OnUpdate += BotOnUpdate;
            client.StartReceiving();

            Console.ReadLine();
            client.StopReceiving();
        }

        private async static void BotOnUpdate(object sender, UpdateEventArgs e)
        {
            var update = e?.Update;
            Message message = update?.Message;
            var callBack = update.CallbackQuery;

            if (callBack != null)
            {
                foreach (var command in Bot.CallbackCommands)
                {
                    if (command.Contains(callBack.Data))
                    {
                        command.Execute(callBack.Message, client);
                        await client.DeleteMessageAsync(callBack.Message.Chat, callBack.Message.MessageId);
                        return;
                    }
                }

                await client.DeleteMessageAsync(callBack.Message.Chat, callBack.Message.MessageId);
                
                //List of Play 🎲 buttons
                List<InlineKeyboardButton> inlineButtons = new List<InlineKeyboardButton>()
                {
                    new InlineKeyboardButton() { Text= "Play 🎲", CallbackData= "play_quiz" },
                    new InlineKeyboardButton() { Text= "Play 🎲", CallbackData= "play_quiz" },
                    new InlineKeyboardButton() { Text= "Play 🎲", CallbackData= "play_quiz" },
                    new InlineKeyboardButton() { Text= "Play 🎲", CallbackData= "play_quiz" },
                };

                //KeyboardButtons
                InlineKeyboard = new InlineKeyboardMarkup(inlineButtons);

                await client.SendTextMessageAsync(
                    chatId: callBack.Message.Chat,
                    text: "To play game press 👇",
                    replyMarkup: InlineKeyboard
                    ).ConfigureAwait(false);

                //Gets questions from API
                Quiz.Questions = await Load(callBack.Data);
            }

        }

        private async static void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e?.Message;
            var commands = Bot.Commands;

            if (message == null || message.Type != MessageType.Text)
            {
                return;
            }

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    return;
                }
            }

            await Quiz.Playing(message, client);

        }


        private static async Task<List<QuestionModel>> Load(string category)
        {
            QuizModel quiz = await QuizProcessor.LoadQuiz(category);
            return quiz.Questions;
        }
    }
}
