using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLineRenderer : MonoBehaviour
{
    public void ClearTrail(bool activate)
    {
        GameObject.FindGameObjectWithTag("Trail_Tuto").GetComponent<TrailRenderer>().Clear();
        GameObject.FindGameObjectWithTag("Trail_Tuto").GetComponent<TrailRenderer>().enabled = activate;

    }
}
