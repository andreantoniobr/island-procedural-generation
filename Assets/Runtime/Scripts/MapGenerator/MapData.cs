public enum TerrainType
{
    Unknown = -1,
    Water,
    Grass,
    Dirt,
    Sand,    
}

public struct Tile
{
    public TerrainType TerrainType;
    public int BitwiseTileIndex;
    public bool IsColliderEnabled;
}

public static class MapData
{
    public static Tile[,] GetMapData(int islandWidth, int islandHeight, int mapWidth, int mapHeight, int mapSeed, int grassBorderPercent)
    {
        if (mapWidth < islandWidth)
        {
            mapWidth = islandWidth;
        }
        
        if (mapHeight < islandHeight)
        {
            mapHeight = islandHeight;
        }
        
        Tile[,] mapData = GenerateMapData(mapWidth, mapHeight);
        Tile[,] islandData = GenerateIslandData(islandWidth, islandHeight, mapSeed, grassBorderPercent);        
        
        AddIslandDataInMapData(islandWidth, islandHeight, mapWidth, mapHeight, mapData, islandData);
        ActiveWaterColliders(mapWidth, mapHeight, mapData);


        return mapData;
    }

    private static Tile[,] GenerateMapData(int mapWidth, int mapHeight)
    {
        Tile[,] mapData = new Tile[mapWidth, mapHeight];
        FillWaterMapData(mapWidth, mapHeight, mapData);
        return mapData;
    }

    private static void FillWaterMapData(int mapWidth, int mapHeight, Tile[,] mapData)
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (mapData[x, y].TerrainType != TerrainType.Water)
                {
                    mapData[x, y].TerrainType = TerrainType.Water;
                    mapData[x, y].IsColliderEnabled = false;
                }
            }
        }
    }

    private static Tile[,] GenerateIslandData(int islandWidth, int islandHeight, int mapSeed, int grassBorderPercent)
    {
        Tile[,] islandData = new Tile[islandWidth, islandHeight];
        System.Random pseudoRandom = new System.Random(mapSeed.GetHashCode());

        for (int x = 0; x < islandWidth; x++)
        {
            for (int y = 0; y < islandHeight; y++)
            {
                Tile tile = GenerateRandomIslandTile(x, y, islandWidth, islandHeight, grassBorderPercent, pseudoRandom); ;
                if (tile.TerrainType != TerrainType.Unknown)
                {
                    islandData[x, y] = tile;
                }                    
            }
        }
        return islandData;
    }

    private static Tile GenerateRandomIslandTile(int x, int y, int islandWidth, int islandHeight, int grassBorderPercent, System.Random pseudoRandom)
    {
        Tile tile = new Tile
        {
            TerrainType = TerrainType.Grass,
        };

        if (IsBorder(x, y, islandWidth, islandHeight))
        {            
            int tilePercent = pseudoRandom.Next(0, 100);
            if (grassBorderPercent < tilePercent)
            {
                tile.TerrainType = TerrainType.Unknown;
            }
        }
        return tile;
    }

    private static void AddIslandDataInMapData(int islandWidth, int islandHeight, int mapWidth, int mapHeight, Tile[,] mapData, Tile[,] islandTiles)
    {
        //Calculate Border Map
        int tilesToBorder = (mapWidth - islandWidth) / 2;
        for (int x = 0; x < islandWidth; x++)
        {
            for (int y = 0; y < islandHeight; y++)
            {
                int mapX = x + tilesToBorder;
                int mapY = y + tilesToBorder;
                if (mapX >= 0 && mapX < mapWidth && mapY >= 0 && mapY < mapHeight)
                {
                    mapData[mapX, mapY] = islandTiles[x, y];
                }
            }
        }
    }

    private static bool IsBorder(int x, int y, int width, int height)
    {
        bool isBorder = false;
        if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
        {
            isBorder = true;
        }
        return isBorder;
    }

    private static void ActiveWaterColliders(int mapWidth, int mapHeight, Tile[,] mapData)
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (!IsBorder(x, y, mapWidth, mapHeight) && mapData[x, y].TerrainType == TerrainType.Water)
                {
                    if (CountNeighbors(x, y, mapData, TerrainType.Grass) > 0)
                    {
                        mapData[x, y].IsColliderEnabled = true;
                    }
                }
            }
        }
    }

    private static int CountNeighbors(int tileX, int tileY, Tile[,] mapData, TerrainType terrainType)
    {
        int neighbors = 0;
        for (int x = tileX - 1; x < tileX + 1; x++)
        {
            for (int y = tileY - 1; y < tileY + 1; y++)
            {
                if (mapData[x, y].TerrainType == terrainType)
                {
                    neighbors++;
                }
            }
        }

        return neighbors;
    }
}
