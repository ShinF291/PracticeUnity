using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Off_Controller : MonoBehaviour
{
    Button me_button;

    void Start()
    {
        me_button = GetComponent<Button>();
    }

    public void PushedButton(){
        me_button.interactable = false;
    }
}
