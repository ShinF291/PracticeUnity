using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public void ChangeScene()
    {
        StartCoroutine("Load");
        
    }

    IEnumerator Load(){
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Stage_1_Scene");
    }
}
