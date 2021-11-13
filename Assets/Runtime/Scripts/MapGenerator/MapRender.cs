using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BitwiseTile
{
    public GameObject tile;
    public int[] bitwiseTileIndexes;
}

public class MapRender : MonoBehaviour
{
    [SerializeField] private GameObject unknownTile;
    [SerializeField] private BitwiseTile[] bitwiseTiles;

    public void RenderMap(Tile[,] mapData)
    {
        int mapWidth = mapData.GetLength(0);
        int mapHeight = mapData.GetLength(1);

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Tile tileData = mapData[x, y]; 
                int tilePositionX = (int)(y - mapWidth / 2);
                int tilePositionY = (int)(-x + mapHeight / 2);
                Vector3 tilePosition = new Vector3Int(tilePositionX, tilePositionY, 0);

                GameObject tile = GetTileObject(tileData.bitwiseTileIndex, bitwiseTiles);
                GameObject tileGameObject = Instantiate(tile, tilePosition, Quaternion.identity, transform);
                tileGameObject.name = $"Tile:[{x}, {y}]-[{tileData.terrainType}]-Bitwise:{tileData.bitwiseTileIndex}";
            }
        }
    }

    private GameObject GetTileObject(int tileDatatIndex, BitwiseTile[] bitwiseTiles)
    {
        GameObject gameObject = unknownTile;        

        foreach (BitwiseTile bitwiseTile in bitwiseTiles)
        {            
            foreach (int bitwiseTileIndex in bitwiseTile.bitwiseTileIndexes)
            {
                if (tileDatatIndex == bitwiseTileIndex)
                {
                    gameObject = bitwiseTile.tile;
                    break;
                }
            }
            if (gameObject != unknownTile)
            {
                break;
            }
        }

        return gameObject;
    }
}
