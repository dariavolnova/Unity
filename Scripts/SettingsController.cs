using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField]
    private GameObject menuPanel;
    private bool isPlaying;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        menuPanel.SetActive(false);
    }

    public void ContinueClick()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }
}
