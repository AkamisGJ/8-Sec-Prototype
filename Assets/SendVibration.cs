using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendVibration : MonoBehaviour
{
    [SerializeField] private int _millisecond = 50;

    public void VibrateOnce(int millisecond)
    {
        long millisecondLong = millisecond;
        Vibration.Vibrate(millisecondLong);
    }
}
