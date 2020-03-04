using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Spike : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.RestartLevel();
        }
    }
}
