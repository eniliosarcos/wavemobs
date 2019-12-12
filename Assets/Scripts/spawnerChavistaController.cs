using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerChavistaController : MonoBehaviour
{
    public string rootName;
    public int chavistasAmount;
    public GameObject[] chavistasToPool;

    List<GameObject> chavistasList = new List<GameObject>();

    float _timer = 0.0f;
    bool _spawnNewChavista = false;


    GameObject GetInactiveChavistaFromList()
    {
        GameObject _chavista = null;

        for (int i = 0; i < chavistasList.Count; i++)
        {
            if (!chavistasList[i].activeInHierarchy)
            {
                _chavista = chavistasList[i];
                break;
            }
        }
        return _chavista;
    }

    Vector3 GetPositionToSpawnTheChavista()
    {
        List<Vector3> _positions = new List<Vector3>();

        foreach (Transform item in GetComponentsInChildren<Transform>())
            _positions.Add(item.localPosition);

        return _positions[UnityEngine.Random.Range(0, _positions.Count)];
    }

    float Timer()
    {
        return _timer += Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateChavistaList();
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer() > 1 && !_spawnNewChavista)
        {
            _spawnNewChavista = true;
            SpawnChavista(GetPositionToSpawnTheChavista());
            
        }
    }

    void SpawnChavista(Vector3 _position)
    {
        GameObject _chavista = GetInactiveChavistaFromList();

        _chavista.transform.position = _position;
        _chavista.SetActive(true);
    }

    private void CreateChavistaList()
    {
        GameObject Root = new GameObject();
        Root.name = rootName;

        foreach (var item in chavistasToPool)
        {
            if (!item)
            {
                print("Whoops... You miss a prefab enemy in the list.");
                return;
            }
        }

        for (int i = 0; i < chavistasAmount; i++)
        {
            GameObject obj = Instantiate(chavistasToPool[UnityEngine.Random.Range(0, chavistasToPool.Length)]);
            obj.transform.parent = Root.transform;
            obj.SetActive(false);
            chavistasList.Add(obj);
        }
    }
}
