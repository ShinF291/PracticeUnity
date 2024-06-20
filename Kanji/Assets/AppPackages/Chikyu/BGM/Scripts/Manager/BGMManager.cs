using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MamoriOfChikyu.BGM
{
    public class BGMManager:IBGMManager
    {
        [Inject(Id = "GameAudioSource")]
        private AudioSource _GameAudioSource;

        [Inject(Id = "TitleAudioSource")]
        private AudioSource _TitleAudioSource;

        private BGMList _bGMList = BGMList.GameBGM;

        public void ChangeGameBGM()
        {
            _bGMList = BGMList.GameBGM;
        }

        public void ChangeTitleBGM()
        {
            _bGMList = BGMList.TitleBGM;
        }

        public void PlayBGM()
        {
            this.StopBGM();
            switch(_bGMList)
            {
                case BGMList.GameBGM :
                    if(!_GameAudioSource.isPlaying)
                    {
                        _GameAudioSource.Play();
                    }
                    break;
                case BGMList.TitleBGM :
                    if(!_TitleAudioSource.isPlaying)
                    {
                        _TitleAudioSource.Play();
                    }
                    break;
            }
            
        }

        public void PauseBGM()
        {
            switch(_bGMList)
            {
                case BGMList.GameBGM :
                    if(_GameAudioSource.isPlaying)
                    {
                        _GameAudioSource.Pause();
                    }
                    break;
                case BGMList.TitleBGM :
                    if(!_TitleAudioSource.isPlaying)
                    {
                        _TitleAudioSource.Pause();
                    }
                    break;
            }
            
        }

        public void UnPauseBGM()
        {
            switch(_bGMList)
            {
                case BGMList.GameBGM :
                    if(!_GameAudioSource.isPlaying)
                    {
                        _GameAudioSource.UnPause();
                    }
                    break;
                case BGMList.TitleBGM :
                    if(!_TitleAudioSource.isPlaying)
                    {
                        _TitleAudioSource.UnPause();
                    }
                    break;
            }
            
        }

        public void StopBGM()
        {
            if(_GameAudioSource.isPlaying)
            {
                _GameAudioSource.Stop();
            }

            if(_TitleAudioSource.isPlaying)
            {
                _TitleAudioSource.Stop();
            }
           
        }
    }
}
