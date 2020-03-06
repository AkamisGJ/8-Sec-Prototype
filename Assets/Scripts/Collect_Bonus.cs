using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Bonus : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _customSimulationSpace = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            _customSimulationSpace.simulated = true;
            GameManager.Instance.GetBonus();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject, 5f);

        }
    }
}
