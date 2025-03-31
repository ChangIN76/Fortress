using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    public void OnMouseX()
    {
        // mouseX에 마우스로 입력한 값을 저장합니다.
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }

    public void OnMouseY()
    {
        // mouseX에 마우스로 입력한 값을 저장합니다.
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;
    }

    public void RotateY(Rigidbody rigidBody)
    {
        rigidBody.transform.eulerAngles = new Vector3 (0f, mouseX, 0f);
    }

    public void RotateX(GameObject clone)
    {
        // mouseY의 값을 -65 ~ 65 사이의 값으로 제한합니다.
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        clone.transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }
}
