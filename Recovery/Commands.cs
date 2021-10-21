using System;
using System.Collections.Generic;

namespace Recovery
{
    class Commands
    {
        public static Dictionary<string, string> help = new();
        public static Dictionary<string, Action> mydic = new();
        public void Dictionary()
        {
            help.Add("/help help", "shows commands and what they do");
            help.Add("/help", "help {COMMAND}");
            help.Add("/help back", "Goes to the Main Menu");
            mydic.Add("/back", () => Program.Menu());
        }
        public static void SearchDic(string value)
        {
            if (help.TryGetValue(value, out string result))
            {
                {
                    Console.Write(result);
                }
            }
            else if (mydic.TryGetValue(value, out var result2))
            {
                result2();
            }
        }
    }
}
