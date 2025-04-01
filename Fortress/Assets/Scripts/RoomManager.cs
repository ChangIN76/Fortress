using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField titleinputField;
    [SerializeField] InputField capacityinputField;

    [SerializeField] Transform parentTransform;

    [SerializeField] Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

    private void Start()
    {
        // Photon이 연결되지 않았을 경우에만 연결 시도
        if (PhotonNetwork.NetworkClientState == Photon.Realtime.ClientState.Disconnected)
        {
            PhotonNetwork.ConnectUsingSettings();  // 네트워크 연결 시도
        }
        else
        {
            Debug.LogWarning("이미 연결 중이거나 연결 상태가 다릅니다. 연결을 다시 시도할 수 없습니다.");
        }
    }

    public override void OnConnectedToMaster()
    {
        if (PhotonNetwork.InLobby == false)
        {        
            PhotonNetwork.JoinLobby();

            // 연결이 완료되었으면 로비에 참가합니다.
            Debug.Log("Connected to Master Server!");
        }
    }
    
    public override void OnJoinedLobby()
    {
        Debug.Log("로비 입장 완료");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = byte.Parse(capacityinputField.text);
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(titleinputField.text, roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log(roomList.Count);

        GameObject prefab = null;

        foreach (RoomInfo room in roomList)
        {
            if (room.RemovedFromList == true)
            {
                dictionary.TryGetValue(room.Name, out prefab);
                Destroy(prefab);
                dictionary.Remove(room.Name);
            }
            else
            {
                if (dictionary.ContainsKey(room.Name) == false)
                {
                    GameObject clone = Instantiate(Resources.Load<GameObject>("Room"), parentTransform);
                    clone.GetComponent<Information>().View(room.Name, room.PlayerCount, room.MaxPlayers);
                    dictionary.Add(room.Name, clone);
                }
                else
                {
                    dictionary.TryGetValue(room.Name, out prefab);
                    prefab.GetComponent<Information>().View(room.Name, room.PlayerCount, room.MaxPlayers);
                }
            }
        }
    }
}
