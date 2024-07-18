using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Common.SoundManager;
using Zenject;
using Appdata;

public class MenuScript : MonoBehaviour
{
    [Inject]
    private SoundManager _SoundManager;

    [Inject]
    private AppData _AppData;

    [SerializeField]
    private AudioClip _BabySe;

    public void OnClickBaby()
    {
        _SoundManager.PlaySe(_BabySe);
    }

    public void OnClickChanegeChikyu()
    {
        _AppData.NextScene = SceneList.Stage_1_Scene;
        this.GoTapScene();
    }

    public void OnClickChanegeRamen()
    {
        _AppData.NextScene = SceneList.RaMEN;
        this.GoTapScene();
    }


    public void GoTapScene()
    {
        SceneManager.LoadScene("Tap_Scene");
    }
    
}
