using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

namespace Com.SoulSki.UI
{
    public class TabSystem : MonoBehaviour
    {
        [SerializeField] Button _selectedTab;
        [SerializeField] List<Button> _tabs;
        [Header("Tabs must match windows exactly!")]
        [SerializeField] GameObject[] _windows;




        private void Start()
        {
            //if (_tabs.Count > 0)
            Debug.Log("Select third tab");
            SelectTab(2);
            //SelectTab(2);
        }


        public void OnClick_Tab(Button btn)
        {
            // Get the index
            int index = _tabs.IndexOf(btn);

            SelectTab(index);
        }

        void SelectTab(int index)
        {
            if (index < 0 || index > _tabs.Count - 1)
            {
                Debug.LogErrorFormat("Index ({0}) does not exist in the _tabs list.", index);
                return;
            }
            if (index < 0 || index > _windows.Length - 1)
            {
                Debug.LogErrorFormat("Index ({0}) does not exist in the _windows array.", index);
                return;
            }

            Button btn = _tabs[index];
            if(_selectedTab != null)
                _selectedTab.DeSelect();

            _selectedTab = btn;
            btn.Select();

            HideAll();
            _windows[index].SetActive(true);
        }


        void HideAll()
        {
            foreach(GameObject go in _windows)
            {
                go.SetActive(false);
            }
        }
    }
}