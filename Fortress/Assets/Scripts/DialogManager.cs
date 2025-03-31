using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] Transform parentTransform;

    void Start()
    {
        // 이미 저장된 이름이 있으면 닉네임을 불러오고, 없으면 초기화
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("Name")))
        {
            // 처음 실행 시 닉네임을 입력하게 만들거나 초기화
            // 예시: PlayerPrefs.SetString("Name", "DefaultName"); // 디폴트 이름 설정
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if (inputField.text.Length <= 0) return;

            // 저장된 닉네임을 매번 가져와서 사용
            string nickName = PlayerPrefs.GetString("Name");  // 닉네임을 PlayerPrefs에서 가져옴
            string message = inputField.text;

            // 닉네임과 메시지를 같이 보냄
            photonView.RPC("Talk", RpcTarget.All, nickName, message);
        }
    }

    [PunRPC]
    public void Talk(string nickName, string message)
    {
        // prefab을 하나 생성한 다음 text 값을 설정합니다.
        GameObject talk = Instantiate(Resources.Load<GameObject>("Talk"));

        // prefab 오브젝트의 Text 컴포넌트로 접근해서 text의 값을 설정합니다.
        // 닉네임 + 메시지로 표시
        talk.GetComponent<Text>().text = nickName + " : " + message;

        // 스크롤 뷰 - content 오브젝트의 자식으로 등록합니다.
        talk.transform.SetParent(parentTransform);

        // 스케일 깨지는 경우 방지
        talk.transform.localScale = Vector3.one; 

        // 채팅을 입력한 후에도 이어서 입력할 수 있도록 설정합니다.
        inputField.ActivateInputField();

        Canvas.ForceUpdateCanvases();

        // 스크롤의 위치를 초기화합니다.
        scrollRect.verticalNormalizedPosition = 0.0f;

        // inputField의 텍스트를 초기화합니다.
        inputField.text = "";
    }
}

