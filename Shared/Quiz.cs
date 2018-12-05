using System.Collections.Generic;

namespace SharedLib
{
    public class Quiz
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}