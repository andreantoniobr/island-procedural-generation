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
                InstantiateTile(x, y, tileData, tilePosition);
            }
        }
    }

    private void InstantiateTile(int x, int y, Tile tileData, Vector3 tilePosition)
    {
        GameObject tile = GetTileObject(tileData.BitwiseTileIndex, bitwiseTiles);
        if (tile)
        {
            GameObject tileGameObject = Instantiate(tile, tilePosition, Quaternion.identity, transform);
            ActivateWaterCollider(tileData, tileGameObject);
            tileGameObject.name = $"Tile:[{x}, {y}]-[{tileData.TerrainType}]-Bitwise:{tileData.BitwiseTileIndex}";
        }
    }

    private void ActivateWaterCollider(Tile tileData, GameObject tileGameObject)
    {
        if (tileData.IsColliderEnabled == true)
        {
            TileObject tileObject = tileGameObject.GetComponent<TileObject>();
            if (tileObject)
            {
                tileObject.ActiveCollider2D();
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
