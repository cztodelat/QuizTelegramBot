﻿using QuizTelegramBot.CallBackCommands;
using QuizTelegramBot.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace QuizTelegramBot
{

    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commands;
        private static List<CallBackCommand> callBackCommands;

        public static IReadOnlyList<Command> Commands { get => commands.AsReadOnly(); }

        public static IReadOnlyList<CallBackCommand> CallbackCommands { get => callBackCommands.AsReadOnly(); }
        
        public static TelegramBotClient GetClient()
        {
            if (client != null)
            {
                return client;
            }

            //Add commands here
            commands = new List<Command>();
            commands.Add(new StartCommand());
            commands.Add(new RemoveKeyboardButtonsCommand());
            commands.Add(new StopQuizCommand());

            //Add CallBack commands here
            callBackCommands = new List<CallBackCommand>();
            callBackCommands.Add(new PlayCallBackCommand());
            callBackCommands.Add(new HistoryTopicCallBack());
            callBackCommands.Add(new ComputersTopicCallBack());
            callBackCommands.Add(new AnimeAndMangaTopicCallBack());
            callBackCommands.Add(new BooksTopicCallBack());
            callBackCommands.Add(new FilmTopicCallBack());
            callBackCommands.Add(new VideoGamesTopicCallBack());
            callBackCommands.Add(new EasyLevelCallBack());
            callBackCommands.Add(new MediumLevelCallBack());
            callBackCommands.Add(new HardLevelCallBack());
            callBackCommands.Add(new TenQuestionsCallBack());
            callBackCommands.Add(new TwentyQuestionsCallBack());
            callBackCommands.Add(new ThirtyQuestionsCallBack());


            client = new TelegramBotClient(AppSettings.Key) { Timeout = TimeSpan.FromSeconds(10) };
            //await client.SetWebhookAsync(""); Когда настраиваем webhook сделать этот метод асинхронным 

            return client;
        }
    }
}
