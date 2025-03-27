using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;


public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;

    public void Confirm()
    {
        PlayerPrefs.SetString("Name", inputField.text);

        PhotonNetwork.NickName = PlayerPrefs.GetString("Name");

        gameObject.SetActive(false);
    }
}
