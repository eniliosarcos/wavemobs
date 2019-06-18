using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralBullet : MonoBehaviour
{
    public float duration;
    public float speedMovement;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Sleep());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speedMovement;
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }

}
