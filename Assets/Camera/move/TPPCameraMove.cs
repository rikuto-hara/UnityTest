using UnityEngine;

public class TPPCameraMove : MonoBehaviour
{
    public Transform target;        // �Ǐ]����Ώہi�v���C���[�j
    public Vector3 offset = new Vector3(0, 3, -5); // �v���C���[����̑��Έʒu
    public float rotationSpeed = 5f; // �}�E�X��]�̃X�s�[�h

    float currentX = 0f;
    float currentY = 0f;
    public float yMin = -20f;
    public float yMax = 60f;

    void LateUpdate()
    {
        if (target == null) return;

        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentY = Mathf.Clamp(currentY, yMin, yMax);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}
