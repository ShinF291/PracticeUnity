using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Yen_Glaf : MonoBehaviour
{

    [SerializeField]
    RectTransform rectTran;
    
    void Start()
    {
        rectTran.DOMove (Vector3.one,1.0f).SetLink(gameObject);
    }
}

