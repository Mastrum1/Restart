using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public UnityEvent Fire; 
    
    public InputContoller InputContoller;
    private InputAction _moveAction;
    private InputAction _fireAction;
    private InputAction _spawnCatAction;

    [SerializeField] private int _moveSpeed = 2;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _poi;

    public InputAction SpawnCatAction => _spawnCatAction;
    
    // Start is called before the first frame update
    void Awake()
    {
        InputContoller = new InputContoller();
    }

    private void OnEnable()
    {
        _moveAction = InputContoller.Player.Move;
        _moveAction.Enable();
        _fireAction = InputContoller.Player.Fire;
        _fireAction.Enable();
        _spawnCatAction = InputContoller.Player.SpawnCat;
        _spawnCatAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _fireAction.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDir = (_moveAction.ReadValue<Vector2>().y * Vector3.forward + _moveAction.ReadValue<Vector2>().x * Vector3.right) * _moveSpeed * Time.deltaTime;
        _playerRigidbody.velocity = moveDir;
        gameObject.transform.LookAt(_poi.transform);
        gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z);

        if (_fireAction.ReadValue<float>() > 0)
        {
            Fire.Invoke();
        }
    }
}