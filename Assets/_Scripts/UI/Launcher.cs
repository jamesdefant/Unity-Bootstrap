using Com.SoulSki.UI;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.SoulSki.Game
{
    public interface ILauncher
    {
        void StartGame();
        void ToggleSettingsPanel(bool show);
        void ToggleLauncherPanel(bool show);
        void QuitToLauncher();
        void QuitToDesktop();
    }
    public class Launcher : MonoBehaviour, ILauncher
    {
        #region Constants
        //-----------------------------------------------

        const string LAUNCHER_SCENE = "LauncherScene";
        const string GAME_SCENE = "GameScene";

        #endregion

        #region Fields
        //-----------------------------------------------

        [SerializeField] GameObject _mainMenuBlocker;       // Menu parent
        [SerializeField] GameObject _settingsMenu;
        [SerializeField] GameObject _modalWindowBlocker;

        [SerializeField] GameObject _launcherMenuButton;
        [SerializeField] GameObject _startGameButton;
        [SerializeField] GameObject _settingsButton;
        [SerializeField] GameObject _quitToLauncherButton;
        [SerializeField] GameObject _cancelButton;

        //[SerializeField] VoidEvent _evt_initializeGame;

        [SerializeField] MultiplayerGameManager _gameManagerReference;
        IGameManager _gameManager;

        ModalWindow _modalWindow;

        public static ILauncher Instance;

        #endregion

        #region Properties
        //-----------------------------------------------

        public ModalWindow ModalWindow => _modalWindow;

        #endregion

        #region Monobehaviour Callbacks
        //-----------------------------------------------

        void Awake()
        {
            //if (Instance != null) return;
            Instance = this;

            _gameManager = _gameManagerReference;
            _modalWindow = GetComponent<ModalWindow>();

            _settingsMenu.transform.localScale = new Vector3(0f, 0f);
            _modalWindowBlocker.SetActive(false);

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(LAUNCHER_SCENE))
            {
                _mainMenuBlocker.SetActive(true);

                _launcherMenuButton.SetActive(false);
                _startGameButton.SetActive(true);
                _settingsButton.SetActive(true);
                _quitToLauncherButton.SetActive(false);
                _cancelButton.SetActive(false);
            }
            else
            {
                _mainMenuBlocker.transform.localScale = new Vector3(0f, 0f);

                _launcherMenuButton.SetActive(true);
                _startGameButton.SetActive(false);
                _settingsButton.SetActive(false);
                _quitToLauncherButton.SetActive(true);
                _cancelButton.SetActive(true);
            }
        }

        #endregion

        #region Public Methods
        //-----------------------------------------------

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

            var scale = GetScale(show);

            LeanTween.value(_settingsMenu, scale.start, scale.end, 0.1f).setOnUpdate(
            (Vector3 newScale) => {
                _settingsMenu.transform.localScale = newScale;
                }
            );
        }



        public void ToggleLauncherPanel(bool show)
        {
            string msg = show ? "Open" : "Close";
            Debug.Log(msg + " Launcher menu");

            var (start, end) = GetScale(show);

            LeanTween.value(_settingsMenu, start, end, 0.1f).setOnUpdate(
            (Vector3 newScale) => {
                _mainMenuBlocker.transform.localScale = newScale;
            });
        }

        public void QuitToLauncher()
        {
            ChangeScene(LAUNCHER_SCENE);
        }
        public void QuitToDesktop()
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

        #endregion

        #region Private Methods
        //-----------------------------------------------

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

        (Vector3 start, Vector3 end) GetScale(bool show)
        {
            Vector3 start = show ? new Vector3(0f, 0f, 0f) : new Vector3(1f, 1f, 1f);
            Vector3 end = show ? new Vector3(1f, 1f, 1f) : new Vector3(0f, 0f, 0f);

            return (start, end);
        }

        #endregion
    }
}