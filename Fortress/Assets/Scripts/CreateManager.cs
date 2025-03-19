using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CreateManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        Create();
    }

    public void Create()
    {
        PhotonNetwork.Instantiate
        (
            "Character",
             Vector3.zero,
             Quaternion.identity
        );      
    }
}
