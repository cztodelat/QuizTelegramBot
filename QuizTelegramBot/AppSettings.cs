using System;

namespace QuizTelegramBot
{
    public static class AppSettings
    {
        public static string Url { get; set; } = $""; //Должна быть ни эта ссылка а ссылка для webhook
        public static string Name { get; set; } = $"Quiz4MeBot"; //Your bot name
        public static string Key { get; set; } = $"{YOUR_TOKEN}";
    }
}
