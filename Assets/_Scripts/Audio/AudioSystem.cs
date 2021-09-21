using UnityEngine;

namespace Com.SoulSki.SFX
{
    public class AudioSystem : MonoBehaviour
    {        
        [SerializeField] UI_SFX _uI_SFX;


        private void Awake()
        {
            var audioSource = GetComponent<AudioSource>();

            _uI_SFX.RegisterAudioSource(audioSource);
        }

        public void PlayMouserOverButton()
        {
            _uI_SFX.PlayMouserOverButton();
        }
    }
}