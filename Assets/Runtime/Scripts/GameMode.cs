using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private MapGenerator mapGenerator;

    private void Start()
    {
        if (mapGenerator)
        {
            mapGenerator.GenerateMap();
        }
        if (player)
        {
            Instantiate(player, Vector3.zero, Quaternion.identity);
        }        
    }
}
