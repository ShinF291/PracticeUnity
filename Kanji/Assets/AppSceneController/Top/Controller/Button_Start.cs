using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Start : MonoBehaviour
{

    private int Nagaoshi = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            Nagaoshi++;
        }else if(Nagaoshi != 0){
            Nagaoshi = 0;
        }

        if(Nagaoshi >= 120){
            SceneManager.LoadScene("Stage_1_Scene");
        }
        
    }
}
