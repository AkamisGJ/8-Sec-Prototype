using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;
using Doozy.Engine;

public class GameManager : Singleton<GameManager>
{
    [ReadOnly] [SerializeField] public Vector2 _gravityDirection = new Vector2(0f, -9.8f);
    [ReadOnly] [SerializeField] public Vector2 _externalGravity = Vector2.zero;
    [SerializeField] public float _gravityMultiplier = 1f;


    private Rigidbody2D _player;

    private bool _canMove = true;

    public enum _directionData { UpDown, RightLeft };
    [ReadOnly] public _directionData _direction = default;

    public enum _blockingMovement { BlockUpDown, BlockRightLeft, None };
    public _blockingMovement actualBlocking = _blockingMovement.None;

    [HideInInspector] public Vector2 _gravityDown = new Vector2(0f, -9.8f);
    [HideInInspector] public Vector2 _gravityUp = new Vector2(0f, 9.8f);
    [HideInInspector] public Vector2 _gravityRight = new Vector2(9.8f, 0f);
    [HideInInspector] public Vector2 _gravityLeft = new Vector2(-9.8f, 0f);

    private List<Physic_Movement> movingObjects = new List<Physic_Movement>();


    private void Start() {
        //_player = FindObjectOfType<Player>().GetComponent<Rigidbody2D>();
        _player = Player.Instance.GetComponent<Rigidbody2D>();
        foreach(Physic_Movement physic_object in FindObjectsOfType<Physic_Movement>())
        { 
            movingObjects.Add(physic_object);
        }
    }

    //#if UNITY_EDITOR
    void Update()
    {
        if (_canMove)
        {
            if(actualBlocking != _blockingMovement.BlockUpDown)
            {
                if(Input.GetButtonDown("Up")){
                   _gravityDirection = _gravityUp;
                    _direction = _directionData.UpDown;
                   UI_Manager.Instance.AddMovementToCounter();
                }

                if(Input.GetButtonDown("Down")){
                   _gravityDirection = _gravityDown;
                    _direction = _directionData.UpDown;
                    UI_Manager.Instance.AddMovementToCounter();
                }

            }

            if(actualBlocking != _blockingMovement.BlockRightLeft)
            {
                if(Input.GetButtonDown("Right")){
                   _gravityDirection = _gravityRight;
                    _direction = _directionData.RightLeft;
                    UI_Manager.Instance.AddMovementToCounter();
                }

                if (Input.GetButtonDown("Left"))
                {
                    _gravityDirection = _gravityLeft;
                    _direction = _directionData.RightLeft;
                    UI_Manager.Instance.AddMovementToCounter();
                }
            }

            ApplyForce();

        }
    }
    //#endif

    public virtual void ApplyForce()
    {
        /*
         * Permet de modifer toute la gravité de la scene. Comportement réaliste
         */
        //Physics2D.gravity = _gravityDirection * _gravityMultiplier;


        /*
         * Permet déplacer les object indépedemant. Comportement non réaliste
         */
        if (movingObjects.Count > 0)
        {
            foreach (Physic_Movement physic_objects in movingObjects)
            { 
           
                physic_objects.Moving();
            }
        }
    }

    public void EndLevel()
    {
        _canMove = false;
        GameEventMessage.SendEvent("End_Level");

    }

    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    
}
