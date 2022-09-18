using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Transform minPositionX;
    [SerializeField] private Transform maxPositionX;
    [SerializeField] private Transform minPositionY;
    [SerializeField] private Transform maxPositionY;
    
    [SerializeField] private float speed = 5f;
    [SerializeField] private float armrX = 5f;
    [SerializeField] private float armrY = 5f;

    private void FixedUpdate()
    {
        if (playerController && minPositionX && maxPositionX && minPositionY && maxPositionY)
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = playerController.transform.position;
            
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPositionX.position.x + armrX, maxPositionX.position.x - armrX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPositionY.position.y + armrY, maxPositionY.position.y - armrY);
            transform.position = Vector2.Lerp(currentPosition, targetPosition, speed * Time.fixedDeltaTime);
        }        
    }

    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
    }
}
