using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TruckMovement : MonoBehaviour
{
    #region Champs
    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _jump;
    //[SerializeField] InputActionReference _attack;
    [SerializeField] InputActionReference _speedRun;
    [SerializeField] Rigidbody _carRb;
    [SerializeField] Vector3 _jumpForce;
    [SerializeField] Vector3 _carRotation;
    [SerializeField] int _speed, _run;


    Vector3 _playerDir;
    bool _isMoving;
    bool _isRun;
    bool _isJump;
    //bool _isAttack;

    #endregion

    #region Start
    void Start ()
    {
        //Move
        _move.action.started += StartMove;
        _move.action.performed += StartMove;
        _move.action.canceled += StopMove;

        //Run
        _speedRun.action.started += RunStart;
        _speedRun.action.canceled += RunStop;

        //Jump
        _jump.action.started += JumpStart;
        _jump.action.performed += JumpStart;
        _jump.action.canceled += EndJump;

    }

    #endregion

    public void Disactivate () => _move.action.actionMap.Disable ();

    #region Update
    void Update ()
    {        
        Vector3 _directionMove = new Vector3 (_playerDir.x, _playerDir.z, _playerDir.y);

        Move (_directionMove);
        
        Run (_directionMove);

        Jump ();
    }
    #endregion

    #region Methode (Move, Run, Jump)
    void Move (Vector3 Direction)
    {
        //Move
        if (_isMoving)
        {
            transform.Translate (Direction * _speed * Time.deltaTime);
        }
    }

    void Run (Vector3 Direction)
    {
        //Run
        if (_isRun)
        {
            transform.Translate ( Direction * _speed * _run * Time.deltaTime);
        }
    }

    void Jump ()
    {
        //Jump
        if (_isJump)
        {
            _carRb.AddForce (_jumpForce * Time.deltaTime);
        }
    }
    #endregion

    #region Move
    private void StartMove (InputAction.CallbackContext obj)
    {
        _playerDir = obj.ReadValue<Vector2> ();
        _isMoving= true;
        
        if (_playerDir.x > 0)
        {
            transform.rotation = Quaternion.Euler (_carRotation);
        }
        
        else if (_playerDir.x < 0)
        {
            transform.rotation = Quaternion.Euler (-_carRotation);            
        }

        else
        {
            transform.rotation = Quaternion.Euler (0, 0, 0);
        }
    }

    private void StopMove (InputAction.CallbackContext obj)
    {
        _playerDir = Vector3.zero;
        _isMoving = false;
        transform.rotation = Quaternion.Euler (0, 0, 0);            
    }
    #endregion

    #region Run
    private void RunStart (InputAction.CallbackContext obj)
    {
        _isRun = true;
    }

    private void RunStop (InputAction.CallbackContext obj)
    {
        _isRun = false;
    }
    #endregion

    #region Jump
    private void JumpStart (InputAction.CallbackContext obj)
    {
        _isJump = true;
    }

    private void EndJump (InputAction.CallbackContext obj)
    {
        _isJump = false;
    }
    #endregion
}
