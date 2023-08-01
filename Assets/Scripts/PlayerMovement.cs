using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 3f;
    private Rigidbody rb;
    private Transform playerTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = transform;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // �������������� ��������� ����������� ��������� � ����������
        Vector3 moveDirection = playerTransform.TransformDirection(direction);

        // ���������� �������� � ������ ���������� �����������
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
