using PlayFab;
using PlayFab.ClientModels;
using PlayfabTutorial.Scripts.PlayFab;
using TMPro;
using UnityEngine;

namespace FMGames.Playfab.Login {
    public class PasswordRecovery : MonoBehaviour {
        [SerializeField] private TMP_InputField emailInputField;
        [SerializeField] private GameObject window;
        
        public void RecoverPassword() {
            var request = new SendAccountRecoveryEmailRequest {
                Email = emailInputField.text,
                TitleId = PlayFabConstants.TitleID
            };
            
            PlayFabClientAPI.SendAccountRecoveryEmail(request, ResultCallback, ErrorCallback);
        }

        private void ErrorCallback(PlayFabError error) {
            Debug.LogError(error.ErrorMessage);
        }

        private void ResultCallback(SendAccountRecoveryEmailResult result) {
            window.SetActive(false);
            Debug.Log("Please check your email");
        }
    }
}