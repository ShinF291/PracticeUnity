using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class YenGraph : MonoBehaviour
{
    [SerializeField]
    public GameObject Ring2; //ゲージ部分
    
    public float rate; //数値部分

    void RingMove(float gauge)
   {
       Ring2.GetComponent<Image>().DOFillAmount(gauge, 1.0f);
   }
}
