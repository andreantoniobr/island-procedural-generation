using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;

    [Header("Seed")]
    [SerializeField] private int mapSeed;

    [Header("Island Properties")]
    [SerializeField] private int islandWidth;
    [SerializeField] private int islandHeight;
    [Range(0, 100)]
    [SerializeField] private int grassBorderPercent;    

    private void Awake()
    {
        //Get Map Data
        Tile[,] mapData = MapData.GetMapData(islandWidth, islandHeight, mapWidth, mapHeight, mapSeed, grassBorderPercent);

        //Generate Map BitwiseTile Data
        MapBitwiseTileDataGenerator.GenerateMapBitwiseTileData(mapData);

        //Generate Map Resources
        MapResourceGenerator mapResourceGenerator = GetComponent<MapResourceGenerator>();
        
        if (mapResourceGenerator)
        {
            mapData = mapResourceGenerator.GenerateResources(mapData, mapSeed);
        }

        //Render Map Data
        MapRender mapRender = GetComponent<MapRender>();
        if (mapRender)
        {
            mapRender.RenderMap(mapData);
        }
    }
}
