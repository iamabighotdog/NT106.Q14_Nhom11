using System.Collections.Generic;

namespace FormAppQuyt.Models
{
    public class QuestionData
    {
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public string DapAnDung { get; set; }
        public string DapAnSai1 { get; set; }
        public string DapAnSai2 { get; set; }
        public string DapAnSai3 { get; set; }
        public string ImageBase64 { get; set; }
        public int TimeLimit { get; set; } = 20;
    }

    public class QuizDetailResponse
    {
        public bool ok { get; set; }
        public string message { get; set; }
        public List<QuestionData> questions { get; set; }
    }
}
