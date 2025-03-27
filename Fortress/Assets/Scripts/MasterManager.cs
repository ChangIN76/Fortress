using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterManager : MonoBehaviourPunCallbacks
{
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
            if (PhotonNetwork.CurrentRoom != null)
            { 
                PhotonNetwork.Instantiate("Energy", Vector3.zero, Quaternion.identity);
            }

            yield return waitForSeconds;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        StartCoroutine(Create());
    }
}