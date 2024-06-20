using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace MamoriOfChikyu.Meteo
{
    public class CharacterPresenter <T> : MonoBehaviour where T : Datas
    {
        public virtual void Init(T Datas)
        {
        }

    }

    public class Datas
    {
    }
}

