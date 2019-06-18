using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedMovement = 3.0f;
    public float speedRotation = 4.0f;

    private Camera _mainCamera;
    private Vector3 _inputDirection;
    private Vector3 _inputMovement;

    void Awake()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        InputRecognition();
    }

    void LateUpdate()
    {
        Rotation();
        Movement();
    }

    private void InputRecognition()
    {
        _inputDirection = new Vector3(Input.GetAxis("Horizontal right stick"), 0f, Input.GetAxis("Vertical right stick"));
        _inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

    private void Rotation()
    {
        if (_inputDirection != Vector3.zero)
        {
            _inputDirection = _mainCamera.transform.TransformDirection(_inputDirection);
            _inputDirection.y = 0.0f;
            Quaternion targetrotation = Quaternion.LookRotation(_inputDirection, Vector3.up * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, speedRotation * Time.deltaTime);
        }
    }

    private void Movement()
    {
        _inputMovement = _mainCamera.transform.TransformDirection(_inputMovement);
        _inputMovement.y = 0.0f;
        transform.position += _inputMovement * Time.deltaTime * speedMovement;
    }
}
