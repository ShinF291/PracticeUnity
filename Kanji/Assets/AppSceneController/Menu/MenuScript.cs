using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public void OnClickChanegeTapScene()
    {
        SceneManager.LoadScene("Tap_Scene");
    }
    
}
