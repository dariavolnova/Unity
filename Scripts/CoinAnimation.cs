using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isPlay = true;

    public bool IsPlay { get => isPlay; set => isPlay = value; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsPlay)
        {
            animator.speed = 1;
        }
        else{
            animator.speed = 0;
        }
    }
}
