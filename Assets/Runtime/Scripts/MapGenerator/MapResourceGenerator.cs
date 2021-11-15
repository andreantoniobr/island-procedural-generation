using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Resource
{
    public GameObject resource;
    [Range(0, 100)]
    public int resourcePercent;
}

public class MapResourceGenerator : MonoBehaviour
{
    [SerializeField] private Resource[] resources;
    [SerializeField] private Resource[] waterResources;

    public Tile[,] GenerateResources(Tile[,] mapData, int mapSeed)
    {
        int mapWidth = mapData.GetLength(0);
        int mapHeight = mapData.GetLength(1);
        System.Random pseudoRandom = new System.Random(mapSeed.GetHashCode());        

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (mapData[x, y].TerrainType != TerrainType.Water)
                {
                    int resourcesPercent = pseudoRandom.Next(0, 100);
                    GameObject resourceObject = GetResourceFromPercent(resourcesPercent);
                    if (resourceObject != null)
                    {
                        mapData[x, y].resource = resourceObject;
                    }
                }      
            }
        }

        return mapData;
    }    

    private GameObject GetResourceFromPercent(int percent)
    {
        GameObject resourceObject = null;
        foreach (Resource resource in resources)
        {
            if (resource.resourcePercent > percent)
            {
                resourceObject = resource.resource;
                break;
            }
        }

        return resourceObject;
    }
}
