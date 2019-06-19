using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float recoil;

    private float _timeRecoil;
    private float _inputTrigger;
    private BulletPool _bulletpool;

    void Awake()
    {
        _bulletpool = GetComponentInChildren<BulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        InputRecognition();
        Shot();
    }

    private void InputRecognition()
    {
        _inputTrigger = Input.GetAxisRaw("Shot");
    }

    private void Shot()
    {
        if (_inputTrigger == 0 && _timeRecoil != recoil || _inputTrigger == 1 && _timeRecoil <= recoil)
        {
            _timeRecoil += Time.deltaTime;
        }
        else if (_timeRecoil >= recoil && _inputTrigger == 1)
        {
            _bulletpool.CallBullet();
            _timeRecoil = 0.0f;
        }
        if (_timeRecoil >= recoil && _inputTrigger == 0 && _timeRecoil != recoil)
        {
            print("ready to shot!");
            _timeRecoil = recoil;
        }
    }
}
