using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class MusicManager : MonoBehaviour
{
    UIToggle toogle;
    // Start is called before the first frame update
    void Start()
    {
        toogle = GetComponent<UIToggle>();
        int state = PlayerPrefs.GetInt("Mute", 0);
        if(state == 1)
        {
            toogle.IsOn = true;
        }
        else
        {
            toogle.IsOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (toogle.IsOn)
        {
            GameMusicPlayer.Instance.GetComponent<AudioSource>().mute = true;
            PlayerPrefs.SetInt("Mute", 1);
        }
        else
        {
            GameMusicPlayer.Instance.GetComponent<AudioSource>().mute = false;
            PlayerPrefs.SetInt("Mute", 0);
        }
    }

}
