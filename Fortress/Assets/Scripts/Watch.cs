using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Watch : MonoBehaviourPun
{   
    void Update()
    {
        Debug.Log(PhotonNetwork.Time);
    }
}
