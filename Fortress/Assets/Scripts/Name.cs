using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickNameText;

    private void Awake()
    {
        nickNameText = GetComponent<Text>();

        PhotonNetwork.LocalPlayer.NickName = PlayerPrefs.GetString("Name");

        if (photonView.IsMine)
        {
            nickNameText.text = PhotonNetwork.LocalPlayer.NickName;
        }
        else
        {
            nickNameText.text = photonView.Owner.NickName;
        }

        nickNameText.text = PhotonNetwork.LocalPlayer.NickName;
    }
}
