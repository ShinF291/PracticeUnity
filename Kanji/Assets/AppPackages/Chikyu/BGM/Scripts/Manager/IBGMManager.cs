using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MamoriOfChikyu.BGM
{
    public interface IBGMManager
        {
            void ChangeGameBGM();

            void ChangeTitleBGM();

            void PlayBGM();

            void PauseBGM();

            void UnPauseBGM();

            void StopBGM();
        }
}
