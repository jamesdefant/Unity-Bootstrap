using Com.SoulSki.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.SoulSki.Game
{
    public interface IPlayerManager
    {
        void InitializePlayers();
    }

    [CreateAssetMenu(menuName = "TurnBased/PlayerManager")]
    public class PlayerManager : SingletonScriptableObject<PlayerManager>, IPlayerManager
    {
        #region Fields
        //-----------------------------------------------

        
        #endregion

        #region Public Methods
        //-----------------------------------------------
                  
        public void InitializePlayers()
        {
            Debug.LogFormat("PlayerManager initialized");
        }

        #endregion
    }
}