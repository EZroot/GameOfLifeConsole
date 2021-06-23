namespace GameOfLifeConsole
{
    public class MapData
    {
        public int GridX { get; set; }
        public int GridY { get; set; }

        int[] data;
        int[] savedData;

        public MapData(int x, int y)
        {
            GridX = x;
            GridY = y;
            data = new int[x * y];
            savedData = new int[x*y];
        }

        public void SetMapData(int x, int y, int input)
        {
            data[x + GridX * y] = input;
        }

        public int GetMapData(int x, int y)
        {
            return savedData[x + GridX * y];
        }

        public void SaveData(int[] data)
        {
            System.Array.Copy(data,savedData,data.Length);
        }

        //This needs to check old map
        //When all collisions are done for each square in oldmap, set oldmap to new map;
        public void Simulate(int[] map)
        {
            SaveData(map);
            for (int i = 0; i < map.Length; i++)
            {
                int x, y;
                if (i >= GridX)
                {
                    x = ((i) % GridX);
                    y = ((i - x) / GridX);
                }
                else
                {
                    x = i;
                    y = 0;
                }

                int neighbourCounter = 0;
                try
                {
                    //top left and bottom right
                    if (GetMapData(x - 1, y + 1) == 1)
                    {
                        neighbourCounter++;
                    }
                    if (GetMapData(x + 1, y - 1) == 1)
                    {
                        neighbourCounter++;
                    }
                    //top right and bottom left
                    if (GetMapData(x + 1, y + 1) == 1)
                    {
                        neighbourCounter++;
                    }
                    if (GetMapData(x - 1, y - 1) == 1)
                    {
                        neighbourCounter++;
                    }
                    //top and bottom
                    if (GetMapData(x, y + 1) == 1)
                    {
                        neighbourCounter++;
                    }
                    if (GetMapData(x, y - 1) == 1)
                    {
                        neighbourCounter++;
                    }
                    //left and right
                    if (GetMapData(x - 1, y) == 1)
                    {
                        neighbourCounter++;
                    }
                    if (GetMapData(x + 1, y) == 1)
                    {
                        neighbourCounter++;
                    }
                }
                catch (System.IndexOutOfRangeException e)
                {
                }

                if (map[i] == 1)
                {
                    if (neighbourCounter == 2 || neighbourCounter == 3)
                        SetMapData(x, y, 1);
                    else
                        SetMapData(x, y, 0);
                }
                else
                {
                    if (neighbourCounter == 3)
                        SetMapData(x, y, 1);
                }
            }
        }

        public int[] Data()
        {
            return data;
        }
    }
}