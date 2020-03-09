using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] ParticleSystem winFX;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            winFX.Play();
            GetComponent<AudioSource>().Play();
            GameManager.Instance.EndLevel();
        }
    }
}
