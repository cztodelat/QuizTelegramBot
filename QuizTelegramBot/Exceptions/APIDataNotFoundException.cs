using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTelegramBot.Exceptions
{
    
    public class APIDataNotFoundException : Exception
    {
        public APIDataNotFoundException(string message) : base(message)
        {}
    }
}
