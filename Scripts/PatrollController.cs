using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrollController : MonoBehaviour
{
    private bool flip = false;
    private bool stay = false;
    [SerializeField]
    private float speed;
    private Animator animator;
    private SpriteRenderer render;
    private bool isPlay = true;

    public bool IsPlay { get => isPlay; set => isPlay = value; }

    void Start()
    {
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isPlay)
        {
            animator.speed = 1;
            if (!stay)
                transform.Translate(new Vector3(flip ? speed : -speed, 0, 0) * Time.deltaTime);
        }
        else
        {
            animator.speed = 0;
        }
        
    }
    private void Flip()
    {
        render.flipX = flip;
        flip = !flip; 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!stay)
            StartCoroutine(StayDelay());
    }

    IEnumerator StayDelay()
    {
        stay = true;
        animator.SetTrigger("isIdle");
        yield return new WaitForSeconds(2);
        animator.SetTrigger("isRun");
        stay = false;
        Flip();
    }
}
