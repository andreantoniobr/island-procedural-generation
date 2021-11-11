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

    private void Start()
    {
        if (isRandomSeed)
        {
            seed = GenerateRandomSeed();
        }

        GenerateMap();
    }

    private void GenerateMap()
    {
        Tile[] map = MapData.GenerateMapData(islandWidth, islandHeight, mapWidth, mapHeight, seed, grassBorderPercent);
    }

    private int GenerateRandomSeed()
    {        
        return Time.time.ToString().GetHashCode();
    }
}
