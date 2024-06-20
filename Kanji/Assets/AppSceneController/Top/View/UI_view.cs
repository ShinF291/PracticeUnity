using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

public class UI_view : MonoBehaviour
{

    [SerializeField]
    Text UI_BP;

    [SerializeField]
    Text UI_UFOScore;

    private int BP;

    public static int UFOScore;

    // Start is called before the first frame update
    void Start()
    {
        UFOScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        BP_update(BP);
        UFOScore_update(UFOScore);
    }

    void BP_update(int nowBP){
        UI_BP.text = nowBP.ToString();
    }

    public void SetBP(int ChikyusBP)
    {
        this.BP = ChikyusBP;
    }

    void UFOScore_update(int nowUFOScore){
        UI_UFOScore.text = nowUFOScore.ToString();
    }

}
