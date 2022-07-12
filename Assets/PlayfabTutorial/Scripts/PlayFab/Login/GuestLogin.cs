using System;
using System.Text;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace FMGames.Playfab.Login {
    public class GuestLogin : ILogin {
        public void Login(GetPlayerCombinedInfoRequestParams loginInfoParams, Action<LoginResult> loginSuccess,
            Action<PlayFabError> loginFailure) {
            string guestCustomID;
            string guestID;

            if (!PlayerPrefs.HasKey("GUEST_ID")) {
                StringBuilder sb = new StringBuilder("guest://");
                System.Random rnd = new System.Random();
                guestID = rnd.Next(100000, 1000000).ToString();

                sb.Append(guestID);
                sb.Append("/");
                sb.Append(DateTime.UtcNow.ToString());

                guestCustomID = sb.ToString();

                PlayerPrefs.SetString("GUEST_ID", guestCustomID);
            } else guestCustomID = PlayerPrefs.GetString("GUEST_ID");

            var request = new LoginWithCustomIDRequest {
                CustomId = guestCustomID,
                CreateAccount = true,
                InfoRequestParameters = loginInfoParams,
            };

            PlayFabClientAPI.LoginWithCustomID(request, loginSuccess, loginFailure);
        }
    }
}