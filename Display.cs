using System;

namespace GameOfLifeConsole
{
    public class Display
    {
        char[] charMap;

        public Display(int width, int height)
        {
            //we must set windows size to buffer size, or buffer wont work
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            charMap = new char[width * height];

            //Hide cursor 
            Console.CursorVisible = false;
        }

        public Display(MapData data)
        {
            //we must set windows size to buffer size, or buffer wont work
            Console.SetWindowSize(data.GridX, data.GridY);
            Console.SetBufferSize(data.GridX, data.GridY);
            charMap = new char[data.GridX * data.GridY];

            //Hide cursor 
            Console.CursorVisible = false;
        }

        public void DrawScreen(MapData data)
        {
            //Convert 0,1 to string
            //Map need to use a string builder
            int[] map = data.Data();
            int width = data.GridX;

            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                    charMap[i] = '\u2588';
                else
                    charMap[i] = ' ';
            }

            //Draw the map
            Console.SetCursorPosition(0, 0);
            Console.Write(charMap);
        }
    }
}