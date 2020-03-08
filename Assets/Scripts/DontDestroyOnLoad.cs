using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : Singleton<DontDestroyOnLoad>
{
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<AudioSource>())
        {
            AudioSource audiosource = GetComponent<AudioSource>();
            if (audiosource.isPlaying)
            {
                return;
            }
            else
            {
                audiosource.Play();
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
