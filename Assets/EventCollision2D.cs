using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class EventCollision2D : MonoBehaviour
{
    [Space(5f)]
    
    [Space(5f)]
    [TabGroup("On Enter")] [SerializeField] private UnityEvent _onTriggerEnter2D = null;
    [Space(5f)]
    [TabGroup("On Enter")] [SerializeField] private UnityEvent _onCollisionEnter2D = null;

    [Space(5f)]
    [TabGroup("On Stay")] [SerializeField] private UnityEvent _onTriggerStay2D = null;
    [Space(5f)]
    [TabGroup("On Stay")] [SerializeField] private UnityEvent _onCollisionStay2D = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _onTriggerEnter2D.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _onCollisionEnter2D.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _onTriggerStay2D.Invoke();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _onCollisionStay2D.Invoke();
    }
}
