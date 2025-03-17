using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Dropdown dropDown;

    public void Connect()
    {
        // 서버에 접속하는 함수
        PhotonNetwork.ConnectUsingSettings();

        PhotonNetwork.LoadLevel("Room");
    }

    public override void OnConnectedToMaster()
    {
        // JoinLobby : 특정 로비를 생성하여 진입하는 함수
        PhotonNetwork.JoinLobby
        (
            new TypedLobby
            (
                dropDown.options[dropDown.value].text,
                LobbyType.Default
            )
        );


    }
}