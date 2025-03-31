using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class NickNameManager : MonoBehaviour
{
    [SerializeField] GameObject nickNamePanel;

    void Start()
    {
        Debug.Log("Stored Name: " + PlayerPrefs.GetString("Name"));  // Name 키로 저장된 값을 확인

        PlayerPrefs.DeleteAll();  // 모든 PlayerPrefs 데이터 삭제
    }

    public void Awake()
    {
        if(string.IsNullOrEmpty(PlayerPrefs.GetString("Name")))
        {
            nickNamePanel.SetActive(true);
        }
        else
        {
            nickNamePanel.SetActive(false);
        }
    }
}