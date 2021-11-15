using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderTopTree : MonoBehaviour
{
    [SerializeField] private GameObject topTree;
    private void Awake()
    {
        if (topTree)
        {
            Instantiate(topTree, transform.parent);
        }
    }
}
