 public static class MapBitwiseTileDataGenerator
{
    /*
     * Tile Neighbors
     * 
     * [x - 1, y - 1][x - 1, y][x - 1, y + 1]
     * [x    , y - 1][x    , y][x    , y + 1]
     * [x + 1, y - 1][x + 1, y][x + 1, y + 1]
     * 
     * Tile Positions
     * 
     * [northWest][ north ][northEast]
     * [   west  ][ tile  ][   east  ]
     * [southWest][ south ][southEast]
     * 
     * Bitwise Tilemaps
     * 
     * [128][   1][  2]
     * [ 64][x, y][  4]
     * [ 32][  16][  8]
     */

    public static void GenerateMapBitwiseTileData(Tile[,] mapData)
    {
        int mapWidth = mapData.GetLength(0);
        int mapHeight = mapData.GetLength(1);

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (!IsBorder(x, y, mapWidth, mapHeight))
                {
                    mapData[x, y].BitwiseTileIndex = CalculateBitwiseTile(x, y, mapData);
                }                
            }
        }
    }

    private static int CalculateBitwiseTile(int tileX, int tileY, Tile[,] mapData)
    {
        //int bitwiseTile = 0;

        int north = 0;
        int northEast = 0;
        int east = 0;
        int southEast = 0;
        int south = 0;
        int southWest = 0;
        int west = 0;
        int northWest = 0;
        /*
        int[] bitwiseTileArray = new int[]
        {
            northWest,
            northEast,
            north,
            north,
            north,
            north,
            north,

        };
        */
        //int index = 0;
        //check 
        /*
        for (int x = tileX - 1; x < tileX + 2; x++)
        {
            for (int y = tileY - 1; y < tileY + 2; y++)
            {
                if (x != tileX && y != tileY)
                {
                    Debug.Log($"{x}-{y}");
                }
            }
        }
        */
        if (IsGrass(mapData[tileX, tileY]))
        {
            if (IsGrass(mapData[tileX - 1, tileY]))
            {
                north = 1;
            }
            if (IsGrass(mapData[tileX - 1, tileY + 1]))
            {
                northEast = 1;
            }
            if (IsGrass(mapData[tileX, tileY + 1]))
            {
                east = 1;
            }
            if (IsGrass(mapData[tileX + 1, tileY + 1]))
            {
                southEast = 1;
            }
            if (IsGrass(mapData[tileX + 1, tileY]))
            {
                south = 1;
            }
            if (IsGrass(mapData[tileX + 1, tileY - 1]))
            {
                southWest = 1;
            }
            if (IsGrass(mapData[tileX, tileY - 1]))
            {
                west = 1;
            }
            if (IsGrass(mapData[tileX - 1, tileY - 1]))
            {
                northWest = 1;
            }
        }

        if (IsWater(mapData[tileX, tileY]) && IsGrass(mapData[tileX - 1, tileY]))
        {
            if (IsGrass(mapData[tileX - 1, tileY]))
            {
                north = 1000;
            }
            if (IsGrass(mapData[tileX - 1, tileY + 1]))
            {
                northEast = 1000;
            }
            if (IsGrass(mapData[tileX - 1, tileY - 1]))
            {
                northWest = 1000;
            }
        }

        int bitwiseTile = north + northEast * 2 + east * 4 + southEast * 8 + south * 16 + southWest * 32 + west * 64 + northWest * 128;

        return bitwiseTile;
    }

    private static bool IsGrass(Tile tile)
    {
        return IsTerrainType(tile, TerrainType.Grass);
    }

    private static bool IsWater(Tile tile)
    {
        return IsTerrainType(tile, TerrainType.Water);
    }

    private static bool IsTerrainType(Tile tile, TerrainType terrainType)
    {
        bool isTerrainType = false;
        if (tile.TerrainType == terrainType)
        {
            isTerrainType = true;
        }

        return isTerrainType;
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
}
