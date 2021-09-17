using UnityEngine;

namespace Com.SoulSki.SFX
{
    public class UI_SFX : MonoBehaviour
    {
        AudioSource _audioSource;
        [SerializeField] AudioClip _mouseOverButtonClip;
        [Range(0f, 1.0f)]
        [SerializeField] float _mouseOverButtonVolume = 0.3f;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        public void PlayMouserOverButton()
        {
            _audioSource.PlayOneShot(_mouseOverButtonClip, _mouseOverButtonVolume);
        }
    }
}