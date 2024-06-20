using UnityEngine;

public class AnimationPlayerController : MonoBehaviour
{
    private Animator animator;
    private MoveController moveController;
    private bool isPlay = true;
    public bool IsPlay { get => isPlay; set => isPlay = value; }

    void Start()
    {
        moveController = GetComponent<MoveController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsPlay)
        { 
            animator.speed = 1;
            if (!moveController.CanJump) { 
                animator.SetTrigger("jumpTrigger");
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
                animator.SetTrigger("runTrigger");
            } else {
                animator.SetTrigger("idleTrigger"); 
            }
        }
        else
        {
            animator.speed = 0;
        }
    }
}
