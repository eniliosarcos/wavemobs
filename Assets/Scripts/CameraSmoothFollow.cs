using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    Transform _player;
    public float smoothSpeed = 0.05f;
    public Vector3 offset;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        if(!_player)
        {
            print("The player is not detected in the Scene. I'll turn off.");
            this.enabled = false;
        }
    }
    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 _positionWithOffset = _player.transform.position + offset;
        Vector3 _smoothPosition = Vector3.Lerp(transform.position, _positionWithOffset, smoothSpeed);
        transform.position = _smoothPosition;
    }
}
