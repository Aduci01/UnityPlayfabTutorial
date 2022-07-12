using System;
using PlayFab;
using PlayFab.ClientModels;
using PlayfabTutorial.Scripts.PlayFab;

namespace FMGames.Playfab.Login {
    public class EmailLogin : ILogin {
        private string _username;
        private string _password;

        public EmailLogin(string username, string password) {
            _username = username;
            _password = password;
        }

        public void Login(GetPlayerCombinedInfoRequestParams loginInfoParams, Action<LoginResult> loginSuccess, Action<PlayFabError> loginFailure) {
            var request = new LoginWithPlayFabRequest {
                TitleId = PlayFabConstants.TitleID,
                Password = _password,
                Username = _username,
                InfoRequestParameters = loginInfoParams,
            };

            PlayFabClientAPI.LoginWithPlayFab(request, loginSuccess, loginFailure);
        }
    }
}