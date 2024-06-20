using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float powerJump;
    private bool flip = true;
    private bool canJump = false;
    private bool isPlay = true;
    private Rigidbody2D rb;
    private SpriteRenderer render;
    private AudioSource jumpSound;
    private AudioSource walkSound;
    public bool CanJump { get => canJump;  }
    public bool Flip1 { get => flip; }
    public bool IsPlay { get => isPlay; set => isPlay = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        jumpSound = GetComponents<AudioSource>()[0];
        walkSound = GetComponents<AudioSource>()[2];
    }

    void Update()
    {
        if (isPlay)   
        {
            transform.Translate(new Vector2(Input.GetAxis("Horizontal")*speed*Time.deltaTime, 0));
            if (canJump && Input.GetAxis("Jump") > 0)
            {
                canJump = false;
                rb.AddForce(powerJump * Vector2.up, ForceMode2D.Impulse);
                jumpSound.Play();
            }
            if (Input.GetAxis("Horizontal") != 0 && canJump == true)
            {
                if (!walkSound.isPlaying) { walkSound.Play(); }
                walkSound.loop = true;
            }
            else { walkSound.loop = false; }
            if ((flip && Input.GetAxis("Horizontal") < 0) || (!flip && Input.GetAxis("Horizontal") > 0))
                Flip();
        }
    }
    private void Flip()
    {
        render.flipX = flip;
        flip = !flip; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
