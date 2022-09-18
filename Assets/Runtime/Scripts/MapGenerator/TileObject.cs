using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider2d;
    //public BoxCollider2D BoxCollider2D => boxCollider2d != null ? boxCollider2d : boxCollider2d = GetComponent<BoxCollider2D>();

    public void ActiveCollider2D()
    {
        if (boxCollider2d != null && !boxCollider2d.enabled)
        {
            boxCollider2d.enabled = true;
        }
    }
}
