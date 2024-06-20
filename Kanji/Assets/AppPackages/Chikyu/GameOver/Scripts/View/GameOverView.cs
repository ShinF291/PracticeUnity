using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using DG.Tweening;
using UnityEngine.Events;

public class GameOverView : MonoBehaviour
{

    [SerializeField]
    Image _GameOverImage;

    [SerializeField]
    Image _GameOverImageMetsubou;

    [SerializeField]
    int _EndWaitSecond;

    public void PlayGameOverSequence(bool MetsubouOrTimeOver, UnityAction onCompleteAction)
    {
        DOTween.Sequence()
        .AppendCallback(() =>
        {
            if (MetsubouOrTimeOver)
            {
                ActiveMetsubouImage();
            }
            else
            {
                ActiveGameOverImage();
            }
        })
            .AppendInterval(_EndWaitSecond)
            .AppendCallback(() => { onCompleteAction.Invoke(); });
    }


    private void ActiveGameOverImage()//ToDo 名前,public
    {
        _GameOverImage.enabled = true;
    }

    private void ActiveMetsubouImage()//ToDo
    {
        _GameOverImageMetsubou.enabled = true;
    }

}
