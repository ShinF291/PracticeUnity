using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

public class GamaStartCountDownModel : MonoBehaviour
{
    [SerializeField]
    int CountDownTime;

    public ReactiveProperty<int> property = new ReactiveProperty<int>();

    Coroutine _CountDownCoroutine;

    private const int WAIT_SECONDS_TIME = 1;

    WaitForSeconds _WaitForSeconds = new WaitForSeconds(WAIT_SECONDS_TIME);//ToDo

    public void StartCountDown()
    {
        _CountDownCoroutine = StartCoroutine(CountDown());

        //StartCoroutine(_CountDownCoroutine);
    }

    public void StopCountDown()
    {
        StopCoroutine(_CountDownCoroutine);
    }

    IEnumerator CountDown()
    {
        property.Value = CountDownTime;


        //for (int i = CountDownTime; i > 0; i--)
        while(true)
        {

            yield return _WaitForSeconds;

            property.Value--;

            //if( property.Value <= 0) break;

            // Debug.Log($"countdown:i: {i}");
            // Debug.Log($"countdown:property.Value: {property.Value}");
        }
    }

}
