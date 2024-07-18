using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using Appdata;
using UnityEngine.UI;

public class TapSceneController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _Prefabs;

    [Inject] 
    private DiContainer _DiContainer;

    [Inject]
    private AppData _AppData;

    void Awake()
    {
        _DiContainer.InstantiatePrefab(_Prefabs[(int)_AppData.NextScene], this.transform);
    }

}
