using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/Create GameOverImage")]
public class GameOverImage : ScriptableObject 
{
	public Sprite GameOverImageSprite;

	public Sprite GameClearImageSprite;
}