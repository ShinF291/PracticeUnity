using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MamoriOfChikyu.Meteo
{
[CreateAssetMenu(menuName = "ScriptableObject/Create CharaDataList", fileName="CharaDataList")]
public class CharaDataList : ScriptableObject
{
    public List<CharacterData> CharacterData;
	
}
}
