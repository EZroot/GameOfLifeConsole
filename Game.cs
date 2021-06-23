namespace GameOfLifeConsole
{
    public static class Game
    {
        public static void Run()
        {
            MapData mapData = new MapData(120, 30);
            
            mapData.SetMapData(3,5,1);
            mapData.SetMapData(2,7,1);
            mapData.SetMapData(3,7,1);
            mapData.SetMapData(4,7,1);
            mapData.SetMapData(4,6,1);
            
            for(int i = 15; i < 25; i++)
            {
                for(int j = 13; j < 20; j++)
                {
                    mapData.SetMapData(i,j,1);
                }
            }
            Display display = new Display(mapData);

            while (true)
            {
                Log.Wait(200);
                display.DrawScreen(mapData);
                mapData.Simulate(mapData.Data());
            }
        }
    }
}