using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : Singleton<UI_Manager>
{
    public TextMeshProUGUI _movementCounter = null;
    private int _movementCount = 0;
    
    
    public void AddMovementToCounter()
    {
        _movementCount++;
        _movementCounter.text = "Movement = " + _movementCount;
    }
}
