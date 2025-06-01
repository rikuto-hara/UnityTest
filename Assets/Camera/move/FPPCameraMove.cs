using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // マウスカーソルを画面中央に固定＆非表示
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 上下回転の制限

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // 上下の回転（カメラ）
        playerBody.Rotate(Vector3.up * mouseX); // 左右の回転（プレイヤー本体）
    }
}
