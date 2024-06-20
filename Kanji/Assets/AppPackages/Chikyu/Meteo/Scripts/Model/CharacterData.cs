using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MamoriOfChikyu.Meteo
{
[CreateAssetMenu(menuName = "ScriptableObject/Create CaracterData", fileName="CaracterData")]
public class CharacterData : ScriptableObject
{
    public CharacterView CharacterPrefab;
    public CharacterId CharaId;
	public int Atk;
    public float Speed;
    public int CreateTimeSpan;
}
}
