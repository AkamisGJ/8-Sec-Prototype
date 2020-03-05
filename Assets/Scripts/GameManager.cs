using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;
using Doozy.Engine;
using System;

public class GameManager : Singleton<GameManager>
{
    [Title("Gravity")]

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

    [Title("Acceleration")]
    [InfoBox("Controlle la vitesse de déplacement des objects")]
    [SerializeField] private AnimationCurve _accelerationSpeedCurve;
    private float _accelerationCurveTime = 0f;
    [HideInInspector] public float _accelerationValue;


    private List<Physic_Movement> movingObjects = new List<Physic_Movement>();



    private void Start() {
        SwipeDetector.OnSwipe += ChangeGravity;
        _player = Player.Instance.GetComponent<Rigidbody2D>();
        foreach(Physic_Movement physic_object in FindObjectsOfType<Physic_Movement>())
        { 
            movingObjects.Add(physic_object);
        }
    }

    #if UNITY_WEBGL
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
    #endif

    //#if UNITY_ANDROID
    void Update()
    {
        if (_canMove)
        {
            ApplyForce();
        }
    }

    private void ChangeGravity(SwipeData data){
        if (_canMove)
        {
            if(actualBlocking != _blockingMovement.BlockUpDown)
            {
                switch (data.Direction)
                {
                    case SwipeDirection.Up:
                        _gravityDirection = _gravityUp;
                        _direction = _directionData.UpDown;
                        UI_Manager.Instance.AddMovementToCounter();

                        break;

                    case SwipeDirection.Down:
                        _gravityDirection = _gravityDown;
                        _direction = _directionData.UpDown;
                        UI_Manager.Instance.AddMovementToCounter();
                        break;
                }
            }

            if (actualBlocking != _blockingMovement.BlockRightLeft)
            {
                switch (data.Direction)
                {
                    case SwipeDirection.Right:
                        _gravityDirection = _gravityRight;
                        _direction = _directionData.RightLeft;
                        UI_Manager.Instance.AddMovementToCounter();

                        break;

                    case SwipeDirection.Left:
                        _gravityDirection = _gravityLeft;
                        _direction = _directionData.RightLeft;
                        UI_Manager.Instance.AddMovementToCounter();
                        break;
                }
            }

            ResetAcceleration();
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
            _accelerationCurveTime += Time.deltaTime;
            _accelerationValue = _accelerationSpeedCurve.Evaluate(_accelerationCurveTime);
            foreach (Physic_Movement physic_objects in movingObjects)
            { 
           
                physic_objects.Moving();
            }
        }
    }

    public void ResetAcceleration()
    {
        _accelerationCurveTime = 0f;
    }

    public void GetBonus()
    {
        StarCount.Instance.UnlockStar(2);
    }

    public void EndLevel()
    {
        _canMove = false;
        GameEventMessage.SendEvent("End_Level");

        //Stars Count
        StarCount.Instance.UnlockStar(1);
        if(UI_Manager.Instance.GetCountMovement() <= StarCount.Instance.maximumMovementForThisLevel)
        {
            StarCount.Instance.UnlockStar(3);
        }

        StartCoroutine(StarCount.Instance.SendDataToUI());

    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadNextLevel()
    {
        SwipeDetector.OnSwipe -= ChangeGravity;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SwipeDetector.OnSwipe -= ChangeGravity;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
