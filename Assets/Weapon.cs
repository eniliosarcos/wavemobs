using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float recoil;
    float _timeRecoil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Shot") == 0 && _timeRecoil != recoil || Input.GetAxisRaw("Shot") == 1 && _timeRecoil <= recoil)
        {
            _timeRecoil += Time.deltaTime;
        }
        else if (_timeRecoil >= recoil && Input.GetAxisRaw("Shot") == 1)
        {
            print("shot!");
            _timeRecoil = 0.0f;
        }
        if(_timeRecoil >= recoil && Input.GetAxisRaw("Shot") == 0 && _timeRecoil != recoil)
        {
            print("ready to shot!");
            _timeRecoil = recoil;
        }

    }
}
