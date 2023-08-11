using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public GameObject settingPanel;

    public Slider volumeSlider;
    public TMP_Dropdown resolutionDropdown;

    private float originalVolume;
    private int originalResolutionIndex;

    private void Start()
    {
        // ��������� ������������ ��������� ��� �������� ������ ��������
        originalVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        originalResolutionIndex = PlayerPrefs.GetInt("Resolution", 0);

        // ������������� ��������� ��������
        volumeSlider.value = originalVolume;
        resolutionDropdown.value = originalResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettingPanel();
        }
         
    }

    // ����� ��� �������� ������ ��������
    public void ToggleSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    // ����� ��� �������� ������ �������� ��� ���������� ���������
    public void CloseSettingPanel()
    {
        settingPanel.SetActive(false);
    }

    // ����� ��� ��������� ��������� ���������
    public void OnVolumeChanged()
    {
        float volume = volumeSlider.value;
        AudioListener.volume = volume;
    }

    // ����� ��� ��������� ��������� ����������
    public void OnResolutionChanged()
    {
        int selectedIndex = resolutionDropdown.value;
        // ���������� ����� ������ ��� ��������� ���������� ������
        // ������:
        if (selectedIndex == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (selectedIndex == 1)
        {
            Screen.SetResolution(1280, 720, true);
        }

        // ��������� ������ ���������� � ����������
        PlayerPrefs.SetInt("Resolution", selectedIndex);
        PlayerPrefs.Save();
    }

    // ����� ��� ���������� ��������
    public void SaveSettings()
    {
        float volume = volumeSlider.value;
        int resolutionIndex = resolutionDropdown.value;

        // ��������� ���������
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
        PlayerPrefs.Save();

        // ��������� ������ ��������
        settingPanel.SetActive(false);
    }

    // ����� ��� ������ ��������� ��������
    public void CancelSettings()
    {
        // ��������������� ������������ ���������
        volumeSlider.value = originalVolume;
        resolutionDropdown.value = originalResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // ��������� ������ ��������
        settingPanel.SetActive(false);
    }
}
