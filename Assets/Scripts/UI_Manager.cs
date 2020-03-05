using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Manager : Singleton<UI_Manager>
{
    public TextMeshProUGUI _movementCounter = null;
    public TextMeshProUGUI _stageCounter = null;
    private int _movementCount = 0;

    private void Start()
    {
        _stageCounter.text = "Stage " + SceneManager.GetActiveScene().buildIndex;
    }


    public void AddMovementToCounter()
    {
        _movementCount++;
        _movementCounter.text = "Movement = " + _movementCount;
    }

    public int GetCountMovement()
    {
        return _movementCount;
    }
}
