using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderTopTree : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TopTree topTreeModel;
    
    private void Start()
    {
        InstantiateTopTree();
    }

    private void InstantiateTopTree()
    {
        if (topTreeModel)
        {
            TopTree topTree = Instantiate(topTreeModel, transform.parent);
            SetTopTreeLayer(topTree);
        }
    }

    private void SetTopTreeLayer(TopTree topTree)
    {
        if (topTree && spriteRenderer)
        {
            topTree.SetSpriteRenderersLayer(spriteRenderer.sortingLayerName, spriteRenderer.sortingOrder);
        }
    }
}
