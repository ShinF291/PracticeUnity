using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;
using UniRx;
using MamoriOfChikyu.Result;

public class ResultView : MonoBehaviour
{

    [SerializeField]
    GameObject _ResultPanelObject; //GameObject以外の実装

    [SerializeField]
    ResultModel _ResultModel;//ToDo

    [SerializeField]
    string _SceneTo;

    [SerializeField]
    Text _ThisTimeBP;

    [SerializeField]
    Text _BPHighScore;

    [SerializeField]
    Text _ThisTimeUFOScore;

    [SerializeField]
    Image _GameOverImage;

    [SerializeField]
    GameOverImage _ScriptableGameOverImage;

    [SerializeField]
    int _GameOverBP;

    [SerializeField]
    int _GameClearUFOScore;

    private int _ThisTimeBPValue;

    private int _BPHighScoreValue;

    private int _ThisTimeUFOScoreValue;

    public const string SCENE_TO_TAP_SCENE = "Tap_Scene";//ToDo

    public void ResultActive()
    {
        _ResultPanelObject.SetActive (true);
    }

    public void ScoreUpdate(int bp, int ufoScore)
    {
        InitScoreValue(bp,ufoScore);

        if(_ThisTimeBPValue > _BPHighScoreValue)
        {
            BPHighScoreUpdate();
        }

        ScoreTextUpdate();

        if(IsClear())
        {
            ChangeImage(_GameOverImage,_ScriptableGameOverImage.GameClearImageSprite);
        }else
        {
            ChangeImage(_GameOverImage,_ScriptableGameOverImage.GameOverImageSprite);
        }
    }

    public void ChangeToTapScene()
    {
        SceneManager.LoadScene(SCENE_TO_TAP_SCENE);
    }

     public void InitScoreValue(int bp, int ufoScore)
    {
        _ThisTimeBPValue = bp;
        _BPHighScoreValue = _ResultModel.getBPHighScore();
        _ThisTimeUFOScoreValue = ufoScore;
    }

    public void ScoreTextUpdate()
    {
        _ThisTimeBP.text = _ThisTimeBPValue.ToString();
        _ThisTimeUFOScore.text = _ThisTimeUFOScoreValue.ToString();
        _BPHighScore.text = _BPHighScoreValue.ToString();
    }

    public void BPHighScoreUpdate()
    {
        _ResultModel.setBPHighScore(_ThisTimeBPValue);
        _ResultModel.BPHighScoreUpdate();
        _BPHighScoreValue = _ThisTimeBPValue;
    }

    private bool IsClear()
    {
        return _ThisTimeBPValue > _GameOverBP && _ThisTimeUFOScoreValue >= _GameClearUFOScore ;
    }

    public void ChangeImage(Image _Image, Sprite _ChangeImage)
    {
        _Image.sprite = _ChangeImage;
        
    }
}
