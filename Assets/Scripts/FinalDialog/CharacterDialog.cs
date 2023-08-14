using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterDialog : MonoBehaviour
{
    public string dialogText = "������! ��� ������ ������� � ����������.";
    public GameObject interactionText; // ������ ������ � ��������������

    private bool canInteract = false;
    private DialogManager dialogManager; // ������ �� DialogManager

    private void Start()
    {
        HideInteractionText(); // �������� ������� ��� ������
        dialogManager = FindObjectOfType<DialogManager>(); // ������� DialogManager �� �����
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger entered by player");
            canInteract = true;
            ShowInteractionText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            HideInteractionText();
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");
            StartDialog();
        }
    }

    private void ShowInteractionText()
    {
        interactionText.SetActive(true); // ���������� ������� � ��������������
    }

    private void HideInteractionText()
    {
        interactionText.SetActive(false); // �������� ������� � ��������������
    }

    private void StartDialog()
    {
        if (dialogManager != null)
        {
            dialogManager.ShowDialog(dialogText);
        }
    }
}
