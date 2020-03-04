using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertisementManager : MonoBehaviour
{
    
    public void OpenWebsite(string website_url){
        Application.OpenURL(website_url);
    }
}
