using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickNameManager : MonoBehaviour
{
    private void Awake()
    {
        SetUserName("ChangIN");
    }

    // 디스플레이 네임 업데이트 함수
    private void SetUserName(string newDisplayName)
    {
        // 디스플레이 네임을 변경하는 요청 객체 생성
        UpdateUserTitleDisplayNameRequest request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = newDisplayName // 새로 설정할 디스플레이 네임
        };

        // PlayFab API를 통해 디스플레이 네임 변경 요청
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, Success, Failure);
    }

    // 디스플레이 네임 업데이트 성공 시 호출되는 콜백
    private void Success(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Display Name updated successfully to: " + result.DisplayName);
    }

    // 디스플레이 네임 업데이트 실패 시 호출되는 콜백
    private void Failure(PlayFabError error)
    {
        Debug.LogError("Error updating Display Name: " + error.GenerateErrorReport());
    }
}