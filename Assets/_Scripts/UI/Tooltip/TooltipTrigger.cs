using UnityEngine;
using UnityEngine.EventSystems;

namespace Com.SoulSki.UI
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] string _header; 

        [Multiline()]
        [SerializeField] string _content;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            TooltipSystem.Show(_content, _header);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            TooltipSystem.Hide();
        }

        void OnDisable()
        {
            //TooltipSystem.Hide();
        }
    }
}