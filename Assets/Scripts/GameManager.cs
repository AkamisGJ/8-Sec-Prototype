using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;
using Doozy.Engine;

public class GameManager : Singleton<GameManager>
{
    [ReadOnly] [SerializeField] private Vector2 _gravityDirection = new Vector2(0f, -9.8f);
    [SerializeField] private float _gravityMultiplier = 1f;

    private Rigidbody2D _player;

    private bool _canMove = true;

    private Vector2 _gravityDown = new Vector2(0f, -9.8f);
    private Vector2 _gravityUp = new Vector2(0f, 9.8f);
    private Vector2 _gravityRight = new Vector2(9.8f, 0f);
    private Vector2 _gravityLeft = new Vector2(-9.8f, 0f);


    private void Start() {
        _player = Player.Instance.GetComponent<Rigidbody2D>();    
    }

    #if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            if(Input.GetButtonDown("Up")){
               _gravityDirection = _gravityUp;
               print("Up");
               UI_Manager.Instance.AddMovementToCounter();
            }

            if(Input.GetButtonDown("Down")){
               _gravityDirection = _gravityDown;
               print("Down");
               UI_Manager.Instance.AddMovementToCounter();
            }

            if(Input.GetButtonDown("Right")){
               _gravityDirection = _gravityRight;
               print("Right");
               UI_Manager.Instance.AddMovementToCounter();
            }

            if(Input.GetButtonDown("Left")){
               _gravityDirection = _gravityLeft;
               print("Left");
               UI_Manager.Instance.AddMovementToCounter();
            }


            Physics2D.gravity = _gravityDirection * _gravityMultiplier;
            _player.velocity = _gravityDirection * _gravityMultiplier;

        }
    }

    public void EndLevel()
    {
        _canMove = false;
        GameEventMessage.SendEvent("End_Level");

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    #endif
}
