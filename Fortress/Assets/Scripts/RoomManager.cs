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

    void Start()
    {
        
    }


}
