using UnityEngine;
using UnityEngine.EventSystems;

namespace Com.SoulSki.UI
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        const float DELAY_TIME = 1f;

        private static LTDescr _delay;
        [SerializeField] string _header; 

        [Multiline()]
        [SerializeField] string _content;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            _delay = LeanTween.delayedCall(DELAY_TIME, () => 
            {
                TooltipSystem.Show(_content, _header);
            });
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            LeanTween.cancel(_delay.uniqueId);
            TooltipSystem.Hide();
        }
    }
}