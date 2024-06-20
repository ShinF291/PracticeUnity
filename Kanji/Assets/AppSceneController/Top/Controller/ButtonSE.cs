using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSE : MonoBehaviour
{
    AudioClip _AudioClip;
 
    void Start()
    {
        _AudioClip = GetComponent<AudioSource> ().clip;
    }
 
    public void Play()
    {
        GetComponent<AudioSource>().PlayOneShot(_AudioClip);
    }
}
