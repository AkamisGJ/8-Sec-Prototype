using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Spike : MonoBehaviour
{
    [SerializeField] private long _vibrationDuration = 100;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vibration.Vibrate(_vibrationDuration);
            StartCoroutine(RestartLevel());
            
            //GetComponent<AudioSource>().Play();
        }
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(_vibrationDuration / 1000);
        GameManager.Instance.RestartLevel();
    }
}
