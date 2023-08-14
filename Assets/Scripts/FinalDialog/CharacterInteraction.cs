using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public Dialog01 dialog;
    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ���������� ����� �������������� ��� ������� � ���������
            Debug.Log("Trigger entered by player");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �������� ����� �������������� ��� ��������� �� ���������
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �������� ������ ��� ������� ������� "E"
            if (dialogManager != null)
            {
                dialogManager.ShowDialog(dialog.dialogText);
            }
        }
    }
}
