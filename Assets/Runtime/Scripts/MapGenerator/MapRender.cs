using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BitwiseTile
{
    public GameObject tile;
    public int bitwiseTileIndex;
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
                GameObject tile = unknownTile;

                int tilePositionX = (int) (y - mapWidth / 2);
                int tilePositionY = (int) (-x + mapHeight / 2);
                //Vector3 tilePosition = new Vector3Int(y , -x , 0);
                Vector3 tilePosition = new Vector3Int(tilePositionX, tilePositionY, 0);

                foreach (BitwiseTile bitwiseTile in bitwiseTiles)
                {
                    if (bitwiseTile.bitwiseTileIndex == tileData.bitwiseTileIndex)
                    {
                        if (bitwiseTile.tile)
                        {
                            tile = bitwiseTile.tile;
                        }
                        break;
                    }
                }

                /*
                if (tileData.terrainType == TerrainType.Water)
                {
                    tile = tileWater;
                }
                else if (tileData.terrainType == TerrainType.Grass)
                {
                    tile = tileGrass;
                }*/

                GameObject tileGameObject = Instantiate(tile, tilePosition, Quaternion.identity, transform);

                //Debug.Log(tileData.terrainType);

                tileGameObject.name = $"Tile:[{x}, {y}]-[{tileData.terrainType}]-Bitwise:{tileData.bitwiseTileIndex}";
            }
        }
    }
}
