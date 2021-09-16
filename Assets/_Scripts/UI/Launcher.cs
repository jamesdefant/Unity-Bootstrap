using Com.SoulSki.UI;
using System.Collections;
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

        [SerializeField] float _panelZoomDuration = 0.1f;

        //[SerializeField] VoidEvent _evt_initializeGame;

        [SerializeField] MultiplayerGameManager _gameManagerReference;
        IGameManager _gameManager;

        IModalWindow _modalWindow;

        public static ILauncher Instance;

        #endregion

        #region Properties
        //-----------------------------------------------

        public IModalWindow ModalWindow => _modalWindow;

        #endregion

        #region Monobehaviour Callbacks
        //-----------------------------------------------

        void Awake()
        {
            //if (Instance != null) return;
            Instance = this;

            _gameManager = _gameManagerReference;
            _modalWindow = GetComponent<ModalWindow>();

            _mainMenuBlocker.SetActive(true);
            _settingsMenu.transform.localScale = new Vector3(0f, 0f);
            _modalWindowBlocker.SetActive(false);

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(LAUNCHER_SCENE))
            {


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
            TooltipSystem.HideImmediate();

            //string msg = show ? "Open" : "Close";
            //Debug.Log(msg + " Game Settings menu");
/*
            var scale = GetScale(show);

            LeanTween.value(_settingsMenu, scale.start, scale.end, 0.1f).setOnUpdate(
            (Vector3 newScale) => {
                _settingsMenu.transform.localScale = newScale;
                }
            );
*/
            TogglePanel(_settingsMenu.transform, show);
        }



        public void ToggleLauncherPanel(bool show)
        {
            TooltipSystem.HideImmediate();

            //string msg = show ? "Open" : "Close";
            //Debug.Log(msg + " Launcher menu");
/*
            var (start, end) = GetScale(show);

            LeanTween.value(_settingsMenu, start, end, 0.1f).setOnUpdate(
            (Vector3 newScale) => {
                _mainMenuBlocker.transform.localScale = newScale;
            });
*/
            TogglePanel(_mainMenuBlocker.transform, show);
        }

        public void QuitToLauncher()
        {
            TooltipSystem.HideImmediate();
            _modalWindow.ShowAsDialog("Quit to Launcher",
                "Do you want to quit the current game?", "Yes", "No", 
                ChangeToLauncherScene, null);              
        }

        public void QuitToDesktop()
        {
            TooltipSystem.HideImmediate();
            _modalWindow.ShowAsDialog("Quit to Desktop",
                "Do you want to quit to the desktop?", "Yes", "No",
                Quit, null);
        }

        #endregion

        #region Private Methods
        //-----------------------------------------------
        void Quit()
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        void ChangeToLauncherScene()
        {
            ChangeScene(LAUNCHER_SCENE);
        }
        void ChangeScene(string sceneName)
        {
            TooltipSystem.HideImmediate();
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

        void TogglePanel(Transform panelTransform, bool show)
        {
            //var (start, end) = GetScale(show);

            //LeanTween.scale(panelTransform.gameObject, end, _panelZoomDuration);

            StartCoroutine(ChangeScale(panelTransform, show));
            //string msg = show ? "Open" : "Close";
            //Debug.Log(msg + panelTransform.gameObject.name);
/*
            var (start, end) = GetScale(show);

            LeanTween.value(_settingsMenu, start, end, 0.1f).setOnUpdate(
            (Vector3 newScale) =>
            {
                panelTransform.localScale = newScale;
            });
*/
        }

        IEnumerator ChangeScale(Transform panelTransform, bool show)
        {
            var (start, end) = GetScale(show);

            float elapsedTime = 0f;

            while (elapsedTime < _panelZoomDuration)
            {
                elapsedTime += Time.deltaTime;
                panelTransform.localScale = Vector3.Lerp(start, end, elapsedTime / _panelZoomDuration);

                //_image.color = Color.Lerp(oldColor, newColor, elapsedTime / _fadeDuration);
                yield return null;
            }
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