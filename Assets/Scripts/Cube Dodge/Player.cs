using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float _moveX;
    [SerializeField] float _movePower;
    Rigidbody _playerRb;
    Vector3 _moveVec;

	void Start () {
        _playerRb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        GetInput();
    }

    void FixedUpdate () {
        MovePlayer();
	}

    void MovePlayer()
    {
        _moveVec = new Vector3(0, 0, -_moveX) * _movePower;
        _playerRb.AddTorque(_moveVec, ForceMode.VelocityChange);
    }

    void GetInput()
    {
        _moveX = Input.GetAxis("Horizontal");
    }
}
