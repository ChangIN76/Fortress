using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Watch : MonoBehaviourPun
{
    [SerializeField] double time;
    [SerializeField] double startTime;

    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] int milliseconds;

    [SerializeField] Text timeText;

    public void Awake()
    {
        timeText = GetComponent<Text>();
        startTime = PhotonNetwork.Time;
    }

    private void Update()
    {
        time += PhotonNetwork.Time - startTime;

        minute = (int)time / 60;
        second = (int)time % 60;
        milliseconds = (int)(time * 100) % 100 ;

        timeText.text = string.Format("{0:D2} : {1:D2} : {2:D2}",minute,second,milliseconds);
    }
}
