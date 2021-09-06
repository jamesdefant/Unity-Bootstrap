using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.SoulSki.Game
{

    public class Launcher : MonoBehaviour
    {
        const string LAUNCHER_SCENE = "LauncherScene";
        const string GAME_SCENE = "GameScene";

        [SerializeField] GameObject _blocker;       // Menu parent
        [SerializeField] GameObject _settingsMenu;

        [SerializeField] GameObject _launcherMenuButton;
        [SerializeField] GameObject _startGameButton;
        [SerializeField] GameObject _settingsButton;
        [SerializeField] GameObject _quitToLauncherButton;
        [SerializeField] GameObject _cancelButton;


        [SerializeField] VoidEvent _evt_initializeGame;

        [SerializeField] MultiplayerGameManager _gameManagerReference;
        IGameManager _gameManager;

        void Awake()
        {
            _gameManager = _gameManagerReference;

            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName(LAUNCHER_SCENE))
            {
                _blocker.SetActive(true);
                _settingsMenu.SetActive(false);

                _launcherMenuButton.SetActive(false);
                _startGameButton.SetActive(true);
                _settingsButton.SetActive(true);
                _quitToLauncherButton.SetActive(false);
                _cancelButton.SetActive(false);
            }
            else
            {
                _blocker.SetActive(false);
                _settingsMenu.SetActive(false);

                _launcherMenuButton.SetActive(true);
                _startGameButton.SetActive(false);
                _settingsButton.SetActive(false);
                _quitToLauncherButton.SetActive(true);
                _cancelButton.SetActive(true);
            }
        }

        public void StartGame()
        {
            Debug.Log("Start Game");
            _gameManager.InitializeGame();

            ChangeScene(GAME_SCENE);
        }

        public void ToggleSettingsPanel(bool show)
        {
            string msg = show ? "Open" : "Close";
            Debug.Log(msg + " Game Settings menu");

            _settingsMenu.SetActive(show);
        }

        //public void OpenLauncherPanel()
        //{
        //    Debug.Log("Open Launcher menu");
        //    _menu.SetActive(true);
        //}
        public void ToggleLauncherPanel(bool show)
        {
            string msg = show ? "Open" : "Close";
            Debug.Log(msg + " Launcher menu");
            _blocker.SetActive(show);
        }

        public void QuitToLauncher()
        {
            ChangeScene(LAUNCHER_SCENE);
        }
        public void QuitToDesktop()
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }



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
    }
}