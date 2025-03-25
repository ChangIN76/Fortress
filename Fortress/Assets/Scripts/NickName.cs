using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;



public class NickName : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
       Information(null);
    }

    private void Information(LoginResult result)
    {
        // 로그인 성공 시, 유저의 계정 정보 요청
        GetAccountInfoRequest accountInfoRequest = new GetAccountInfoRequest();

        PlayFabClientAPI.GetAccountInfo(accountInfoRequest, Success, Failure);
    }

    private void Success(GetAccountInfoResult result)
    {
        // 유저의 DisplayName 출력
        photonView.Owner.NickName = result.AccountInfo.Username;

        Debug.Log(result.AccountInfo.Username);
        Debug.Log(photonView.Owner.NickName);
    }

    private void Failure(PlayFabError error)
    {
        Debug.LogError("Error: " + error.GenerateErrorReport());
    }

}
