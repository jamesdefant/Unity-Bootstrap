using UnityEngine;

namespace Com.SoulSki.SFX
{
    public class AudioSystem : MonoBehaviour
    {        
        [SerializeField] UI_SFX _uI_SFX;


        private void Awake()
        {
            _uI_SFX.RegisterAudioSource(GetComponent<AudioSource>());
        }

        public void PlayMouserOverButton()
        {
            _uI_SFX.PlayMouserOverButton();
        }
    }
}