using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    //public string nameOfLevel = null;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            GameManager.Instance.EndLevel();
        }
    }
}
