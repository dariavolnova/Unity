using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBullet;
    
    [SerializeField]
    private float shootingDelay;
    private bool canShoot = true;
    private bool isPlay = true;
    private bool flip;
    private AudioSource shootSound;

    public bool IsPlay { get => isPlay; set => isPlay = value; }

    void Start()
    {
        shootSound = GetComponents<AudioSource>()[1];
    }

    void Update()
    {
        if (isPlay)
        {
            flip = GameObject.Find("Player").GetComponent<MoveController>().Flip1;
            if (Input.GetKeyDown(KeyCode.F) && canShoot)
            {
                if (prefabBullet != null)
                {
                    StartCoroutine(DelayBetweenShoot());
                    shootSound.Play();
                    Instantiate(prefabBullet, new Vector3(transform.position.x + (flip ? 1 : -1), transform.position.y, transform.position.z), Quaternion.identity);
                }
            }
        }
    }
    IEnumerator DelayBetweenShoot() {
        canShoot = false;
        yield return new WaitForSeconds(shootingDelay);
        canShoot = true;
    }
}
