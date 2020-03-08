using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Manager : Singleton<UI_Manager>
{
    public TextMeshProUGUI _movementCounter = null;
    public TextMeshProUGUI _movementFait = null;
    public TextMeshProUGUI _movementAfaire = null;

    public TextMeshProUGUI _stageCounter = null;
    private int _movementCount = 0;

    private void Start()
    {
        _stageCounter.text = "Stage " + SceneManager.GetActiveScene().buildIndex;
        PrintMovement();

    }


    public void AddMovementToCounter()
    {
        _movementCount++;
        PrintMovement();
    }

    private void PrintMovement()
    {
        _movementCounter.text = "Movement = ";
        _movementFait.text = _movementCount.ToString();
        if(_movementCount <= StarCount.Instance.maximumMovementForThisLevel)
        {
            _movementFait.color = Color.green;
        }
        else
        {
            _movementFait.color = Color.red;
        }
        _movementAfaire.text = " / " + StarCount.Instance.maximumMovementForThisLevel.ToString();
    }

    public int GetCountMovement()
    {
        return _movementCount;
    }
}
