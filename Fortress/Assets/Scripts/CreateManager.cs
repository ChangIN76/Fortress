using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CreateManager : MonoBehaviourPunCallbacks
{
   
    [SerializeField] Transform[] transforms;
    
    private void Awake()
    {
        Create();
    }

    public void Create()
    {
        PhotonNetwork.Instantiate
        (
            "Character",
             transforms[Random.Range(0, transforms.Length)].position,
             Quaternion.identity
        );      
    }

 
}
