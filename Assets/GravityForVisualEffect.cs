using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class GravityForVisualEffect : MonoBehaviour
{
    private VisualEffect bonus_etoile;


    private void Start()
    {
        bonus_etoile = GetComponent<VisualEffect>();
    }
    // Update is called once per frame
    void Update()
    {
        bonus_etoile.SetVector3("Gravity", GameManager.Instance._gravityDirection);
    }

    public void PlayParticuleSystem()
    {
        bonus_etoile.Play();
    }
}
