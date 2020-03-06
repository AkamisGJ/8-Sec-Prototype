using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintApplicationNumber : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "V." + Application.version;
    }
}
