using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Com.SoulSki.UI
{
    public interface IModalWindow
    {
        void Confirm();
        void Decline();
        void Alternate();
        void ShowAsHero(string title, Sprite imageToShow, string message
                        , Action confirmAction);
        void ShowAsHero(string title, Sprite imageToShow, string message
                        , Action confirmAction, Action declineAction);
        void ShowAsPrompt(string title, Sprite imageToShow, string message
                                , string confirmMessage = "OK", string declineMessage = ""
                                , Action confirmAction = null, Action declineAction = null
                                , Action alternateAction = null);
        void ShowAsDialog(string title, string message, string confirmMessage
                                , string declineMessage, Action confirmAction
                                , Action declineAction);
    }
    public class ModalWindow : MonoBehaviour, IModalWindow
    {
        #region Fields
        //-----------------------------------------------

        [SerializeField] Transform _modalWindowBlocker;

        [Header("Header")]
        [SerializeField] Transform _headerArea;
        [SerializeField] TextMeshProUGUI _titleField;

        [Header("Content")]
        [SerializeField] Transform _contentArea;
        [SerializeField] Transform _verticalLayoutArea;
        [SerializeField] Image _heroImage;
        [SerializeField] TextMeshProUGUI _heroText;

        [Space()]
        [SerializeField] Transform _horizontalLayoutArea;
//        [SerializeField] Transform _iconContainer;
        [SerializeField] Image _iconImage;
        [SerializeField] TextMeshProUGUI _iconText;

        [Header("Footer")]
        [SerializeField] Transform _footerArea;
        [SerializeField] Button _confirmButton;
        [SerializeField] TextMeshProUGUI _confirmText;
        [SerializeField] Button _declineButton;
        [SerializeField] TextMeshProUGUI _declineText;
        [SerializeField] Button _alternateButton;
        [SerializeField] TextMeshProUGUI _alternateText;

        Action _onConfirmCallback;
        Action _onDeclineCallback;
        Action _onAlternateCallback;

        #endregion

        #region Public Methods
        //-----------------------------------------------

        public void Confirm()
        {
            Close();
            _onConfirmCallback?.Invoke();
        }
        public void Decline()
        {
            Close();
            _onDeclineCallback?.Invoke();
        }
        public void Alternate()
        {
            Close();
            _onAlternateCallback?.Invoke();
        }

        public void ShowAsHero(string title, Sprite imageToShow, string message
                                , Action confirmAction)
        {
            ShowAsHero(title, imageToShow, message, "Continue", "", confirmAction
                                , null);
        }

        public void ShowAsHero(string title, Sprite imageToShow, string message
                                , Action confirmAction, Action declineAction)
        {
            ShowAsHero(title, imageToShow, message, "Continue", "Back"
                                , confirmAction, declineAction);
        }

        public void ShowAsPrompt(string title, Sprite imageToShow, string message
                                , string confirmMessage = "OK", string declineMessage = ""
                                , Action confirmAction = null, Action declineAction = null
                                , Action alternateAction = null)
        {
            Debug.Log("ModalWindowPanel::ShowAsPrompt()");

            _horizontalLayoutArea.gameObject.SetActive(true);
            _verticalLayoutArea.gameObject.SetActive(false);

            _iconImage.sprite = imageToShow;
            _iconText.text = message;

            ShowModalCommon(title, confirmMessage, declineMessage, confirmAction, declineAction, alternateAction);
        }

        /// <summary>
        /// Show a simple dialog box (no picture)
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        /// <param name="confirmMessage">Confirm message.</param>
        /// <param name="declineMessage">Decline message.</param>
        /// <param name="confirmAction">Confirm action.</param>
        /// <param name="declineAction">Decline action.</param>
        public void ShowAsDialog(string title, string message, string confirmMessage
                                , string declineMessage, Action confirmAction
                                , Action declineAction = null)
        {
            Debug.Log("ModalWindowPanel::ShowAsDialog()");

            _horizontalLayoutArea.gameObject.SetActive(true);
            _iconImage.gameObject.SetActive(false);
            _verticalLayoutArea.gameObject.SetActive(false);

            _iconText.text = message;

            ShowModalCommon(title, confirmMessage, declineMessage, confirmAction, declineAction);
        }


        #endregion

        #region Private Methods
        //-----------------------------------------------

        private void ShowModalCommon(string title, string confirmMessage
                        , string declineMessage, Action confirmAction
                        , Action declineAction = null, Action alternateAction = null)
        {
            // Deselect the buttons
            _confirmButton.Deselect();
            _declineButton.Deselect();
            _alternateButton.Deselect();

            // Hide the header if there's no title
            bool hasTitle = !string.IsNullOrEmpty(title);
            _headerArea.gameObject.SetActive(hasTitle);
            _titleField.text = title;

            _onConfirmCallback = confirmAction;
            _confirmText.text = confirmMessage;

            // Hide the decline button if there's no declineMessage (otherwise have to code default close behaviour)
            bool hasDecline = !string.IsNullOrEmpty(declineMessage);
            _declineText.text = declineMessage;
            _declineButton.gameObject.SetActive(hasDecline);
            _onDeclineCallback = declineAction;

            bool hasAlternate = alternateAction != null;
            _alternateButton.gameObject.SetActive(hasAlternate);
            _onAlternateCallback = alternateAction;

            Show();
        }

        private void ShowAsHero(string title, Sprite imageToShow, string message
                                , string confirmMessage, string declineMessage
                                , Action confirmAction, Action declineAction
                                , Action alternateAction = null)
        {
            Debug.Log("ModalWindowPanel::ShowAsHero()");

            _horizontalLayoutArea.gameObject.SetActive(false);

            _heroImage.sprite = imageToShow;
            _heroText.text = message;

            ShowModalCommon(title, confirmMessage, declineMessage, confirmAction, declineAction, alternateAction);
        }

        private void Show()
        {
            _modalWindowBlocker.gameObject.SetActive(true);
        }

        private void Close()
        {
            _modalWindowBlocker.gameObject.SetActive(false);
        }

        #endregion

    }
}