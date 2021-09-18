using UnityEngine;

namespace Com.SoulSki.SFX
{
    [CreateAssetMenu(menuName = "SoulSki/Audio/UI_SFX")]
    public class UI_SFX : ScriptableObject
    {
        AudioSource _audioSource;
        [SerializeField] AudioClip _mouseOverButtonClip;
        [Range(0f, 1.0f)]
        [SerializeField] float _mouseOverButtonVolume = 0.3f;

        public void RegisterAudioSource(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public void PlayMouserOverButton()
        {
            _audioSource.PlayOneShot(_mouseOverButtonClip, _mouseOverButtonVolume);
        }
    }
}