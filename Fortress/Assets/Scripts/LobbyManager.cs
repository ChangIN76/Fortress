using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] public Dropdown dropDown;

    void Start()
    {
        Dropdown[] dropdowns = FindObjectsOfType<Dropdown>();
        Debug.Log($"씬에 있는 Dropdown 개수: {dropdowns.Length}");

        foreach (Dropdown dropdown in dropdowns)
        {
            Debug.Log($"Dropdown 이름: {dropdown.gameObject.name}, 활성화 상태: {dropdown.gameObject.activeInHierarchy}");
        }

        if (dropDown == null)
        {
            dropDown = FindObjectOfType<Dropdown>();

            if (dropDown == null)
            {
                Debug.LogError("Dropdown을 찾을 수 없습니다. 씬에 Dropdown이 있는지 확인하세요.");
            }
            else
            {
                Debug.Log($"Dropdown이 정상적으로 할당됨: {dropDown.gameObject.name}");
            }
        }
    }

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

    public override void OnJoinedLobby()
    {
        PhotonNetwork.IsMessageQueueRunning = true;

        PhotonNetwork.LoadLevel("Room");
    }
}