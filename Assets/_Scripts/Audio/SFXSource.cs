using System;
using UnityEngine;

namespace Com.SoulSki.SFX
{
    public abstract class SFXSource : ScriptableObject
    {
        protected AudioSource _audioSource;

        public Type RegisterAudioSource(AudioSource audioSource)
        {
            _audioSource = audioSource;
            return this.GetType();
        }
    }
}