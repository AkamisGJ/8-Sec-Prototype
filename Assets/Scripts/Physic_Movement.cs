using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Physic_Movement : MonoBehaviour
{
    [ReadOnly] [SerializeField] private Vector2 _gravityDirection = new Vector2(0f, -9.8f);
    [ReadOnly] [SerializeField] public Vector2 _externalGravity = Vector2.zero;
    [SerializeField] public float _personalGravityMultiplier = 1f;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }



    public void Moving()
    {
        _gravityDirection = GameManager.Instance._gravityDirection;
        _rigidbody2D.velocity = ( (_gravityDirection + _externalGravity) * GameManager.Instance._gravityMultiplier * _personalGravityMultiplier ) * GameManager.Instance._accelerationValue;
    }
}
