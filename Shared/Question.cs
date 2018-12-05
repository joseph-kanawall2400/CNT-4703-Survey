using System.Collections.Generic;

namespace SharedLib
{
    public class Question
    {
        public string Value { get; set; }
        public int Answer { get; set; }
        public List<string> Options { get; set; } = new List<string>();
    }
}
