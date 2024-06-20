using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
     private int score = 0;
     [SerializeField]
     private TMP_Text textMeshPro;

    public int Score { get => score; set => score = value; }

    private void Start()
    {
        textMeshPro.text += Score;
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            StartCoroutine(DelayPickUp(collision));
        }
    }
    IEnumerator DelayPickUp(Collider2D collision)
    {
        Score++;
        textMeshPro.text = textMeshPro.text.Substring(0, textMeshPro.text.Length - 1) + Score;
        AudioSource music = collision.gameObject.GetComponent<AudioSource>();
        if (music != null) music.Play();
        collision.gameObject.GetComponent<Collider2D>().enabled = false;
        collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(music.clip.length);
        Destroy(collision.gameObject);
    }
}

