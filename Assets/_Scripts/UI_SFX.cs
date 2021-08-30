using UnityEngine;

namespace Com.SoulSki.SFX
{
    public class UI_SFX : MonoBehaviour
    {
        AudioSource _audioSource;
        [SerializeField] AudioClip _mouseOverButtonClip;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        public void PlayMouserOverButton()
        {
            _audioSource.PlayOneShot(_mouseOverButtonClip);
        }
    }
}