using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CheckController : MonoBehaviour
{
    private bool isTake;
    private Animator animatorFlag; 
    private AudioSource checkSound;
    private bool isPlay = true;
    public Animator AnimatorFlag { get => animatorFlag; }
    public bool IsTake { get => isTake; set { if (!value) isTake = value; } }

    public bool IsPlay { get => isPlay; set => isPlay = value; }

    void Start()
    {
        IsTake = false;
        animatorFlag = GetComponent<Animator>();
        checkSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isPlay)
        {
            animatorFlag.speed = 1;
        }
        else
        {
            animatorFlag.speed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.name == "Player")
        {
            CheckController[] massChecks = GameObject.Find("CHECKPOINTS").GetComponentsInChildren<CheckController>();
            foreach (CheckController script in massChecks)
            {
                if (!script.Equals(this))
                    script.IsTake = false;
                    script.AnimatorFlag.SetBool("isActive", false);
            }
            if (!this.isTake)
            {
                checkSound.Play();
                isTake = true;
            }
            animatorFlag.SetBool("isActive", true);
        }
    }
}

