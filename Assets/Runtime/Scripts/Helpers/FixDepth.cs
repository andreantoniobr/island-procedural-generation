using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FixDepth : MonoBehaviour 
{
    [SerializeField] private bool fixEveryFrame;
    [SerializeField] private SpriteRenderer spriteRenderer;    
    [SerializeField] private int sortingOrderBase = 0;    
    [SerializeField] private float offset = 0;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer)
        {
            spriteRenderer.sortingLayerName = "Player";
            Fix();            
        }

        if (!fixEveryFrame) {
            Destroy(this);
        }
    }
    
    void LateUpdate()
    {  
        if (spriteRenderer && fixEveryFrame) 
        {
            Fix();
        }
    }

    void Fix() 
    {
        spriteRenderer.sortingOrder = (int)(sortingOrderBase - (transform.position.y + offset) * 10);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), 1f); ;
    }
}
