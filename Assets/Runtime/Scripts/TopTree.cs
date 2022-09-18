using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTree : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spriteRenderers;

    public void SetSpriteRenderersLayer(string layerName, int layerOrder)
    {
        int spriteRenderersAmount = spriteRenderers.Length;
        if (spriteRenderersAmount > 0)
        {
            for (int i = 0; i < spriteRenderersAmount; i++)
            {
                SpriteRenderer currentSpriteRenderer = spriteRenderers[i];
                if (currentSpriteRenderer)
                {
                    currentSpriteRenderer.sortingLayerName = layerName;
                    currentSpriteRenderer.sortingOrder = layerOrder;
                }
            }
        }
    }
}
