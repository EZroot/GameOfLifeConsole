using System;
using System.Threading;

namespace GameOfLifeConsole
{
    public static class Log
    {
        public static void Debug(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("["+getTime()+"] "+text);
            Console.ResetColor();
        }

        public static void Write(string text)
        {
            Console.WriteLine("["+getTime()+"] "+text);
        }

        public static void Write(int x, int y, string text)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(text);
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        public static void Wait(int milisec)
        {
            Thread.Sleep(milisec);
        }

        private static string getTime()
        {
            return DateTime.Now.ToString("h:mm:ss tt");
        }
    }
}