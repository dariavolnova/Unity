using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private GameObject[] hearts;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject prefabHeart;
    private int currentHealth;
    private Vector3 spawnPos;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        hearts = new GameObject[maxHealth];
        spawnPos = transform.position;
        ResetHealth();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            if (currentHealth > 0)
            {
                currentHealth -= 1;
                GetComponents<AudioSource>()[3].Play();
                Destroy(hearts[currentHealth]);
            }
            if (currentHealth <= 0) 
            {
                GetComponents<AudioSource>()[4].Play();
                StartCoroutine(DieDelay());
            }
        }
    }

        public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            CheckAddHealth();
        }
    }

    IEnumerator DieDelay()
    {
        animator.SetTrigger("isDie");
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("idleTrigger");
        gameObject.transform.position = GetComponent<SpawnController>().SpawnPos;
        currentHealth = maxHealth;
        ResetHealth();
    }

    private void ResetHealth()
    {
        float sizeHeartWithOffset = 0.35f;
        float size = maxHealth * sizeHeartWithOffset;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] != null)
            {
                Destroy(hearts[i]);
                hearts[i] = null;
            }
        }
        for (int i = 0; i < maxHealth; i++)
        {
            hearts[i] = Instantiate(prefabHeart, Vector3.zero, Quaternion.identity);
            hearts[i].transform.SetParent(transform, false);
            hearts[i].transform.position = new Vector3((transform.position.x - size / 2 + 0.1f) + i * sizeHeartWithOffset, transform.position.y + 1f, transform.position.z);
        }
    }

    public void CheckAddHealth()
    {
        if (currentHealth < maxHealth)
        {
            AddHealth();
        }
    }

    private void AddHealth()
    {
        float sizeHeartWithOffset = 0.35f;
        float size = maxHealth * sizeHeartWithOffset;
        hearts[currentHealth] = Instantiate(prefabHeart, Vector3.zero, Quaternion.identity);
        hearts[currentHealth].transform.SetParent(transform, false);
        hearts[currentHealth].transform.position = new Vector3((transform.position.x - size / 2 + 0.1f) + currentHealth * sizeHeartWithOffset, transform.position.y + 1f, transform.position.z);
        currentHealth++;
    }
}