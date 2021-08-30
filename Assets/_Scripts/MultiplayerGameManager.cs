using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.SoulSki.Game
{

    public interface IGameManager
    {
        void InitializeGame();
    }

    [CreateAssetMenu(menuName = "TurnBased/MultiplayerGameManager")]
    public class MultiplayerGameManager : ScriptableObject, IGameManager
    {
        #region Fields
        //-----------------------------------------------

        [SerializeField] PlayerManager _playerManagerReference;
        IPlayerManager _playerManager;

//        const string LAUNCHER_SCENE = "LauncherScene";
//        const string GAME_SCENE = "GameScene";

        #endregion

        #region Public Methods
        //-----------------------------------------------

        public void InitializeGame()
        {
            Debug.AssertFormat(_playerManagerReference != null,
                "Hook up PlayerManager reference in inspector");

            Debug.Log("Initialize Game");
//            ChangeScene(GAME_SCENE);
        }
/*
        public void QuitToLauncher()
        {
            ChangeScene(LAUNCHER_SCENE);
        }
*/
        public void QuitToDesktop()
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

        #endregion

        #region Private Methods
        //-----------------------------------------------
/*
        void ChangeScene(string sceneName)
        {
            string scenePath = "Assets/Scenes/" + sceneName + ".unity";

            //Debug.AssertFormat(SceneUtility.GetBuildIndexByScenePath(scenePath) != -1,
            //    "Scene - {0} is absent from build. Add it to Project Settings", sceneName);

            //SceneManager.LoadScene(sceneName);

            if (SceneUtility.GetBuildIndexByScenePath(scenePath) == -1)            
                Debug.LogFormat("Scene - {0} is absent from build. " +
                    "Add it to Project Settings", sceneName);           
            else
                SceneManager.LoadScene(sceneName);
        } 
*/
        #endregion
    }
}