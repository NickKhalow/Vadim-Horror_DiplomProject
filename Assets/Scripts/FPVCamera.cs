using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPVCamera : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 cameraOffset = new Vector3(0f, 1.5f, 0f);
    public float mouseSensitivity = 3.5f;
    public float smoothSpeed = 0.1f;

    private Vector3 currentRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentRotation = playerTransform.eulerAngles; // ���������� ��������� �������� �������� ���������
    }

    void LateUpdate()
    {
        // ������� ������ � ������� ����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        currentRotation.y += mouseX;
        currentRotation.x -= mouseY;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -90f, 90f);

        // ������������ ���� ������ ������ ���������
        Quaternion cameraRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0f);
        transform.rotation = cameraRotation;

        // ���������������� ������ �� ���������� (���������� TransformPoint ��� ��������� ���������� ���������)
        Vector3 targetPosition = playerTransform.position + playerTransform.TransformDirection(cameraOffset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // ������� ��������� � ���� �� �����������, ��� � ������
        playerTransform.rotation = Quaternion.Euler(0f, currentRotation.y, 0f);
    }
}
