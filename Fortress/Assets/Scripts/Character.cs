using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Rotation))]
[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviourPun
{
    private Move move;
    private Rotation rotation;
    private Rigidbody rigidBody;

    [SerializeField] private GameObject remoteCamera;
    private GameObject pausePanel;

    private void Awake()
    {
        // 컴포넌트 할당
        move = GetComponent<Move>();
        rotation = GetComponent<Rotation>();
        rigidBody = GetComponent<Rigidbody>();

        // PausePanel 찾기 (비활성화된 오브젝트 포함)
        Pause pause = FindObjectOfType<Pause>(true);
        if (pause != null)
        {
            pausePanel = pause.gameObject;
        }
        else
        {
            Debug.LogWarning("Pause Panel을 찾을 수 없습니다.");
        }
    }

    private void Start()
    {
        DisableCamera();
    }

    private void Update()
    {
        // 내 캐릭터가 아니면 입력 X
        if (!photonView.IsMine) return;

        // ESC 누르면 일시정지 패널 표시
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MouseManager.Instance.SetMouse(true);

            if (pausePanel != null)
                pausePanel.SetActive(true);
        }

        move.OnKeyUpdate();
        rotation.OnMouseX();
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine) return;

        move.OnMove(rigidBody);
        rotation.RotateY(rigidBody);
    }

    /// <summary>
    /// 내 캐릭터일 경우 메인 카메라 비활성화, 다른 캐릭터일 경우 Remote Camera 비활성화
    /// </summary>
    public void DisableCamera()
    {
        if (photonView.IsMine)
        {
            if (Camera.main != null)
                Camera.main.gameObject.SetActive(false);
        }
        else
        {
            if (remoteCamera != null)
                remoteCamera.SetActive(false);
        }
    }
}
