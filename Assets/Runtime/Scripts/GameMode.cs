using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField] private PlayerController playerControllerModel;
    [SerializeField] private MapGenerator mapGenerator;
    [SerializeField] private CameraFollow cameraFollow;

    private void Start()
    {
        GenerateMap();
        GetPlayerInstance();
    }

    private void GenerateMap()
    {
        if (mapGenerator)
        {
            mapGenerator.GenerateMap();
        }
    }

    private void GetPlayerInstance()
    {
        if (playerControllerModel)
        {
            PlayerController playerController = Instantiate(playerControllerModel, Vector3.zero, Quaternion.identity);
            SetPlayerInCameraFollow(playerController);
        }
    }

    private void SetPlayerInCameraFollow(PlayerController playerController)
    {
        if (cameraFollow && playerController)
        {
            cameraFollow.SetPlayerController(playerController);
        }
    }
}
