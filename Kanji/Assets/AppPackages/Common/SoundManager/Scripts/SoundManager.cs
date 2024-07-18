using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.SoundManager
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _BgmAudioSource;

        [SerializeField]
        private AudioSource _SeAudioSource;
        
        public void PlayBgm(AudioClip clip)
        {
            if(clip)
            {
                _BgmAudioSource.clip = clip;
                _BgmAudioSource.Play();
            }
        }

        public void StopBgm()
        {
            if(_BgmAudioSource.isPlaying)
            {
                _BgmAudioSource.Stop();
            }
        }

        public void PlaySe(AudioClip clip)
        {
            if(clip)
            {
                _SeAudioSource.PlayOneShot(clip);
            }
        }

    }
}
