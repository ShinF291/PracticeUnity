using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;
using UniRx;
using MamoriOfChikyu.BGM;
using Appdata;

public class TapStart : MonoBehaviour
{
    [SerializeField]
    Text timerText;

    [SerializeField]
    float limitTime;

    [SerializeField]
    Image Ring;

    [Inject]
    private IBGMManager _BGMManager;

    [Inject]
    private AppData _AppData;

    float countUPTime;

    bool RingIsMove;
 
    void Start()
    {
        _BGMManager.ChangeTitleBGM();
        _BGMManager.PlayBGM();

        countUPTime = 0;
        RingIsMove = false;
        timerText.text = countUPTime.ToString("0.00");
    }
 
    
    void Update()
    {
        if(Input.GetMouseButton(0)){
            countUPTime += Time.deltaTime;
            timerText.text = countUPTime.ToString("0.00");

            if(!RingIsMove){
                RingMove(1.0f);
                RingIsMove = true;
            }
            

            if(countUPTime >= limitTime)
            {
                //シーン遷移が何回も呼ばれている
                SceneManager.LoadScene(_AppData.NextScene.ToString());
            }

            return;
        }
        else
        {
            if(countUPTime != 0)
            {
                countUPTime = 0;
                timerText.text = countUPTime.ToString("0.00");
            }

            if(RingIsMove){
                RingRewind();
                RingIsMove = false;
            }
        }

        

    }

    void RingMove(float gauge)
   {
       Ring.DOFillAmount(gauge, limitTime).SetLink(gameObject);
   }

   void RingRewind()
   {
        Ring.DORewind();
   }

}
