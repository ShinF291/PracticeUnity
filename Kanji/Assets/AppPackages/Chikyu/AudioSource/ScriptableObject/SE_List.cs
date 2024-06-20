using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/Create SE_List")]
public class SE_List : ScriptableObject 
{
	public AudioClip _StartWhistle;

	public AudioClip _EndWhistle;

	public AudioClip _Explosion;

	public AudioClip _Explosion2;

	public AudioClip _UfoGet;

	public AudioClip _OnSatellite;

	public AudioClip _SatelliteDestroy;
}