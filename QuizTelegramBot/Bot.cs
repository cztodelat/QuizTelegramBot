using QuizTelegramBot.CallBackCommands;
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

            //Add CallBack commands here
            callBackCommands = new List<CallBackCommand>();
            callBackCommands.Add(new PlayCallBackCommand());

            client = new TelegramBotClient(AppSettings.Key) { Timeout = TimeSpan.FromSeconds(10) };
            //await client.SetWebhookAsync(""); Когда настраиваем webhook сделать этот метод асинхронным 

            return client;
        }
    }
}
