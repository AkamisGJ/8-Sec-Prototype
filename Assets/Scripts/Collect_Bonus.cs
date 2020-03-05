using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Bonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            GameManager.Instance.GetBonus();
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 5f);

        }
    }
}
