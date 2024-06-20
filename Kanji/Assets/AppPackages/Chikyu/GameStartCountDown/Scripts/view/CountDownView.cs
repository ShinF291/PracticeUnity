using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

public class CountDownView : MonoBehaviour
{

    [SerializeField]
    Image _TimerImage;

    [SerializeField]
    ContDownImage _CountDownImage;

    [SerializeField]
    int _CountDownTime;

    private int _SpriteNumber;


    void Awake()
    {
        _SpriteNumber = _CountDownTime;
    }

    public void ChangeCountDownImage(int CountDownNumber)
    {
        if( 0 <= CountDownNumber && CountDownNumber < _CountDownImage.ContDownSprite.Length )
        {
            _TimerImage.sprite = _CountDownImage.ContDownSprite[CountDownNumber];
        }
        else 
        {
            Debug.Log($"CountDownView.ChangeCountDownImageの引数には、0以上かつ{_CountDownImage.ContDownSprite.Length}未満の値を渡してください");
        }
        // Debug.Log($"countdown:CountDownNumber: {CountDownNumber}");
        
    }

    //メソッド名：動詞をさきに
    public void CountDownImageNotActive()
    {
        _TimerImage.enabled = false;
    }
    
}
