using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultModel : MonoBehaviour
{
    private int BPHighScore;

    void Awake()
    {
        BPHighScore = PlayerPrefs.GetInt ("BPHighScore", 0);
    }

    public int ThisTimeUFOScore()
    {
        return UI_view.UFOScore;
    }

    public int getBPHighScore()
    {
        return BPHighScore;
    }

    public void setBPHighScore(int NewBPHighScore)
    {
        BPHighScore = NewBPHighScore;
    }

    public void BPHighScoreUpdate()
    {
        PlayerPrefs.SetInt("BPHighScore", BPHighScore);
        PlayerPrefs.Save();
    }
    
}
