using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviourPunCallbacks
{
    public void Resume()
    {
        MouseManager.Instance.SetMouse(false);

        gameObject.SetActive(false);
    }

    public void Exit()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        gameObject.SetActive(false);

        PhotonNetwork.LoadLevel("Room");
    }
}
