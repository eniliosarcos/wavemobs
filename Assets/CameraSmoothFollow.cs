using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.05f;
    public Vector3 offset;

    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 _positionWithOffset = player.transform.position + offset;
        Vector3 _smoothPosition = Vector3.Lerp(transform.position, _positionWithOffset, smoothSpeed);
        transform.position = _smoothPosition;
    }
}
