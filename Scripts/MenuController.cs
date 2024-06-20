using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField]
    private GameObject menuPanel;
    private bool isPlaying;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        isPlaying = true;
        menuPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPlaying)
        {
            if (menuPanel != null)
            {
                menuPanel.SetActive(true);
                PauseAllAudio();
                m_AudioSource.Pause();
                isPlaying = false;
                SetIsPlay(isPlaying);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !isPlaying)
        {
            if (menuPanel != null)
            {
                menuPanel.SetActive(false);
                m_AudioSource.Play();
                isPlaying = true;
                SetIsPlay(isPlaying);
            }
        }  
    }

 private void PauseAllAudio()
    {
        m_AudioSource.Pause();
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in allAudioSources)
        {
            if (source != m_AudioSource)
            {
                source.Pause();
            }
        }
    }

    private void ResumeAllAudio()
    {
        m_AudioSource.Play();
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in allAudioSources)
        {
            if (source != m_AudioSource)
            {
                source.Play();
            }
        }
    }

    public void SetIsPlay(bool val)
    {
        if (gameObject.transform.parent != null)
        {
            MoveController moveController = gameObject.transform.parent.GetComponent<MoveController>();
            AnimationPlayerController animationPlayerController = gameObject.transform.parent.GetComponent<AnimationPlayerController>();
            ShootController shootController = gameObject.transform.parent.GetComponent<ShootController>();
            CoinAnimation coinAnimation = gameObject.transform.parent.GetComponent<CoinAnimation>();

            if (moveController != null)
            {
                moveController.IsPlay = val;
            }

            if (animationPlayerController != null)
            {
                animationPlayerController.IsPlay = val;
            }

            if (shootController != null)
            {
                shootController.IsPlay = val;
            }

            if (coinAnimation != null) 
            {
                coinAnimation.IsPlay = val;
            }

            GameObject[] massObj = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject obj in massObj)
            {
                PatrollController patrollController = obj.GetComponentInChildren<PatrollController>();
                if (patrollController != null)
                {
                    patrollController.IsPlay = val;
                }
            }

            massObj = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject obj in massObj)
            {
                bulletController bulletController = obj.GetComponent<bulletController>();
                if (bulletController != null)
                {
                    bulletController.IsPlay = val;
                }
            }

            massObj = GameObject.FindGameObjectsWithTag("Checkpoint");
            foreach (GameObject obj in massObj)
            {
                CheckController checkController = obj.GetComponent<CheckController>();
                if (checkController != null)
                {
                    checkController.IsPlay = val;
                }
            }

            massObj = GameObject.FindGameObjectsWithTag("Item");
            foreach (GameObject obj in massObj)
            {
                CoinAnimation coinanimation = obj.GetComponent<CoinAnimation>();
                if (coinanimation != null)
                {
                    coinanimation.IsPlay = val;
                }
            }
        }

    }

    public void ContinueClick()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }

        if (m_AudioSource != null)
        {
            m_AudioSource.Play();
        }
        isPlaying = true;
        SetIsPlay(isPlaying);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
