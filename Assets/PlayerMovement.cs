using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedMovement = 3.0f;
    public float speedRotation = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetdirection = new Vector3(Input.GetAxis("Horizontal right stick"), 0f, Input.GetAxis("Vertical right stick"));
        if (targetdirection != Vector3.zero)
        {
            targetdirection = Camera.main.transform.TransformDirection(targetdirection);
            targetdirection.y = 0.0f;
            Quaternion targetrotation = Quaternion.LookRotation(targetdirection, Vector3.up * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, speedRotation * Time.fixedDeltaTime);
        }

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input = Camera.main.transform.TransformDirection(input);
        input.y = 0.0f;
        transform.position += input*Time.deltaTime*speedMovement;
    }
}
