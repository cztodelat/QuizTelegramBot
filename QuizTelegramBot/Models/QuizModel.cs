using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTelegramBot.Models
{
    public class QuizModel
    {
        [JsonProperty("results")]
        public List<QuestionModel> Questions { get; private set; }
    }
}
