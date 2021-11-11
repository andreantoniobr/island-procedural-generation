using UnityEngine;

public enum TerrainType
{
    Unknown = -1,
    Grass,
    Dirt,
    Sand,
    Water
}

public struct Tile
{
    public Vector2 position;
    public TerrainType terrainType;
}

public static class MapData
{
    public static Tile[] GenerateMapData(int islandWidth, int islandHeight, int mapWidth, int mapHeight, int seed, int grassBorderPercent)
    {
        if (islandWidth > mapWidth)
        {
            mapWidth = islandWidth;
        }

        if (islandHeight > mapHeight)
        {
            mapHeight = islandHeight;
        }

        Tile[] mapData = new Tile[mapWidth * mapHeight];

        Tile[] islandTiles = GenerateIsland(islandWidth, islandHeight, seed, grassBorderPercent);

        /*
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {

            }

        }
        */

        int tilesToBorder = (mapWidth - islandWidth) / 2;

        for (int i = 0; i < islandTiles.Length; i++)
        {
            Tile islandTile = islandTiles[i];
        }

        return mapData;
    }

    private static Tile[] GenerateIsland(int islandWidth, int islandHeight, int seed, int grassBorderPercent)
    {
        Tile[] islandData = new Tile[islandWidth * islandHeight];
        for (int x = 0; x < islandWidth; x++)
        {
            for (int y = 0; y < islandHeight; y++)
            {
                int index = x + (y * islandWidth);
                islandData[index] = GenerateRandomIslandTile(x, y, islandWidth, islandHeight, seed, grassBorderPercent);
            }
        }
        return islandData;
    }

    private static Tile GenerateRandomIslandTile(int x, int y, int width, int height, int seed, int grassBorderPercent)
    {
        Tile tile;
        tile.position.x = x;
        tile.position.y = y;
        tile.terrainType = TerrainType.Grass;

        if (IsBorder(x, y, width, height))
        {
            System.Random pseudoRandom = new System.Random(seed.GetHashCode());
            if (pseudoRandom.Next(0, 100) < grassBorderPercent)
            {
                tile.terrainType = TerrainType.Water;
            }
        }
        
        return tile;
    }

    /*
    Ex. Island 5 x 5:
    [0,0] [0,1] [0,2] [0,3] [0,4]
    [1,0] [1,1] [1,2] [1,3] [1,4]
    [2,0] [2,1] [2,2] [2,3] [2,4]
    [3,0] [3,1] [3,2] [3,3] [3,4]
    [4,0] [4,1] [4,2] [4,3] [4,4]
    */
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
