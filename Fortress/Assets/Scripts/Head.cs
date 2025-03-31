using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotation))]

public class Head : MonoBehaviourPunCallbacks
{
    [SerializeField] Rotation rotation;

    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    void Update()
    {
        if (photonView.IsMine == false) return;

        rotation.OnMouseY();

        rotation.RotateX(gameObject);
    }
}
