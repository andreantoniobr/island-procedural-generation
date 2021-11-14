using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaterCollidersController
{
    public static void ActiveWaterColliders(Tile[,] mapData)
    {
        int mapWidth = mapData.GetLength(0);
        int mapHeight = mapData.GetLength(1);

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                //mapData[x, y]
            }
        }
    }
}
