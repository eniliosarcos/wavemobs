using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    public Transform player;       //Public variable to store a reference to the player game object
    public float smoothSpeed = 0.05f;
    public Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        Vector3 _positionWithOffset = player.transform.position + offset;
        Vector3 _smoothPosition = Vector3.Lerp(transform.position, _positionWithOffset, smoothSpeed);
        transform.position = _smoothPosition;
    }
}
