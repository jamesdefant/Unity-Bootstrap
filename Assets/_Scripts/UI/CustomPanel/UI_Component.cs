using System.Collections;
using System.Collections.Generic;
using Com.SoulSki.UI;
using UnityEngine;

public abstract class UI_Component : MonoBehaviour
{
    private void Awake()
    {
        CacheReferences();
        SetValues();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if(UI_Styles.Instance.UpdateLive || Application.isEditor)
            SetValues();
    }
#endif

    protected abstract void CacheReferences();
    protected abstract void SetValues();
}
