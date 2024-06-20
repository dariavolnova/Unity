using UnityEngine;

public class bulletController : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10f)]
    private float bulletSpeed;
    private bool bulletRight;
    private bool isPlay = true;
    private Camera playerCamera;
    private SpriteRenderer spriteRenderer;

    public bool IsPlay { get => isPlay; set => isPlay = value; }

    void Start()
    {
        playerCamera = Camera.main;
        bulletRight = GameObject.Find("Player").GetComponent<MoveController>().Flip1;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (bulletRight)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    void Update()
    {
        if (IsPlay)
        {
            transform.Translate(new Vector3((bulletRight ? bulletSpeed : -bulletSpeed) * Time.deltaTime, 0, 0));
            if (playerCamera != null) 
            {
                if (playerCamera.WorldToViewportPoint(transform.position).x < 0 || playerCamera.WorldToViewportPoint(transform.position).x > 1) {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        Destroy(collision.gameObject);
            Destroy(gameObject);
    }
}
