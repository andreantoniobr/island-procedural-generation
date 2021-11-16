using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private Animator animator;    

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (animator && playerController)
        {
            if (playerController.IsWalking)
            {
                animator.SetFloat(PlayerAnimationConstants.InputX, playerController.Movement.x);
                animator.SetFloat(PlayerAnimationConstants.InputY, playerController.Movement.y);
            }            
            animator.SetBool(PlayerAnimationConstants.IsWalking, playerController.IsWalking);
        }
    }
}
