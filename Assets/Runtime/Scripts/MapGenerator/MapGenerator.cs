using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;

    [Header("Seed")]
    [SerializeField] private bool isRandomSeed;
    [SerializeField] private int seed;

    [Header("Island Properties")]
    [SerializeField] private int islandWidth;
    [SerializeField] private int islandHeight;
    [Range(0, 100)]
    [SerializeField] private int grassBorderPercent;
    

    private void Awake()
    {
        if (isRandomSeed)
        {
            seed = GenerateRandomSeed();
        }

        //Generate Map Data
        Tile[,] mapData = MapData.GetMapData(islandWidth, islandHeight, mapWidth, mapHeight, seed, grassBorderPercent);

        //GenerateBitwiseTileData
        MapBitwiseTileDataGenerator.GenerateMapBitwiseTileData(mapData);

        //Render Map Data
        MapRender mapRender = GetComponent<MapRender>();
        if (mapRender)
        {
            mapRender.RenderMap(mapData);
        }

        
    }
    
    private int GenerateRandomSeed()
    {        
        return Time.time.ToString().GetHashCode();
    }
}
