﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicModifier : MonoBehaviour
{
    public enum _directionData { Up, Down, Right, Left};
    public _directionData _direction;
    private Vector2 _physicForce = Vector2.zero;
    [SerializeField] private float _physicForceMultiplieur = 1f;

    private void Start()
    {
        switch (_direction)
        {
            case _directionData.Up:
                _physicForce = GameManager.Instance._gravityUp;
                return;

            case _directionData.Down:
                _physicForce = GameManager.Instance._gravityDown;
                return;

            case _directionData.Right:
                _physicForce = GameManager.Instance._gravityRight;
                return;

            case _directionData.Left:
                _physicForce = GameManager.Instance._gravityLeft;
                return;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Physic_Movement>())
        {
            Physic_Movement moving_object = collision.GetComponent<Physic_Movement>();

            if (collision.CompareTag("Player"))
            {
                if (GameManager.Instance._gravityDirection == _physicForce)
                {
                    GameManager.Instance._gravityDirection = Vector2.zero;
                    GameManager.Instance._direction = default;
                }

                if((_direction == _directionData.Up) || (_direction == _directionData.Down) )
                {
                    GameManager.Instance.actualBlocking = GameManager._blockingMovement.BlockUpDown;
                }

                if ((_direction == _directionData.Right) || (_direction == _directionData.Left))
                {
                    GameManager.Instance.actualBlocking = GameManager._blockingMovement.BlockRightLeft;
                }
            }
            
            moving_object._externalGravity = _physicForce * _physicForceMultiplieur;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Physic_Movement>())
        {
            Physic_Movement moving_object = collision.GetComponent<Physic_Movement>();
            moving_object._externalGravity = Vector2.zero;
            GameManager.Instance.actualBlocking = GameManager._blockingMovement.None;

        }
    }
}
