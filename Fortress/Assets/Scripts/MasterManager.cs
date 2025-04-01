using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterManager : MonoBehaviourPunCallbacks
{    
    [SerializeField] int count = 0;
    [SerializeField] Transform [ ] transforms;
    [SerializeField] GameObject [ ] energyList;

    [SerializeField] WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());
        }
    }
    IEnumerator Create()
    {
        while (true)
        {
            if (PhotonNetwork.CurrentRoom != null && energyList[count] == null)
            { 
                energyList[count] = PhotonNetwork.InstantiateRoomObject("Energy", transforms[count].position, Quaternion.identity);

                count = (count + 1) & energyList.Length;
            }

            yield return waitForSeconds;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        StartCoroutine(Create());
    }
 
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            Debug.Log("Game Start");
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
    }
}